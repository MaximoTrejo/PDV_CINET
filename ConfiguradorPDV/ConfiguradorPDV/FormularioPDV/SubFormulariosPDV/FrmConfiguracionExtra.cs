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
using ConfiguradorPDV.Modelo;

namespace ConfiguradorPDV
{
    public partial class FrmConfiguracionExtra : Form
    {
        Factory factory;
        LinkedServer LinkedServer_;
        parametros_controller parametros_;
        public FrmConfiguracionExtra(Factory factory, LinkedServer linkedServer_)
        {
            InitializeComponent();
            this.factory = factory;
            LinkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
        }

        private void FrmConfiguracionExtra_Load(object sender, EventArgs e)
        {
            tbxNombreEmpresa.Text = parametros_.TraerValorParametro("EMPRESA2");
            tbxNombreImpresora.Text = parametros_.TraerValorParametro("PRNCOMANU");
            cbxUsaTurno.Text = parametros_.TraerValorParametro("PRNTURNO");
            cbxUsaTComanda.Text = parametros_.TraerValorParametro("USACOMAPRN");
            cbxMonotributista.Text = parametros_.TraerValorParametro("IVA_MONO");
            cbxUsaFacturaM.Text = parametros_.TraerValorParametro("IVA_MONO");
        }
    }
}
