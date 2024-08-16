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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.tbxIP = new System.Windows.Forms.TextBox();
            this.tbxClave = new System.Windows.Forms.TextBox();
            this.btnTraer = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.cbxBases = new System.Windows.Forms.ComboBox();
            this.tbxPuerto = new System.Windows.Forms.TextBox();
            this.tclEquipos = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbxPuertoCaja = new System.Windows.Forms.TextBox();
            this.cbxClaveEquipo = new System.Windows.Forms.CheckBox();
            this.tbxClaveCaja = new System.Windows.Forms.TextBox();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.btnVerPDV = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnVerBackoffice = new System.Windows.Forms.Button();
            this.cbxUsaLinkedServer = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tclEquipos.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(10, 25);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(127, 20);
            this.tbxIP.TabIndex = 0;
            // 
            // tbxClave
            // 
            this.tbxClave.Location = new System.Drawing.Point(11, 65);
            this.tbxClave.Name = "tbxClave";
            this.tbxClave.Size = new System.Drawing.Size(128, 20);
            this.tbxClave.TabIndex = 1;
            this.tbxClave.UseSystemPasswordChar = true;
            // 
            // btnTraer
            // 
            this.btnTraer.Location = new System.Drawing.Point(154, 65);
            this.btnTraer.Name = "btnTraer";
            this.btnTraer.Size = new System.Drawing.Size(75, 23);
            this.btnTraer.TabIndex = 3;
            this.btnTraer.Text = "Traer";
            this.btnTraer.UseVisualStyleBackColor = true;
            this.btnTraer.Click += new System.EventHandler(this.btnTraer_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(154, 102);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 4;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // cbxBases
            // 
            this.cbxBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBases.FormattingEnabled = true;
            this.cbxBases.Location = new System.Drawing.Point(11, 104);
            this.cbxBases.Name = "cbxBases";
            this.cbxBases.Size = new System.Drawing.Size(127, 21);
            this.cbxBases.TabIndex = 5;
            // 
            // tbxPuerto
            // 
            this.tbxPuerto.Location = new System.Drawing.Point(154, 25);
            this.tbxPuerto.Name = "tbxPuerto";
            this.tbxPuerto.Size = new System.Drawing.Size(75, 20);
            this.tbxPuerto.TabIndex = 6;
            this.tbxPuerto.Text = "1433";
            // 
            // tclEquipos
            // 
            this.tclEquipos.Controls.Add(this.tabPage1);
            this.tclEquipos.Controls.Add(this.tabPage2);
            this.tclEquipos.Location = new System.Drawing.Point(12, 151);
            this.tclEquipos.Name = "tclEquipos";
            this.tclEquipos.SelectedIndex = 0;
            this.tclEquipos.Size = new System.Drawing.Size(438, 313);
            this.tclEquipos.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbxPuertoCaja);
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
            // tbxPuertoCaja
            // 
            this.tbxPuertoCaja.Enabled = false;
            this.tbxPuertoCaja.Location = new System.Drawing.Point(355, 235);
            this.tbxPuertoCaja.Name = "tbxPuertoCaja";
            this.tbxPuertoCaja.Size = new System.Drawing.Size(72, 20);
            this.tbxPuertoCaja.TabIndex = 55;
            this.tbxPuertoCaja.Text = "1433";
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
            this.tbxClaveCaja.Enabled = false;
            this.tbxClaveCaja.Location = new System.Drawing.Point(331, 258);
            this.tbxClaveCaja.Name = "tbxClaveCaja";
            this.tbxClaveCaja.Size = new System.Drawing.Size(96, 20);
            this.tbxClaveCaja.TabIndex = 10;
            this.tbxClaveCaja.Text = "cinettorcel";
            this.tbxClaveCaja.UseSystemPasswordChar = true;
            // 
            // dgvEquipos
            // 
            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipos.Location = new System.Drawing.Point(3, 3);
            this.dgvEquipos.Name = "dgvEquipos";
            this.dgvEquipos.RowHeadersVisible = false;
            this.dgvEquipos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnVerBackoffice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(430, 287);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "BACKOFFICE";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnVerBackoffice
            // 
            this.btnVerBackoffice.Location = new System.Drawing.Point(331, 230);
            this.btnVerBackoffice.Name = "btnVerBackoffice";
            this.btnVerBackoffice.Size = new System.Drawing.Size(96, 54);
            this.btnVerBackoffice.TabIndex = 2;
            this.btnVerBackoffice.Text = "VER BASE";
            this.btnVerBackoffice.UseVisualStyleBackColor = true;
            this.btnVerBackoffice.Click += new System.EventHandler(this.btnVerBackoffice_Click);
            // 
            // cbxUsaLinkedServer
            // 
            this.cbxUsaLinkedServer.AutoSize = true;
            this.cbxUsaLinkedServer.Checked = true;
            this.cbxUsaLinkedServer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxUsaLinkedServer.Location = new System.Drawing.Point(12, 131);
            this.cbxUsaLinkedServer.Name = "cbxUsaLinkedServer";
            this.cbxUsaLinkedServer.Size = new System.Drawing.Size(15, 14);
            this.cbxUsaLinkedServer.TabIndex = 56;
            this.cbxUsaLinkedServer.UseVisualStyleBackColor = true;
            this.cbxUsaLinkedServer.CheckedChanged += new System.EventHandler(this.cbxUsaLinkedServer_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Direccion IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Base de datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 60;
            this.label4.Text = "Conectarse Localmente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(151, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Puerto";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 469);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxUsaLinkedServer);
            this.Controls.Add(this.tclEquipos);
            this.Controls.Add(this.tbxPuerto);
            this.Controls.Add(this.cbxBases);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.btnTraer);
            this.Controls.Add(this.tbxClave);
            this.Controls.Add(this.tbxIP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.Text = "ConfiguradorPDV";
            this.tclEquipos.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.tabPage2.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tclEquipos;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnVerPDV;
        private System.Windows.Forms.DataGridView dgvEquipos;
        private System.Windows.Forms.CheckBox cbxClaveEquipo;
        private System.Windows.Forms.TextBox tbxClaveCaja;
        private System.Windows.Forms.TextBox tbxPuertoCaja;
        private System.Windows.Forms.CheckBox cbxUsaLinkedServer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnVerBackoffice;
    }
}

