﻿namespace ConfiguradorPDV
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
            this.btnElimSucInactivas = new System.Windows.Forms.Button();
            this.btnCorrelatividad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLimpiarPDV
            // 
            this.btnLimpiarPDV.Location = new System.Drawing.Point(12, 12);
            this.btnLimpiarPDV.Name = "btnLimpiarPDV";
            this.btnLimpiarPDV.Size = new System.Drawing.Size(75, 48);
            this.btnLimpiarPDV.TabIndex = 0;
            this.btnLimpiarPDV.Text = "Limpiar PDV";
            this.btnLimpiarPDV.UseVisualStyleBackColor = true;
            this.btnLimpiarPDV.Click += new System.EventHandler(this.btnLimpiarPDV_Click);
            // 
            // btnElimSucInactivas
            // 
            this.btnElimSucInactivas.Location = new System.Drawing.Point(93, 12);
            this.btnElimSucInactivas.Name = "btnElimSucInactivas";
            this.btnElimSucInactivas.Size = new System.Drawing.Size(117, 48);
            this.btnElimSucInactivas.TabIndex = 2;
            this.btnElimSucInactivas.Text = "Eliminar Sucursales Inactivas";
            this.btnElimSucInactivas.UseVisualStyleBackColor = true;
            this.btnElimSucInactivas.Click += new System.EventHandler(this.btnElimSucInactivas_Click);
            // 
            // btnCorrelatividad
            // 
            this.btnCorrelatividad.Location = new System.Drawing.Point(93, 66);
            this.btnCorrelatividad.Name = "btnCorrelatividad";
            this.btnCorrelatividad.Size = new System.Drawing.Size(117, 48);
            this.btnCorrelatividad.TabIndex = 3;
            this.btnCorrelatividad.Text = "Corregir correlatividad";
            this.btnCorrelatividad.UseVisualStyleBackColor = true;
            this.btnCorrelatividad.Click += new System.EventHandler(this.btnCorrelatividad_Click);
            // 
            // FrmSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 122);
            this.Controls.Add(this.btnCorrelatividad);
            this.Controls.Add(this.btnElimSucInactivas);
            this.Controls.Add(this.btnLimpiarPDV);
            this.Name = "FrmSQL";
            this.Text = "FrmSQL";
            this.Load += new System.EventHandler(this.FrmSQL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarPDV;
        private System.Windows.Forms.Button btnElimSucInactivas;
        private System.Windows.Forms.Button btnCorrelatividad;
    }
}