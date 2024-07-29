namespace ConfiguradorPDV
{
    partial class FrmPDV
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
            this.tbxCuit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxCuit
            // 
            this.tbxCuit.Location = new System.Drawing.Point(12, 29);
            this.tbxCuit.Name = "tbxCuit";
            this.tbxCuit.Size = new System.Drawing.Size(100, 20);
            this.tbxCuit.TabIndex = 0;
            // 
            // FrmPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxCuit);
            this.Name = "FrmPDV";
            this.Text = "FrmPDV";
            this.Load += new System.EventHandler(this.FrmPDV_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxCuit;
    }
}