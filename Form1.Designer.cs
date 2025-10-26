namespace Speech_To_Text
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxDilSecimi = new System.Windows.Forms.ComboBox();
            this.butonBaslatDurdur = new System.Windows.Forms.Button();
            this.textBoxMetinCikisi = new System.Windows.Forms.TextBox();
            this.labelKismiSonuc = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.butonTemizle = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // comboBoxDilSecimi
            this.comboBoxDilSecimi.FormattingEnabled = true;
            this.comboBoxDilSecimi.Location = new System.Drawing.Point(120, 20);
            this.comboBoxDilSecimi.Name = "comboBoxDilSecimi";
            this.comboBoxDilSecimi.Size = new System.Drawing.Size(200, 28);
            this.comboBoxDilSecimi.TabIndex = 0;

            // butonBaslatDurdur
            this.butonBaslatDurdur.Location = new System.Drawing.Point(340, 20);
            this.butonBaslatDurdur.Name = "butonBaslatDurdur";
            this.butonBaslatDurdur.Size = new System.Drawing.Size(100, 30);
            this.butonBaslatDurdur.TabIndex = 1;
            this.butonBaslatDurdur.Text = "Başlat";
            this.butonBaslatDurdur.UseVisualStyleBackColor = true;
            this.butonBaslatDurdur.Click += new System.EventHandler(this.butonBaslatDurdur_Click);

            // textBoxMetinCikisi
            this.textBoxMetinCikisi.Location = new System.Drawing.Point(20, 100);
            this.textBoxMetinCikisi.Multiline = true;
            this.textBoxMetinCikisi.Name = "textBoxMetinCikisi";
            this.textBoxMetinCikisi.Size = new System.Drawing.Size(420, 150);
            this.textBoxMetinCikisi.TabIndex = 2;

            // labelKismiSonuc
            this.labelKismiSonuc.AutoSize = true;
            this.labelKismiSonuc.Location = new System.Drawing.Point(20, 260);
            this.labelKismiSonuc.Name = "labelKismiSonuc";
            this.labelKismiSonuc.Size = new System.Drawing.Size(75, 20);
            this.labelKismiSonuc.TabIndex = 3;
            this.labelKismiSonuc.Text = "Kısmi: ";

            // listBoxLog
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 20;
            this.listBoxLog.Location = new System.Drawing.Point(20, 300);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(420, 144);
            this.listBoxLog.TabIndex = 4;

            // butonTemizle
            this.butonTemizle.Location = new System.Drawing.Point(340, 60);
            this.butonTemizle.Name = "butonTemizle";
            this.butonTemizle.Size = new System.Drawing.Size(100, 30);
            this.butonTemizle.TabIndex = 5;
            this.butonTemizle.Text = "Temizle";
            this.butonTemizle.UseVisualStyleBackColor = true;
            this.butonTemizle.Click += new System.EventHandler(this.butonTemizle_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dil Seçimi:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tanınan Metin:";

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Log:";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 473);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butonTemizle);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.labelKismiSonuc);
            this.Controls.Add(this.textBoxMetinCikisi);
            this.Controls.Add(this.butonBaslatDurdur);
            this.Controls.Add(this.comboBoxDilSecimi);
            this.Name = "Form1";
            this.Text = "Çok Dilli Speech-to-Text";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBoxDilSecimi;
        private System.Windows.Forms.Button butonBaslatDurdur;
        private System.Windows.Forms.TextBox textBoxMetinCikisi;
        private System.Windows.Forms.Label labelKismiSonuc;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button butonTemizle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

