namespace LoginEkrani
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBoxKullaniciAdi = new TextBox();
            textBoxSifre = new TextBox();
            buttonKaydol = new Button();
            buttonGiris = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(115, 83);
            label1.Name = "label1";
            label1.Size = new Size(95, 20);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 149);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 1;
            label2.Text = "Şifre:";
            // 
            // textBoxKullaniciAdi
            // 
            textBoxKullaniciAdi.Location = new Point(213, 83);
            textBoxKullaniciAdi.Name = "textBoxKullaniciAdi";
            textBoxKullaniciAdi.Size = new Size(156, 27);
            textBoxKullaniciAdi.TabIndex = 2;
            // 
            // textBoxSifre
            // 
            textBoxSifre.Location = new Point(213, 142);
            textBoxSifre.Name = "textBoxSifre";
            textBoxSifre.Size = new Size(156, 27);
            textBoxSifre.TabIndex = 3;
            // 
            // buttonKaydol
            // 
            buttonKaydol.Location = new Point(162, 218);
            buttonKaydol.Name = "buttonKaydol";
            buttonKaydol.Size = new Size(93, 30);
            buttonKaydol.TabIndex = 4;
            buttonKaydol.Text = "Kaydol";
            buttonKaydol.UseVisualStyleBackColor = true;
            buttonKaydol.Click += buttonKaydol_Click;
            // 
            // buttonGiris
            // 
            buttonGiris.Location = new Point(290, 218);
            buttonGiris.Name = "buttonGiris";
            buttonGiris.Size = new Size(93, 30);
            buttonGiris.TabIndex = 5;
            buttonGiris.Text = "Giriş";
            buttonGiris.UseVisualStyleBackColor = true;
            buttonGiris.Click += buttonGiris_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 336);
            Controls.Add(buttonGiris);
            Controls.Add(buttonKaydol);
            Controls.Add(textBoxSifre);
            Controls.Add(textBoxKullaniciAdi);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxKullaniciAdi;
        private TextBox textBoxSifre;
        private Button buttonKaydol;
        private Button buttonGiris;
    }
}