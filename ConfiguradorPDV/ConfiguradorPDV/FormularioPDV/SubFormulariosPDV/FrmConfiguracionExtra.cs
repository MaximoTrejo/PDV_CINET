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
        comprobantes_e_controller comprobantes_E_;
        comprobantes_d_controller comprobantes_D_;
        categdgi_controller categdgi_;
        public FrmConfiguracionExtra(Factory factory, LinkedServer linkedServer_)
        {
            InitializeComponent();
            this.factory = factory;
            LinkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
            comprobantes_E_ = new comprobantes_e_controller(factory, linkedServer_);
            categdgi_ = new categdgi_controller(factory, linkedServer_);
            comprobantes_D_ = new comprobantes_d_controller(factory, linkedServer_);
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

        private void btnUsaFacturaM_Click(object sender, EventArgs e)
        {

        }

        private void btnEsMonotributista_Click(object sender, EventArgs e)
        {
            string EsMonotributista = cbxMonotributista.Text;

            if (EsMonotributista =="S")
            {
                comprobantes_E_.modificarCodigoComprobantes("M");
                categdgi_.modificarComprobanteCategdgi("M");
                parametros_.modificarParametros("IVA_MONO", "", EsMonotributista);
                comprobantes_D_.eliminarComprobante("FAB", "VTAS", "IVA1");
                comprobantes_D_.modificarFormulaComprobante("FAB", "VTAS", "NETO1", "NETO1=SUBTOTAL");
            }
            else
            {
                comprobantes_E_.modificarCodigoComprobantes("FE");
                categdgi_.modificarComprobanteCategdgi("FE");
                parametros_.modificarParametros("IVA_MONO", "", EsMonotributista);
                comprobantes_D_.insertarComprobante("FAB", "VTAS", "IVA1", "IVA1=ROUND((SUBTOTAL-DTO1)*17.3553719008264/100,4)");
                comprobantes_D_.modificarFormulaComprobante("FAB", "VTAS", "NETO1", "NETO1=ROUND((SUBTOTAL-EXENTO-DTO1-DTO2-DTO3)/1.21,4)");
            }
            

        }
    }
}
