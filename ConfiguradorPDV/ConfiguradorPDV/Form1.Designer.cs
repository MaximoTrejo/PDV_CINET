namespace ConfiguradorPDV
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.tbxClave = new System.Windows.Forms.TextBox();
            this.btnTraer = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.cbxBases = new System.Windows.Forms.ComboBox();
            this.tbxPuerto = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbxClaveEquipo = new System.Windows.Forms.CheckBox();
            this.tbxClaveCaja = new System.Windows.Forms.TextBox();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.btnVerPDV = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(13, 14);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(127, 20);
            this.tbxIP.TabIndex = 0;
            this.tbxIP.Text = "26.51.65.156";
            // 
            // tbxClave
            // 
            this.tbxClave.Location = new System.Drawing.Point(12, 43);
            this.tbxClave.Name = "tbxClave";
            this.tbxClave.Size = new System.Drawing.Size(128, 20);
            this.tbxClave.TabIndex = 1;
            this.tbxClave.Text = "cinettorcel";
            this.tbxClave.UseSystemPasswordChar = true;
            // 
            // btnTraer
            // 
            this.btnTraer.Location = new System.Drawing.Point(166, 44);
            this.btnTraer.Name = "btnTraer";
            this.btnTraer.Size = new System.Drawing.Size(75, 23);
            this.btnTraer.TabIndex = 3;
            this.btnTraer.Text = "Traer";
            this.btnTraer.UseVisualStyleBackColor = true;
            this.btnTraer.Click += new System.EventHandler(this.btnTraer_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(166, 73);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // cbxBases
            // 
            this.cbxBases.FormattingEnabled = true;
            this.cbxBases.Location = new System.Drawing.Point(12, 75);
            this.cbxBases.Name = "cbxBases";
            this.cbxBases.Size = new System.Drawing.Size(127, 21);
            this.cbxBases.TabIndex = 5;
            // 
            // tbxPuerto
            // 
            this.tbxPuerto.Location = new System.Drawing.Point(166, 14);
            this.tbxPuerto.Name = "tbxPuerto";
            this.tbxPuerto.Size = new System.Drawing.Size(75, 20);
            this.tbxPuerto.TabIndex = 6;
            this.tbxPuerto.Text = "1434";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 313);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbxClaveEquipo);
            this.tabPage1.Controls.Add(this.tbxClaveCaja);
            this.tabPage1.Controls.Add(this.dgvEquipos);
            this.tabPage1.Controls.Add(this.btnVerPDV);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(430, 287);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "PDV";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbxClaveEquipo
            // 
            this.cbxClaveEquipo.AutoSize = true;
            this.cbxClaveEquipo.Location = new System.Drawing.Point(331, 238);
            this.cbxClaveEquipo.Name = "cbxClaveEquipo";
            this.cbxClaveEquipo.Size = new System.Drawing.Size(15, 14);
            this.cbxClaveEquipo.TabIndex = 54;
            this.cbxClaveEquipo.UseVisualStyleBackColor = true;
            this.cbxClaveEquipo.CheckedChanged += new System.EventHandler(this.cbxClaveEquipo_CheckedChanged);
            // 
            // tbxClaveCaja
            // 
            this.tbxClaveCaja.Location = new System.Drawing.Point(331, 258);
            this.tbxClaveCaja.Name = "tbxClaveCaja";
            this.tbxClaveCaja.Size = new System.Drawing.Size(96, 20);
            this.tbxClaveCaja.TabIndex = 10;
            this.tbxClaveCaja.UseSystemPasswordChar = true;
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.Location = new System.Drawing.Point(3, 3);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvEquipos.Size = new System.Drawing.Size(325, 276);
            this.dgvEquipos.StandardTab = true;
            this.dgvEquipos.TabIndex = 6;
            this.dgvEquipos.TabStop = false;
            // 
            // btnVerPDV
            // 
            this.btnVerPDV.Location = new System.Drawing.Point(331, 176);
            this.btnVerPDV.Name = "btnVerPDV";
            this.btnVerPDV.Size = new System.Drawing.Size(96, 54);
            this.btnVerPDV.TabIndex = 1;
            this.btnVerPDV.Text = "VER PDV";
            this.btnVerPDV.UseVisualStyleBackColor = true;
            this.btnVerPDV.Click += new System.EventHandler(this.btnVerPDV_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 435);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbxPuerto);
            this.Controls.Add(this.cbxBases);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnTraer);
            this.Controls.Add(this.tbxClave);
            this.Controls.Add(this.tbxIP);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxIP;
        private System.Windows.Forms.TextBox tbxClave;
        private System.Windows.Forms.Button btnTraer;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.ComboBox cbxBases;
        private System.Windows.Forms.TextBox tbxPuerto;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnVerPDV;
        private System.Windows.Forms.DataGridView dgvEquipos;
        private System.Windows.Forms.CheckBox cbxClaveEquipo;
        private System.Windows.Forms.TextBox tbxClaveCaja;
    }
}

