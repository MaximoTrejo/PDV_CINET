namespace ConfiguradorPDV
{
    partial class FrmFactura
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
            this.Factura = new System.Windows.Forms.GroupBox();
            this.tbxDireccion = new System.Windows.Forms.TextBox();
            this.tbxLocalidad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCuitEmpresa = new System.Windows.Forms.TextBox();
            this.tbxRazonSocial = new System.Windows.Forms.TextBox();
            this.btnEFactura = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Factura.SuspendLayout();
            this.SuspendLayout();
            // 
            // Factura
            // 
            this.Factura.Controls.Add(this.tbxDireccion);
            this.Factura.Controls.Add(this.tbxLocalidad);
            this.Factura.Controls.Add(this.label8);
            this.Factura.Controls.Add(this.tbxCuitEmpresa);
            this.Factura.Controls.Add(this.tbxRazonSocial);
            this.Factura.Controls.Add(this.btnEFactura);
            this.Factura.Controls.Add(this.label4);
            this.Factura.Controls.Add(this.label3);
            this.Factura.Controls.Add(this.tbxTelefono);
            this.Factura.Controls.Add(this.label2);
            this.Factura.Controls.Add(this.label1);
            this.Factura.Location = new System.Drawing.Point(12, 12);
            this.Factura.Name = "Factura";
            this.Factura.Size = new System.Drawing.Size(324, 135);
            this.Factura.TabIndex = 2;
            this.Factura.TabStop = false;
            this.Factura.Text = "Factura";
            // 
            // tbxDireccion
            // 
            this.tbxDireccion.Location = new System.Drawing.Point(224, 49);
            this.tbxDireccion.Name = "tbxDireccion";
            this.tbxDireccion.Size = new System.Drawing.Size(84, 20);
            this.tbxDireccion.TabIndex = 38;
            // 
            // tbxLocalidad
            // 
            this.tbxLocalidad.Location = new System.Drawing.Point(116, 97);
            this.tbxLocalidad.Name = "tbxLocalidad";
            this.tbxLocalidad.Size = new System.Drawing.Size(84, 20);
            this.tbxLocalidad.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(113, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Localidad";
            // 
            // tbxCuitEmpresa
            // 
            this.tbxCuitEmpresa.Location = new System.Drawing.Point(116, 49);
            this.tbxCuitEmpresa.Name = "tbxCuitEmpresa";
            this.tbxCuitEmpresa.Size = new System.Drawing.Size(84, 20);
            this.tbxCuitEmpresa.TabIndex = 34;
            // 
            // tbxRazonSocial
            // 
            this.tbxRazonSocial.Location = new System.Drawing.Point(6, 49);
            this.tbxRazonSocial.Name = "tbxRazonSocial";
            this.tbxRazonSocial.Size = new System.Drawing.Size(84, 20);
            this.tbxRazonSocial.TabIndex = 33;
            // 
            // btnEFactura
            // 
            this.btnEFactura.Location = new System.Drawing.Point(224, 94);
            this.btnEFactura.Name = "btnEFactura";
            this.btnEFactura.Size = new System.Drawing.Size(75, 23);
            this.btnEFactura.TabIndex = 30;
            this.btnEFactura.Text = "Configurar";
            this.btnEFactura.UseVisualStyleBackColor = true;
            this.btnEFactura.Click += new System.EventHandler(this.btnEFactura_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Direccion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cuit Empresa";
            // 
            // tbxTelefono
            // 
            this.tbxTelefono.Location = new System.Drawing.Point(6, 97);
            this.tbxTelefono.Name = "tbxTelefono";
            this.tbxTelefono.Size = new System.Drawing.Size(84, 20);
            this.tbxTelefono.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Telefono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon Social";
            // 
            // FrmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 151);
            this.Controls.Add(this.Factura);
            this.Name = "FrmFactura";
            this.Text = "FrmFactura";
            this.Load += new System.EventHandler(this.FrmFactura_Load);
            this.Factura.ResumeLayout(false);
            this.Factura.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Factura;
        private System.Windows.Forms.TextBox tbxDireccion;
        private System.Windows.Forms.TextBox tbxLocalidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxCuitEmpresa;
        private System.Windows.Forms.TextBox tbxRazonSocial;
        private System.Windows.Forms.Button btnEFactura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}