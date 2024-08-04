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
        parametros_controller parametros_;
        LinkedServer linkedServer_;
        public FrmPDV(Factory factory,LinkedServer linked)
        {
            this.factory = factory;
            linkedServer_ = linked;
            parametros_ = new parametros_controller(factory ,linked);

            InitializeComponent();
        }

        private void FrmPDV_Load(object sender, EventArgs e)
        {

            tbxCuit.Text = parametros_.TraerValorParametro("CUIT");
            tbxPDV.Text = parametros_.TraerValorParametro("VTAPUNTO");
            tbxPDVManual.Text = parametros_.TraerValorParametro("PTOVTAMAN");
            tbxNumCaj.Text = parametros_.TraerValorParametro("NUMCAJA");
            cbxTipoFac.Text  = parametros_.TraerValorParametro("MODOFE") == "S" ? "FE" : "CF";
            tbxCodLocal.Text = parametros_.TraerValorParametro("NOMLOCAL");
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            FrmMP frmMP = new FrmMP(factory,linkedServer_);
            frmMP.Show();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail(factory,linkedServer_) ;
            frmMail.Show();
        }

        private void btnCF_Click(object sender, EventArgs e)
        {
            FrmCF frmCF = new FrmCF(factory,linkedServer_);
            frmCF.Show();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura(factory,linkedServer_);
            frmFactura.Show();
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            FrmSQL frmSQL = new FrmSQL(factory,linkedServer_);
            frmSQL.Show();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            FrmConfiguracionExtra frmConfiguracionExtra = new FrmConfiguracionExtra(factory,linkedServer_);
            frmConfiguracionExtra.Show();
        }
    }
}
