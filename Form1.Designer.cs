namespace Tez_Sablon_Kontrolu
{
    partial class TezSablon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ac = new System.Windows.Forms.Button();
            this.kontrol = new System.Windows.Forms.Button();
            this.cikis = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label = new System.Windows.Forms.Label();
            this.dosya_label = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ac
            // 
            this.ac.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ac.Location = new System.Drawing.Point(10, 12);
            this.ac.Name = "ac";
            this.ac.Size = new System.Drawing.Size(85, 49);
            this.ac.TabIndex = 0;
            this.ac.Text = "Aç";
            this.ac.UseVisualStyleBackColor = true;
            this.ac.Click += new System.EventHandler(this.ac_Click);
            // 
            // kontrol
            // 
            this.kontrol.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kontrol.Location = new System.Drawing.Point(187, 12);
            this.kontrol.Name = "kontrol";
            this.kontrol.Size = new System.Drawing.Size(85, 49);
            this.kontrol.TabIndex = 1;
            this.kontrol.Text = "Kontrol Et";
            this.kontrol.UseVisualStyleBackColor = true;
            this.kontrol.Click += new System.EventHandler(this.kontrol_Click);
            // 
            // cikis
            // 
            this.cikis.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cikis.Location = new System.Drawing.Point(358, 12);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(85, 49);
            this.cikis.TabIndex = 2;
            this.cikis.Text = "Çıkış";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.label.Location = new System.Drawing.Point(9, 72);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(120, 17);
            this.label.TabIndex = 4;
            this.label.Text = "Seçilen Dosya:";
            // 
            // dosya_label
            // 
            this.dosya_label.AutoSize = true;
            this.dosya_label.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold);
            this.dosya_label.Location = new System.Drawing.Point(129, 74);
            this.dosya_label.Name = "dosya_label";
            this.dosya_label.Size = new System.Drawing.Size(0, 13);
            this.dosya_label.TabIndex = 5;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.richTextBox1.Location = new System.Drawing.Point(10, 92);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(433, 327);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 425);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(433, 36);
            this.progressBar1.TabIndex = 7;
            // 
            // TezSablon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 474);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dosya_label);
            this.Controls.Add(this.label);
            this.Controls.Add(this.cikis);
            this.Controls.Add(this.kontrol);
            this.Controls.Add(this.ac);
            this.Name = "TezSablon";
            this.Text = "Tez Şablon Kontrolü";
            this.Load += new System.EventHandler(this.TezSablon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ac;
        private System.Windows.Forms.Button kontrol;
        private System.Windows.Forms.Button cikis;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label dosya_label;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

