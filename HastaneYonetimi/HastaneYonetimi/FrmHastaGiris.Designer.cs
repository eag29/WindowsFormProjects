namespace HastaneYonetimi
{
    partial class FrmHastaGiris
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sifretxt = new System.Windows.Forms.TextBox();
            this.tcmsk = new System.Windows.Forms.MaskedTextBox();
            this.btngirisyap = new System.Windows.Forms.Button();
            this.lbluyeol = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(119, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hasta Giriş Paneli";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "TC Kimlik No:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre:";
            // 
            // sifretxt
            // 
            this.sifretxt.Location = new System.Drawing.Point(185, 164);
            this.sifretxt.Name = "sifretxt";
            this.sifretxt.Size = new System.Drawing.Size(174, 29);
            this.sifretxt.TabIndex = 1;
            this.sifretxt.UseSystemPasswordChar = true;
            // 
            // tcmsk
            // 
            this.tcmsk.Location = new System.Drawing.Point(185, 121);
            this.tcmsk.Mask = "00000000000";
            this.tcmsk.Name = "tcmsk";
            this.tcmsk.Size = new System.Drawing.Size(174, 29);
            this.tcmsk.TabIndex = 0;
            this.tcmsk.ValidatingType = typeof(int);
            // 
            // btngirisyap
            // 
            this.btngirisyap.Location = new System.Drawing.Point(204, 210);
            this.btngirisyap.Name = "btngirisyap";
            this.btngirisyap.Size = new System.Drawing.Size(134, 41);
            this.btngirisyap.TabIndex = 6;
            this.btngirisyap.Text = "Giriş Yap";
            this.btngirisyap.UseVisualStyleBackColor = true;
            this.btngirisyap.Click += new System.EventHandler(this.btngirisyap_Click);
            // 
            // lbluyeol
            // 
            this.lbluyeol.AutoSize = true;
            this.lbluyeol.Location = new System.Drawing.Point(375, 170);
            this.lbluyeol.Name = "lbluyeol";
            this.lbluyeol.Size = new System.Drawing.Size(66, 23);
            this.lbluyeol.TabIndex = 7;
            this.lbluyeol.TabStop = true;
            this.lbluyeol.Text = "Üye Ol";
            this.lbluyeol.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbluyeol_LinkClicked);
            // 
            // FrmHastaGiris
            // 
            this.AcceptButton = this.btngirisyap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(546, 272);
            this.Controls.Add(this.lbluyeol);
            this.Controls.Add(this.btngirisyap);
            this.Controls.Add(this.tcmsk);
            this.Controls.Add(this.sifretxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.Name = "FrmHastaGiris";
            this.Text = "Hasta Giris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sifretxt;
        private System.Windows.Forms.MaskedTextBox tcmsk;
        private System.Windows.Forms.Button btngirisyap;
        private System.Windows.Forms.LinkLabel lbluyeol;
    }
}