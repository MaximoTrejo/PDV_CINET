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

            tbxCuit.Text = linkedServer.TraerDatoParametroLinked("CUIT", equipo);
            tbxPDV.Text = linkedServer.TraerDatoParametroLinked("VTAPUNTO", equipo);
            tbxPDVManual.Text = linkedServer.TraerDatoParametroLinked("PTOVTAMAN",equipo);
            tbxNumCaj.Text = linkedServer.TraerDatoParametroLinked("NUMCAJA", equipo);
            cbxTipoFac.Text  = linkedServer.TraerDatoParametroLinked("MODOFE", equipo) == "S" ? "FE" : "CF";
            tbxCodLocal.Text = linkedServer.TraerDatoParametroLinked("NOMLOCAL", equipo);
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            FrmMP frmMP = new FrmMP(factory,equipo);
            frmMP.Show();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail(factory, equipo);
            frmMail.Show();
        }

        private void btnCF_Click(object sender, EventArgs e)
        {
            FrmCF frmCF = new FrmCF(factory,equipo);
            frmCF.Show();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura(factory, equipo);
            frmFactura.Show();
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            FrmSQL frmSQL = new FrmSQL(factory, equipo);
            frmSQL.Show();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            FrmConfiguracionExtra frmConfiguracionExtra = new FrmConfiguracionExtra(factory, equipo);
            frmConfiguracionExtra.Show();
        }
    }
}
