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
            List<string> opcionesSiNo = new List<string> { "N", "S" };
            cbxUsaTurno.Items.AddRange(opcionesSiNo.ToArray());
            cbxUsaTComanda.Items.AddRange(opcionesSiNo.ToArray());
            tbxNombreEmpresa.Text = parametros_.TraerValorParametro("EMPRESA2");
            tbxNombreImpresora.Text = parametros_.TraerValorParametro("PRNCOMANU");
            cbxUsaTurno.Text = parametros_.TraerValorParametro("PRNTURNO");
            cbxUsaTComanda.Text = parametros_.TraerValorParametro("USACOMAPRN");
            cbxMonotributista.Text = parametros_.TraerValorParametro("IVA_MONO");
            cbxUsaFacturaM.Text = parametros_.TraerValorParametro("IVA_MONO");
            //cambiar titulo formulario
            this.Text = "FrmConfiguracionesExtra " + LinkedServer_._equipo + LinkedServer_._puerto;
        }

        private void btnNomEmpresa_Click(object sender, EventArgs e)
        {
            string nomEmpre = tbxNombreEmpresa.Text;
            parametros_.modificarParametros("EMPRESA2","",nomEmpre);
        }

        private void btnNomImpresora_Click(object sender, EventArgs e)
        {
            string nomImpresora = tbxNombreImpresora.Text;
            parametros_.modificarParametros("COCINA1","",nomImpresora);
            parametros_.modificarParametros("PRNCOMANU","",nomImpresora);
            parametros_.modificarParametros("PRNTUR","",nomImpresora);
        }

        private void btnUsaTurno_Click(object sender, EventArgs e)
        {
            string usaTurno = cbxUsaTurno.Text;

            if (usaTurno =="S")
            {
                parametros_.modificarParametros("PRNTURNO", "", usaTurno);
            }
            else
            {
                parametros_.modificarParametros("PRNTURNO", "", usaTurno);
            }
        }

        private void brnUsaTComanda_Click(object sender, EventArgs e)
        {
            string usaTComanda=  cbxUsaTComanda.Text;

            if (usaTComanda =="S")
            {
                parametros_.modificarParametros("COMAPRNALL","",usaTComanda);
                parametros_.modificarParametros("USACOMAPRN","",usaTComanda);
                parametros_.modificarParametros("COMA2IMP", "", usaTComanda);
            }
        }
    }
}
