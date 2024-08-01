using ConfiguradorPDV.Controllers;
using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfiguradorPDV
{
    public partial class FrmPDV : Form
    {
        Factory factory;
        string equipo;
        public FrmPDV(Factory factory , string equipo)
        {
            this.factory = factory;
            this.equipo = equipo;
            InitializeComponent();
        }

        private void FrmPDV_Load(object sender, EventArgs e)
        {
            linkedServer_controller linkedServer = new linkedServer_controller(factory);

            tbxCuit.Text = linkedServer.TraerDatoParametroLinked("VTAPUNTO",equipo);
            
        }
    }
}
