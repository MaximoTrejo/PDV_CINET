namespace ConfiguradorPDV
{
    partial class FrmSQL
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
            this.btnLimpiarPDV = new System.Windows.Forms.Button();
            this.btnRegenerarCierre = new System.Windows.Forms.Button();
            this.btnElimSucInactivas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLimpiarPDV
            // 
            this.btnLimpiarPDV.Location = new System.Drawing.Point(12, 12);
            this.btnLimpiarPDV.Name = "btnLimpiarPDV";
            this.btnLimpiarPDV.Size = new System.Drawing.Size(75, 37);
            this.btnLimpiarPDV.TabIndex = 0;
            this.btnLimpiarPDV.Text = "Limpiar PDV";
            this.btnLimpiarPDV.UseVisualStyleBackColor = true;
            this.btnLimpiarPDV.Click += new System.EventHandler(this.btnLimpiarPDV_Click);
            // 
            // btnRegenerarCierre
            // 
            this.btnRegenerarCierre.Location = new System.Drawing.Point(110, 12);
            this.btnRegenerarCierre.Name = "btnRegenerarCierre";
            this.btnRegenerarCierre.Size = new System.Drawing.Size(96, 37);
            this.btnRegenerarCierre.TabIndex = 1;
            this.btnRegenerarCierre.Text = "Regenerar Cierre";
            this.btnRegenerarCierre.UseVisualStyleBackColor = true;
            this.btnRegenerarCierre.Click += new System.EventHandler(this.btnRegenerarCierre_Click);
            // 
            // btnElimSucInactivas
            // 
            this.btnElimSucInactivas.Location = new System.Drawing.Point(12, 67);
            this.btnElimSucInactivas.Name = "btnElimSucInactivas";
            this.btnElimSucInactivas.Size = new System.Drawing.Size(75, 48);
            this.btnElimSucInactivas.TabIndex = 2;
            this.btnElimSucInactivas.Text = "Eliminar Sucursales Inactivas";
            this.btnElimSucInactivas.UseVisualStyleBackColor = true;
            this.btnElimSucInactivas.Click += new System.EventHandler(this.btnElimSucInactivas_Click);
            // 
            // FrmSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 126);
            this.Controls.Add(this.btnElimSucInactivas);
            this.Controls.Add(this.btnRegenerarCierre);
            this.Controls.Add(this.btnLimpiarPDV);
            this.Name = "FrmSQL";
            this.Text = "FrmSQL";
            this.Load += new System.EventHandler(this.FrmSQL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarPDV;
        private System.Windows.Forms.Button btnRegenerarCierre;
        private System.Windows.Forms.Button btnElimSucInactivas;
    }
}