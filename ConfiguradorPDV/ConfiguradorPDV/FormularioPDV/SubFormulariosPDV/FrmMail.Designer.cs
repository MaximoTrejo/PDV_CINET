namespace ConfiguradorPDV
{
    partial class FrmMail
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxUsaCierreMail = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxEnviaMaila = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCierreMail = new System.Windows.Forms.Button();
            this.tbxPasswordCorreo = new System.Windows.Forms.TextBox();
            this.tbxServicioSMTP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxPuertoSMTP = new System.Windows.Forms.TextBox();
            this.tbxCorreoEnvia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxSSL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.tbxEnviaMaila);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnCierreMail);
            this.groupBox1.Controls.Add(this.tbxPasswordCorreo);
            this.groupBox1.Controls.Add(this.tbxServicioSMTP);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxPuertoSMTP);
            this.groupBox1.Controls.Add(this.tbxCorreoEnvia);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxSSL);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 249);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cierre con Mail";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxUsaCierreMail);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 68);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cbxUsaCierreMail
            // 
            this.cbxUsaCierreMail.FormattingEnabled = true;
            this.cbxUsaCierreMail.Location = new System.Drawing.Point(6, 32);
            this.cbxUsaCierreMail.Name = "cbxUsaCierreMail";
            this.cbxUsaCierreMail.Size = new System.Drawing.Size(84, 21);
            this.cbxUsaCierreMail.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Usa Cierre Mail";
            // 
            // tbxEnviaMaila
            // 
            this.tbxEnviaMaila.Location = new System.Drawing.Point(235, 176);
            this.tbxEnviaMaila.Name = "tbxEnviaMaila";
            this.tbxEnviaMaila.Size = new System.Drawing.Size(84, 20);
            this.tbxEnviaMaila.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Envia Mail a";
            // 
            // btnCierreMail
            // 
            this.btnCierreMail.Location = new System.Drawing.Point(12, 213);
            this.btnCierreMail.Name = "btnCierreMail";
            this.btnCierreMail.Size = new System.Drawing.Size(75, 23);
            this.btnCierreMail.TabIndex = 30;
            this.btnCierreMail.Text = "Configurar";
            this.btnCierreMail.UseVisualStyleBackColor = true;
            this.btnCierreMail.Click += new System.EventHandler(this.btnCierreMail_Click);
            // 
            // tbxPasswordCorreo
            // 
            this.tbxPasswordCorreo.Location = new System.Drawing.Point(236, 120);
            this.tbxPasswordCorreo.Name = "tbxPasswordCorreo";
            this.tbxPasswordCorreo.Size = new System.Drawing.Size(84, 20);
            this.tbxPasswordCorreo.TabIndex = 38;
            // 
            // tbxServicioSMTP
            // 
            this.tbxServicioSMTP.Location = new System.Drawing.Point(125, 120);
            this.tbxServicioSMTP.Name = "tbxServicioSMTP";
            this.tbxServicioSMTP.Size = new System.Drawing.Size(84, 20);
            this.tbxServicioSMTP.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(122, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Servicio SMTP";
            // 
            // tbxPuertoSMTP
            // 
            this.tbxPuertoSMTP.Location = new System.Drawing.Point(125, 176);
            this.tbxPuertoSMTP.Name = "tbxPuertoSMTP";
            this.tbxPuertoSMTP.Size = new System.Drawing.Size(84, 20);
            this.tbxPuertoSMTP.TabIndex = 34;
            // 
            // tbxCorreoEnvia
            // 
            this.tbxCorreoEnvia.Location = new System.Drawing.Point(12, 120);
            this.tbxCorreoEnvia.Name = "tbxCorreoEnvia";
            this.tbxCorreoEnvia.Size = new System.Drawing.Size(84, 20);
            this.tbxCorreoEnvia.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Puerto SMTP";
            // 
            // tbxSSL
            // 
            this.tbxSSL.Location = new System.Drawing.Point(12, 176);
            this.tbxSSL.Name = "tbxSSL";
            this.tbxSSL.Size = new System.Drawing.Size(84, 20);
            this.tbxSSL.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SSL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correo que Envia";
            // 
            // FrmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 273);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMail";
            this.Text = "FrmMail";
            this.Load += new System.EventHandler(this.FrmMail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCierreMail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxSSL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxPasswordCorreo;
        private System.Windows.Forms.TextBox tbxServicioSMTP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxPuertoSMTP;
        private System.Windows.Forms.TextBox tbxCorreoEnvia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxUsaCierreMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxEnviaMaila;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}