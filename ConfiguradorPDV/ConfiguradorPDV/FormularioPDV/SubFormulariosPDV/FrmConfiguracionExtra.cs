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
        comprobantes_n_controller comprobantes_N_;
        categdgi_controller categdgi_;
        cbtexcatdgi_controller cbtexcatdgi_;
        cbte_ingresos_controller cbte_ingresos_;
        public FrmConfiguracionExtra(Factory factory, LinkedServer linkedServer_)
        {
            InitializeComponent();
            this.factory = factory;
            LinkedServer_ = linkedServer_;
            cbte_ingresos_= new cbte_ingresos_controller(factory, linkedServer_);
            parametros_ = new parametros_controller(factory, linkedServer_);
            comprobantes_E_ = new comprobantes_e_controller(factory, linkedServer_);
            categdgi_ = new categdgi_controller(factory, linkedServer_);
            comprobantes_D_ = new comprobantes_d_controller(factory, linkedServer_);
            comprobantes_N_ = new comprobantes_n_controller(factory, linkedServer_);
            cbtexcatdgi_ = new cbtexcatdgi_controller(factory, linkedServer_);
        }

        private void FrmConfiguracionExtra_Load(object sender, EventArgs e)
        {
            List<string> opcionesSiNo = new List<string> { "N", "S" };
            cbxUsaTurno.Items.AddRange(opcionesSiNo.ToArray());
            cbxUsaTComanda.Items.AddRange(opcionesSiNo.ToArray());
            cbxMonotributista.Items.AddRange(opcionesSiNo.ToArray());
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


        private void btnEsMonotributista_Click(object sender, EventArgs e)
        {
            string EsMonotributista = cbxMonotributista.Text;

            if (EsMonotributista =="S")
            {
                comprobantes_E_.modificarCodigoComprobantes("M");
                categdgi_.modificarComprobanteCategdgi("M");
                parametros_.modificarParametros("IVA_MONO", "", EsMonotributista);

                cbtexcatdgi_.insertarCbtexcatdgi("C", "vtas", "FAB");
                cbtexcatdgi_.insertarCbtexcatdgi("E", "vtas", "FAB");
                cbtexcatdgi_.insertarCbtexcatdgi("I", "vtas", "FAB");
                cbtexcatdgi_.insertarCbtexcatdgi("M", "vtas", "FAB");
                cbtexcatdgi_.insertarCbtexcatdgi("N", "vtas", "FAB");
                cbtexcatdgi_.insertarCbtexcatdgi("T", "vtas", "FAB");
                cbtexcatdgi_.insertarCbtexcatdgi("X", "vtas", "FAB");
                comprobantes_D_.eliminarComprobante("FAB", "VTAS", "IVA1");
                comprobantes_D_.modificarFormulaComprobante("FAB", "VTAS", "NETO1", "NETO1=SUBTOTAL");
            }
            else
            {
                comprobantes_E_.modificarCodigoComprobantes("FE");
                categdgi_.modificarComprobanteCategdgi("FE");
                parametros_.modificarParametros("IVA_MONO", "", EsMonotributista);
                comprobantes_D_.insertarComprobante("FAB", "VTAS", "IVA1", "IVA1=ROUND((SUBTOTAL-DTO1)*17.3553719008264/100,4)","8");
                comprobantes_D_.modificarFormulaComprobante("FAB", "VTAS", "NETO1", "NETO1=ROUND((SUBTOTAL-EXENTO-DTO1-DTO2-DTO3)/1.21,4)");
            }
            

        }

        private void btnUsaFacturaM_Click(object sender, EventArgs e)
        {

            if (categdgi_.UsaFacturaAoM() == "FMA")
            {
                //desactiva factura M
                cbtexcatdgi_.insertarCbtexcatdgi("I", "VTAS", "FAA");
                cbtexcatdgi_.insertarCbtexcatdgi("M", "VTAS", "FAA");
                cbtexcatdgi_.insertarCbtexcatdgi("N", "VTAS", "FAA");
                categdgi_.modificarComprobanteFacturaA();
                MessageBox.Show("Se desactivo la factura M", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //se activa la factura M
                comprobantes_E_.insertarComprobantes("FMA", "VTAS", "FACTURA M", "051");
                comprobantes_N_.insertarComprobantes("FMA");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "DTO1", "DTO1=round(SUBTOTAL*PORCEDTO1/100,2)", "2");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "DTO1", "DTO1=round(SUBTOTAL*PORCEDTO1/100,2)", "2");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "DTO2", "DTO2=round((SUBTOTAL-DTO1) * PORCEDTO2/100,2)", "2");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "DTO3", "DTO3=round((SUBTOTAL-DTO1-DTO2) *PORCEDTO3/100,2)", "2");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "EXENTO", "EXENTO=SUBTOTAL-DTO1-DTO2-DTO3+AGENCIA", "4");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "IVA1", "IVA1=ROUND((SUBTOTAL-DTO1)*17.355/100,2)", "8");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "IVA2", "IVA2=round(NETO2*g_iva2/100,2)", "8");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "NETO1", "NETO1=round((SUBTOTAL-EXENTO-DTO1-DTO2-DTO3)/1.21,4)", "5");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "NETO2", "NETO2=round((SUBTOTAL-EXENTO-DTO1-DTO2-DTO3)/1.105,4)", "6");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "SUBTOTAL", "SUBTOTAL=round(CANT*PRECIO,2)", "1");
                comprobantes_D_.insertarComprobante("FMA", "VTAS", "TOTAL", "TOTAL=NETO1+IVA1+EXENTO+NETO2+IVA2+PERIB", "10");
                string pdv = parametros_.TraerValorParametro("VTAPUNTO");
                cbte_ingresos_.insertarComprobante("FMA", "FACTURA M", pdv);

                //
                cbtexcatdgi_.insertarCbtexcatdgi("I", "VTAS", "FMA");
                cbtexcatdgi_.insertarCbtexcatdgi("M", "VTAS", "FMA");


                categdgi_.modificarComprobanteFacturaM();
                MessageBox.Show("Se activo la factura M", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
