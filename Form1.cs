using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vosk;

namespace Speech_To_Text
{
    public partial class Form1 : Form
    {

        private VoskRecognizer recognizer;
        private WaveInEvent waveIn;
        private Model model;
        private bool kayitAktif = false;

        public Form1()
        {
            InitializeComponent();
            ComboBoxDilSecimiDoldur();
        }

        private void ComboBoxDilSecimiDoldur()
        {
            // ComboBox'a dilleri ekle
            comboBoxDilSecimi.Items.Add("Türkçe");
            comboBoxDilSecimi.Items.Add("İngilizce");
            comboBoxDilSecimi.Items.Add("Almanca");
            comboBoxDilSecimi.SelectedIndex = 0; // Varsayılan olarak Türkçe
        }

        private async Task<bool> DilModeliYukleAsync(string dil)
        {
            string modelYolu = "";

            // Model yollarını burada belirleyin.
            // İsterseniz buraya mutlak yolu yazın veya çalışma dizinine göre relative bırakın.
            switch (dil)
            {
                case "Türkçe":
                    modelYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vosk-model-small-tr-0.3");
                    break;
                case "İngilizce":
                    modelYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vosk-model-small-en-us-0.15");
                    break;
                case "Almanca":
                    // Orijinalinizdeki boşluk/dash sorunlarını düzelttim; kendi klasör adınıza göre güncelleyin.
                    modelYolu = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "vosk-model-small-de-0.15");
                    break;
                default:
                    MessageBox.Show("Bilinmeyen dil seçimi.");
                    return false;
            }

            if (!Directory.Exists(modelYolu))
            {
                MessageBox.Show($"{dil} modeli bulunamadı: {modelYolu}");
                return false;
            }

            // Disable controls while loading
            this.Invoke(new Action(() =>
            {
                butonBaslatDurdur.Enabled = false;
                comboBoxDilSecimi.Enabled = false;
                listBoxLog.Items.Add($"{dil} modeli yükleniyor: {modelYolu}");
            }));

            // Dispose old recognizer/model safely
            try
            {
                if (recognizer != null)
                {
                    recognizer.Dispose();
                    recognizer = null;
                }

                if (model != null)
                {
                    model.Dispose();
                    model = null;
                }
            }
            catch { }

            try
            {
                // Load model in background thread to avoid UI freeze
                await Task.Run(() =>
                {
                    model = new Model(modelYolu);
                    recognizer = new VoskRecognizer(model, 16000.0f);
                    recognizer.SetMaxAlternatives(0);
                    recognizer.SetWords(true);
                });

                this.Invoke(new Action(() =>
                {
                    listBoxLog.Items.Add($"{dil} modeli yüklendi: {modelYolu}");
                    MessageBox.Show("Model başarıyla yüklendi.");
                }));

                return true;
            }
            catch (Exception ex)
            {
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show($"Model yüklenirken hata oluştu: {ex.Message}");
                    listBoxLog.Items.Add($"Model yüklenirken hata: {ex.Message}");
                }));

                return false;
            }
            finally
            {
                // Re-enable controls
                this.Invoke(new Action(() =>
                {
                    butonBaslatDurdur.Enabled = true;
                    comboBoxDilSecimi.Enabled = true;
                }));
            }
        }

        private void SesKaydiniBaslat()
        {
            try
            {
                waveIn = new WaveInEvent();
                waveIn.BufferMilliseconds = 50;
                waveIn.WaveFormat = new WaveFormat(16000, 1); // 16kHz, mono
                waveIn.DataAvailable += WaveIn_DataAvailable;
                waveIn.RecordingStopped += WaveIn_RecordingStopped;

                waveIn.StartRecording();
                kayitAktif = true;

                butonBaslatDurdur.Text = "Durdur";
                listBoxLog.Items.Add("Ses kaydı başlatıldı");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ses kaydı başlatılamadı: {ex.Message}");
            }
        }


        private void SesKaydiniDurdur()
        {
            if (waveIn != null)
            {
                try
                {
                    waveIn.DataAvailable -= WaveIn_DataAvailable;
                    waveIn.RecordingStopped -= WaveIn_RecordingStopped;
                    waveIn.StopRecording();
                    waveIn.Dispose();
                    waveIn = null;
                }
                catch { }

                kayitAktif = false;
                butonBaslatDurdur.Text = "Başlat";
                listBoxLog.Items.Add("Ses kaydı durduruldu");
            }
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (recognizer != null && e.BytesRecorded > 0)
            {
                // Ses verisini işle
                if (recognizer.AcceptWaveform(e.Buffer, e.BytesRecorded))
                {
                    string sonucJson = recognizer.Result();
                    var sonuc = JsonConvert.DeserializeObject<SpeechResult>(sonucJson);

                    if (!string.IsNullOrEmpty(sonuc?.text))
                    {
                        // UI thread'ine güvenli şekilde erişim
                        this.Invoke(new Action(() =>
                        {
                            textBoxMetinCikisi.Text = sonuc.text;
                            listBoxLog.Items.Add($"Tanındı: {sonuc.text}");
                        }));
                    }
                }
                else
                {
                    // Kısmi sonuç
                    string kismiSonucJson = recognizer.PartialResult();
                    var kismiSonuc = JsonConvert.DeserializeObject<PartialSpeechResult>(kismiSonucJson);

                    if (!string.IsNullOrEmpty(kismiSonuc?.partial))
                    {
                        this.Invoke(new Action(() =>
                        {
                            labelKismiSonuc.Text = $"Kısmi: {kismiSonuc.partial}";
                        }));
                    }
                }
            }
        }

        private void WaveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (e.Exception != null)
            {
                MessageBox.Show($"Ses kaydı hatası: {e.Exception.Message}");
            }
        }

        private async void butonBaslatDurdur_Click(object sender, EventArgs e)
        {
            if (!kayitAktif)
            {
                string secilenDil = comboBoxDilSecimi.SelectedItem?.ToString() ?? "Türkçe";
                bool yuklemeBasarili = await DilModeliYukleAsync(secilenDil);
                if (yuklemeBasarili)
                {
                    SesKaydiniBaslat();
                }
            }
            else
            {
                SesKaydiniDurdur();
            }
        }

        private async void comboBoxDilSecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kayitAktif)
            {
                string secilenDil = comboBoxDilSecimi.SelectedItem?.ToString() ?? "Türkçe";

                // Stop recording first to free audio device and recognizer
                SesKaydiniDurdur();

                bool yuklemeBasarili = await DilModeliYukleAsync(secilenDil);
                if (yuklemeBasarili)
                {
                    SesKaydiniBaslat();
                    listBoxLog.Items.Add($"Dil değiştirildi: {secilenDil}");
                }
            }
        }

        private void butonTemizle_Click(object sender, EventArgs e)
        {
            textBoxMetinCikisi.Clear();
            labelKismiSonuc.Text = "Kısmi: ";
            listBoxLog.Items.Clear();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Kaynakları temizle
            SesKaydiniDurdur();

            if (recognizer != null)
                recognizer.Dispose();

            if (model != null)
                model.Dispose();

            base.OnFormClosing(e);
        }
    }

    // JSON deserialization için sınıflar
    public class SpeechResult
    {
        public string text { get; set; }
    }

    public class PartialSpeechResult
    {
        public string partial { get; set; }
    }
}