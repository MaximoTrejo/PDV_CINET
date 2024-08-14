namespace ConfiguradorPDV.FormularioBackoffice.SubFormularios
{
    partial class FrmCompararZyV
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
            this.dbvCompararVentasZ = new System.Windows.Forms.DataGridView();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxPDVs = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dbvCompararVentasZ)).BeginInit();
            this.SuspendLayout();
            // 
            // dbvCompararVentasZ
            // 
            this.dbvCompararVentasZ.AllowUserToAddRows = false;
            this.dbvCompararVentasZ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dbvCompararVentasZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dbvCompararVentasZ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbvCompararVentasZ.Location = new System.Drawing.Point(12, 73);
            this.dbvCompararVentasZ.Name = "dbvCompararVentasZ";
            this.dbvCompararVentasZ.RowHeadersVisible = false;
            this.dbvCompararVentasZ.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dbvCompararVentasZ.Size = new System.Drawing.Size(702, 375);
            this.dbvCompararVentasZ.TabIndex = 0;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(12, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(95, 20);
            this.dtpDesde.TabIndex = 1;
            this.dtpDesde.Value = new System.DateTime(2024, 8, 13, 19, 9, 51, 0);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(12, 38);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(95, 20);
            this.dtpHasta.TabIndex = 2;
            this.dtpHasta.Value = new System.DateTime(2024, 8, 13, 19, 9, 51, 0);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(639, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 55);
            this.btnBuscar.TabIndex = 17;
            this.btnBuscar.Text = "BUSCAR";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Sucursal";
            // 
            // cbxPDVs
            // 
            this.cbxPDVs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPDVs.FormattingEnabled = true;
            this.cbxPDVs.Location = new System.Drawing.Point(157, 30);
            this.cbxPDVs.Name = "cbxPDVs";
            this.cbxPDVs.Size = new System.Drawing.Size(121, 21);
            this.cbxPDVs.TabIndex = 18;
            // 
            // FrmCompararZyV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 463);
            this.Controls.Add(this.cbxPDVs);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.dbvCompararVentasZ);
            this.Name = "FrmCompararZyV";
            this.Text = "FrmCompararZyV";
            this.Load += new System.EventHandler(this.FrmCompararZyV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbvCompararVentasZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbvCompararVentasZ;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPDVs;
    }
}