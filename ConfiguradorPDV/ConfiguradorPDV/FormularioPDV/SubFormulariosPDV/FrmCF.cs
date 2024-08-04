using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfiguradorPDV.Controllers;
using ConfiguradorPDV.DB;

namespace ConfiguradorPDV
{
    public partial class FrmCF : Form
    {
        Factory Factory;
        LinkedServer LinkedServer_;
        parametros_controller parametros_;
        public FrmCF(Factory factory, LinkedServer linkedServer_)
        {
            this.Factory = factory;
            InitializeComponent();
            LinkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
        }

        private void FrmCF_Load(object sender, EventArgs e)
        {
            tbxIpHasar.Text = parametros_.TraerValorParametro("HASARIP");
            cbxUsaHasar.Text = parametros_.TraerValorParametro("CFISCAL") == "HASAR" ? "S" : "N";
            tbxModeloCF.Text = parametros_.TraerValorParametro("CFMODELO");
            tbxPuertoF.Text = parametros_.TraerValorParametro("FISCALPORT");
        }
    }
}
