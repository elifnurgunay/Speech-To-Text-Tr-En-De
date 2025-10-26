# Speech To Text
<img width="1919" height="1026" alt="Ekran görüntüsü 2025-10-26 215354" src="https://github.com/user-attachments/assets/6ac5ca9a-9039-4a34-8c22-f755f6d4a560" />
<img width="1919" height="1024" alt="Ekran görüntüsü 2025-10-26 215430" src="https://github.com/user-attachments/assets/6aad895d-b5ba-42b0-907f-5c3128fd6c68" />


# 🗣️ Speech-To-Text Çok Dilli Uygulama

Bu proje, [Vosk](https://alphacephei.com/vosk/) açık kaynak konuşma tanıma motorunu kullanarak Türkçe, İngilizce ve Almanca dillerinde gerçek zamanlı ses tanıma sağlar. 
Mikrofon üzerinden alınan ses, metne dönüştürülerek arayüzde gösterilir.

---

## 🚀 Özellikler

- ✅ Gerçek zamanlı konuşma tanıma
- 🌐 Türkçe, İngilizce, Almanca dil desteği
- 🔄 Dinamik dil değiştirme
- 🧠 Kısmi ve tam tanıma sonuçları
- 🎙️ Mikrofon üzerinden canlı ses alımı
- 🧹 Temizleme ve kaynak yönetimi

---

## 🛠️ Kullanılan Teknolojiler

| Teknoloji       | Açıklama                          |
|----------------|-----------------------------------|
| C# / WinForms   | Arayüz ve uygulama mantığı        |
| Vosk API        | Konuşma tanıma motoru (`libvosk`) |
| NAudio          | Mikrofon verisi işleme            |
| Newtonsoft.Json | JSON ayrıştırma                   |

---

## ▶️ Kullanım

1. Uygulamayı çalıştırın.
2. Dil seçimini yapın (`Türkçe`, `İngilizce`, `Almanca`).
3. “Başlat” butonuna tıklayın.
4. Konuştuğunuz metin tanınarak ekranda gösterilir.
5. “Durdur” ile kaydı sonlandırabilir, “Temizle” ile arayüzü sıfırlayabilirsiniz.

---

## 📌 Notlar

- Vosk modelleri büyük olabilir, yükleme süresi birkaç saniye sürebilir.
- Mikrofon erişimi için uygulamayı yönetici olarak çalıştırmanız gerekebilir.
- Her modelin örnekleme hızı `16000 Hz` olarak ayarlanmıştır.
- GitHub’a yüklenen projede `libvosk.dll` dosyası yer almayabilir. Bu dosyayı manuel olarak eklemeniz gerekebilir.

---
🧹 Kapatma ve Temizlik
Uygulama kapanırken:
- Ses kaydı durdurulur
- recognizer, model, waveIn nesneleri dispose edilir

📬 Katkıda Bulunmak
Pull request’ler ve öneriler memnuniyetle karşılanır. Lütfen önce bir issue açarak tartışma başlatın.

