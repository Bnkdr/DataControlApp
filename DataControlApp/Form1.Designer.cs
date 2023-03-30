namespace DataControlApp
{
    partial class Form1
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
            this.btn_sil = new System.Windows.Forms.Button();
            this.btn_ekle = new System.Windows.Forms.Button();
            this.btn_ara = new System.Windows.Forms.Button();
            this.btn_güncelle = new System.Windows.Forms.Button();
            this.txt_sirano = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_yatılılık = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_sube = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_sınıf = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_numara = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_soyisim = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_isim = new System.Windows.Forms.TextBox();
            this.btn_temizle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_sil
            // 
            this.btn_sil.Location = new System.Drawing.Point(175, 287);
            this.btn_sil.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_sil.Name = "btn_sil";
            this.btn_sil.Size = new System.Drawing.Size(200, 33);
            this.btn_sil.TabIndex = 0;
            this.btn_sil.Text = "Sil";
            this.btn_sil.UseVisualStyleBackColor = true;
            this.btn_sil.Click += new System.EventHandler(this.btn_sil_Click);
            // 
            // btn_ekle
            // 
            this.btn_ekle.Location = new System.Drawing.Point(175, 250);
            this.btn_ekle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.Size = new System.Drawing.Size(200, 33);
            this.btn_ekle.TabIndex = 8;
            this.btn_ekle.Text = "Ekle";
            this.btn_ekle.UseVisualStyleBackColor = true;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_ara
            // 
            this.btn_ara.Location = new System.Drawing.Point(175, 361);
            this.btn_ara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(200, 33);
            this.btn_ara.TabIndex = 3;
            this.btn_ara.Text = "Ara";
            this.btn_ara.UseVisualStyleBackColor = true;
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // btn_güncelle
            // 
            this.btn_güncelle.Location = new System.Drawing.Point(175, 324);
            this.btn_güncelle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_güncelle.Name = "btn_güncelle";
            this.btn_güncelle.Size = new System.Drawing.Size(200, 33);
            this.btn_güncelle.TabIndex = 4;
            this.btn_güncelle.Text = "Güncelle";
            this.btn_güncelle.UseVisualStyleBackColor = true;
            this.btn_güncelle.Click += new System.EventHandler(this.btn_güncelle_Click);
            // 
            // txt_sirano
            // 
            this.txt_sirano.Location = new System.Drawing.Point(175, 40);
            this.txt_sirano.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_sirano.Name = "txt_sirano";
            this.txt_sirano.Size = new System.Drawing.Size(201, 20);
            this.txt_sirano.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sıra No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 212);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Yatılılık Durumu";
            // 
            // txt_yatılılık
            // 
            this.txt_yatılılık.Location = new System.Drawing.Point(175, 210);
            this.txt_yatılılık.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_yatılılık.Name = "txt_yatılılık";
            this.txt_yatılılık.Size = new System.Drawing.Size(201, 20);
            this.txt_yatılılık.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Şube";
            // 
            // txt_sube
            // 
            this.txt_sube.Location = new System.Drawing.Point(175, 183);
            this.txt_sube.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_sube.Name = "txt_sube";
            this.txt_sube.Size = new System.Drawing.Size(201, 20);
            this.txt_sube.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 157);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Sınıf";
            // 
            // txt_sınıf
            // 
            this.txt_sınıf.Location = new System.Drawing.Point(175, 153);
            this.txt_sınıf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_sınıf.Name = "txt_sınıf";
            this.txt_sınıf.Size = new System.Drawing.Size(201, 20);
            this.txt_sınıf.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 128);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Numara";
            // 
            // txt_numara
            // 
            this.txt_numara.Location = new System.Drawing.Point(175, 126);
            this.txt_numara.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_numara.Name = "txt_numara";
            this.txt_numara.Size = new System.Drawing.Size(201, 20);
            this.txt_numara.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Soyisim";
            // 
            // txt_soyisim
            // 
            this.txt_soyisim.Location = new System.Drawing.Point(175, 99);
            this.txt_soyisim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_soyisim.Name = "txt_soyisim";
            this.txt_soyisim.Size = new System.Drawing.Size(201, 20);
            this.txt_soyisim.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 70);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "İsim";
            // 
            // txt_isim
            // 
            this.txt_isim.Location = new System.Drawing.Point(175, 70);
            this.txt_isim.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_isim.Name = "txt_isim";
            this.txt_isim.Size = new System.Drawing.Size(201, 20);
            this.txt_isim.TabIndex = 2;
            // 
            // btn_temizle
            // 
            this.btn_temizle.Location = new System.Drawing.Point(34, 291);
            this.btn_temizle.Name = "btn_temizle";
            this.btn_temizle.Size = new System.Drawing.Size(86, 53);
            this.btn_temizle.TabIndex = 19;
            this.btn_temizle.Text = "Temizle";
            this.btn_temizle.UseVisualStyleBackColor = true;
            this.btn_temizle.Click += new System.EventHandler(this.btn_temizle_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 421);
            this.Controls.Add(this.btn_temizle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_isim);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_soyisim);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_numara);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_sınıf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_sube);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_yatılılık);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sirano);
            this.Controls.Add(this.btn_güncelle);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.btn_sil);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sil;
        private System.Windows.Forms.Button btn_ekle;
        private System.Windows.Forms.Button btn_ara;
        private System.Windows.Forms.Button btn_güncelle;
        private System.Windows.Forms.TextBox txt_sirano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_yatılılık;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_sube;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_sınıf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_numara;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_soyisim;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_isim;
        private System.Windows.Forms.Button btn_temizle;
    }
}

