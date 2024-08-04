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
    public partial class FrmFactura : Form
    {
        Factory factory;
        LinkedServer LinkedServer_;
        parametros_controller parametros_;
        public FrmFactura(Factory factory ,LinkedServer linkedServer_)
        {
            InitializeComponent();
            this.factory = factory;  
            LinkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            tbxRazonSocial.Text = parametros_.TraerValorParametro("COMALIN1");
            tbxCuitEmpresa.Text = parametros_.TraerValorParametro("COMALIN4");
            tbxDireccion.Text = parametros_.TraerValorParametro("COMALIN2");
            tbxTelefono.Text = parametros_.TraerValorParametro("COMALIN5");
            tbxLocalidad.Text = parametros_.TraerValorParametro("COMALIN3");
        }
    }
}
