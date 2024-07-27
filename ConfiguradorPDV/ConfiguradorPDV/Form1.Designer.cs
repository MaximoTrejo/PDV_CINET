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
            this.btnTraerEquipos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbxLinkedserver = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.tbxClaveLinked = new System.Windows.Forms.TextBox();
            this.cbxCajasLinked = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxIP
            // 
            this.tbxIP.Location = new System.Drawing.Point(13, 14);
            this.tbxIP.Name = "tbxIP";
            this.tbxIP.Size = new System.Drawing.Size(127, 20);
            this.tbxIP.TabIndex = 0;
            // 
            // tbxClave
            // 
            this.tbxClave.Location = new System.Drawing.Point(12, 43);
            this.tbxClave.Name = "tbxClave";
            this.tbxClave.Size = new System.Drawing.Size(128, 20);
            this.tbxClave.TabIndex = 1;
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
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 308);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.btnTraerEquipos);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(430, 282);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "PDV";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTraerEquipos
            // 
            this.btnTraerEquipos.Location = new System.Drawing.Point(265, 23);
            this.btnTraerEquipos.Name = "btnTraerEquipos";
            this.btnTraerEquipos.Size = new System.Drawing.Size(117, 31);
            this.btnTraerEquipos.TabIndex = 2;
            this.btnTraerEquipos.Text = "Traer Equipos";
            this.btnTraerEquipos.UseVisualStyleBackColor = true;
            this.btnTraerEquipos.Click += new System.EventHandler(this.btnTraerEquipos_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "VER PDV";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cbxLinkedserver
            // 
            this.cbxLinkedserver.AutoSize = true;
            this.cbxLinkedserver.Location = new System.Drawing.Point(133, 22);
            this.cbxLinkedserver.Name = "cbxLinkedserver";
            this.cbxLinkedserver.Size = new System.Drawing.Size(15, 14);
            this.cbxLinkedserver.TabIndex = 8;
            this.cbxLinkedserver.UseVisualStyleBackColor = true;
            this.cbxLinkedserver.CheckedChanged += new System.EventHandler(this.cbxLinkedserver_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.cbxLinkedserver);
            this.groupBox5.Controls.Add(this.tbxClaveLinked);
            this.groupBox5.Controls.Add(this.cbxCajasLinked);
            this.groupBox5.Location = new System.Drawing.Point(275, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(175, 84);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "LINKEDSERVER";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(111, 56);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(58, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Conectar";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // tbxClaveLinked
            // 
            this.tbxClaveLinked.Location = new System.Drawing.Point(6, 58);
            this.tbxClaveLinked.Name = "tbxClaveLinked";
            this.tbxClaveLinked.Size = new System.Drawing.Size(90, 20);
            this.tbxClaveLinked.TabIndex = 53;
            // 
            // cbxCajasLinked
            // 
            this.cbxCajasLinked.FormattingEnabled = true;
            this.cbxCajasLinked.Location = new System.Drawing.Point(5, 19);
            this.cbxCajasLinked.Name = "cbxCajasLinked";
            this.cbxCajasLinked.Size = new System.Drawing.Size(90, 21);
            this.cbxCajasLinked.TabIndex = 53;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 436);
            this.Controls.Add(this.groupBox5);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.CheckBox cbxLinkedserver;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.TextBox tbxClaveLinked;
        private System.Windows.Forms.ComboBox cbxCajasLinked;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTraerEquipos;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

