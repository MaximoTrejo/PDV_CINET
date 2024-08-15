namespace ConfiguradorPDV.FormularioBackoffice.SubFormularios
{
    partial class FrmAuditarZ
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
            this.cbxPDVs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dbvAuditarZ = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dbvAuditarZ)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxPDVs
            // 
            this.cbxPDVs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPDVs.FormattingEnabled = true;
            this.cbxPDVs.Location = new System.Drawing.Point(157, 32);
            this.cbxPDVs.Name = "cbxPDVs";
            this.cbxPDVs.Size = new System.Drawing.Size(121, 21);
            this.cbxPDVs.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Sucursal";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(12, 40);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpHasta.TabIndex = 21;
            this.dtpHasta.Value = new System.DateTime(2024, 8, 13, 19, 9, 51, 0);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(12, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpDesde.TabIndex = 20;
            this.dtpDesde.Value = new System.DateTime(2024, 8, 13, 19, 9, 51, 0);
            // 
            // dbvAuditarZ
            // 
            this.dbvAuditarZ.AllowUserToAddRows = false;
            this.dbvAuditarZ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbvAuditarZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dbvAuditarZ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbvAuditarZ.Location = new System.Drawing.Point(12, 75);
            this.dbvAuditarZ.Name = "dbvAuditarZ";
            this.dbvAuditarZ.RowHeadersVisible = false;
            this.dbvAuditarZ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dbvAuditarZ.Size = new System.Drawing.Size(506, 375);
            this.dbvAuditarZ.TabIndex = 19;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(443, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 55);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // AuditarZ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 466);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cbxPDVs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dbvAuditarZ);
            this.Name = "AuditarZ";
            this.Text = "AuditarZ";
            this.Load += new System.EventHandler(this.AuditarZ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbvAuditarZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxPDVs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DataGridView dbvAuditarZ;
        private System.Windows.Forms.Button btnBuscar;
    }
}