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
using ConfiguradorPDV.Controllers;

namespace ConfiguradorPDV.FormularioPDV.SubFormulariosPDV
{
    public partial class FrmLapos : Form
    {
        Factory factory;
        LinkedServer LinkedServer_;
        parametros_controller parametros_;
        valLapos_controller valLapos_;
        
        public FrmLapos(Factory factory, LinkedServer linkedServer_)
        {
            this.factory = factory;
            LinkedServer_ = linkedServer_;
            valLapos_ = new valLapos_controller(factory, linkedServer_);
            parametros_ = new parametros_controller(factory, linkedServer_);
            InitializeComponent();
        }

        private void FrmLapos_Load(object sender, EventArgs e)
        {
            List<string> opcionesSiNo = new List<string> { "N", "S" };
            cbxUsaLapos.Items.AddRange(opcionesSiNo.ToArray());
            //parametros
            cbxUsaLapos.Text = parametros_.TraerValorParametro("LAPOSNET");
            tbxCuit.Text = parametros_.TraerValorParametro("TACOCUIT");
            tbxPuertoLapos.Text = parametros_.TraerValorParametro("LPoPuerto");
            tbxTerminal.Text = parametros_.TraerValorParametro("TERMINAL");
            //tabla
            DataTable equiposTable = valLapos_.TraerDatosTarjetas(); ;
            dgvNumeroComercio.DataSource = equiposTable;
            //
            if (cbxUsaLapos.Text == "N")
            {
                dgvNumeroComercio.Enabled = false;
                btnNumeroComercio.Enabled = false;
                tbxCuit.Enabled = false;
                btnCuitLapos.Enabled = false;
                tbxTerminal.Enabled = false;
                btnTerminalLapos.Enabled = false;
                btnPuertoLapos.Enabled = false;
                tbxPuertoLapos.Enabled = false;

            }
            else
            {
                dgvNumeroComercio.Enabled = true;
                btnNumeroComercio.Enabled = true;
                tbxCuit.Enabled = true;
                btnCuitLapos.Enabled = true;
                tbxTerminal.Enabled = true;
                btnTerminalLapos.Enabled = true;
                btnPuertoLapos.Enabled = true;
                tbxPuertoLapos.Enabled = true;
            }


        }

        private void btnUsaLapos_Click(object sender, EventArgs e)
        {
            string UsaLapos = cbxUsaLapos.Text;
            parametros_.modificarParametros("LAPOSNET", "", UsaLapos);
            if (UsaLapos=="N")
            {
                dgvNumeroComercio.Enabled = false;
                btnNumeroComercio.Enabled=false;
                tbxCuit.Enabled = false;
                btnCuitLapos.Enabled = false;
                tbxTerminal.Enabled = false;
                btnTerminalLapos.Enabled = false;
                btnPuertoLapos.Enabled=false;
                tbxPuertoLapos.Enabled = false;

            }
            else
            {
                dgvNumeroComercio.Enabled = true;
                btnNumeroComercio.Enabled = true;
                tbxCuit.Enabled = true;
                btnCuitLapos.Enabled = true;
                tbxTerminal.Enabled = true;
                btnTerminalLapos.Enabled = true;
                btnPuertoLapos.Enabled = true;
                tbxPuertoLapos.Enabled = true;
            }
        }

        private void btnCuitLapos_Click(object sender, EventArgs e)
        {
            string CuitLapos = tbxCuit.Text;
            parametros_.modificarParametros("TACOCUIT", "", CuitLapos);
        }

        private void btnTerminalLapos_Click(object sender, EventArgs e)
        {
            string Terminal = tbxTerminal.Text;
            parametros_.modificarParametros("TERMINAL", "", Terminal);
        }

        private void btnPuertoLapos_Click(object sender, EventArgs e)
        {
            string Puerto = tbxPuertoLapos.Text;
            parametros_.modificarParametros("LPoPuerto", "", Puerto);
        }

        private void btnNumeroComercio_Click(object sender, EventArgs e)
        {
            string codigo;
            string valor;

            for (int i = 0; i< dgvNumeroComercio.Rows.Count; i++)
            {
               codigo = dgvNumeroComercio.Rows[i].Cells["Val_codigo"].Value.ToString();
               valor = dgvNumeroComercio.Rows[i].Cells["lpo_numcomercio"].Value.ToString();

                valLapos_.modificarNumerosConercio(codigo , valor);
            }
        }
    }
}
