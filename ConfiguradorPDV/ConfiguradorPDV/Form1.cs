using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Controllers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ConfiguradorPDV.FormularioBackoffice;

namespace ConfiguradorPDV
{
    public partial class frmPrincipal : Form
    {
        public master_controller master_controller;
        Factory factory;
        public frmPrincipal()
        {
            InitializeComponent();
            master_controller = new master_controller(factory);
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {

            string IP = tbxIP.Text;
            string puerto = tbxPuerto.Text;
            string clave = tbxClave.Text;

            Factory accesoDatos = new Factory(IP, puerto, "master", clave);
            accesoDatos.ObtenerConexion();

            master_controller = new master_controller(accesoDatos);

            List<string> databases = master_controller.GetDB();
            cbxBases.DataSource = databases;


        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            string IP = tbxIP.Text;
            string puerto = tbxPuerto.Text;
            string clave = tbxClave.Text;
            string baseDatos = cbxBases.Text;

            Factory accesoBaseElegida = new Factory(IP, puerto, baseDatos, clave);
            accesoBaseElegida.ObtenerConexion();
            factory = accesoBaseElegida;
            DataTable equiposTable;
            master_controller = new master_controller(factory);
            equiposTable = master_controller.GetEquipos();
            dgvEquipos.DataSource = equiposTable;
            dgvEquipos.CurrentCell = null;


        }

        private void btnVerPDV_Click(object sender, EventArgs e)
        {
            string cajaSeleccionada;
            string claveCaja;
            string puertoCaja;
            LinkedServer linkedServer = new LinkedServer(); 

            if (cbxUsaLinkedServer.Checked)
            {
                cajaSeleccionada = dgvEquipos.CurrentRow.Cells[2].Value.ToString();

                if (cbxClaveEquipo.Checked)
                {
                    claveCaja = tbxClaveCaja.Text;
                    puertoCaja = tbxPuertoCaja.Text;
                }
                else
                {
                    claveCaja = "cinettorcel";
                    puertoCaja = "1433";
                }

                linkedServer = new LinkedServer(factory, cajaSeleccionada, claveCaja, puertoCaja);
                linkedServer.EsLinkedServer = true;
                linkedServer.CrearLinkedServer();

            }

            FrmPDV pDV = new FrmPDV(factory,linkedServer);
            pDV.Show();

        }

        private void cbxClaveEquipo_CheckedChanged(object sender, EventArgs e)
        {

            if (cbxClaveEquipo.Checked)
            {
                tbxClaveCaja.Enabled = true;
                tbxPuertoCaja.Enabled=true;
            }
            else
            {
                tbxClaveCaja.Enabled = false;
                tbxPuertoCaja .Enabled = false;
            }
        }

        private void cbxUsaLinkedServer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUsaLinkedServer.Checked)
            {
                dgvEquipos.Enabled = true;
            }
            else
            {
                dgvEquipos.Enabled = false;
                dgvEquipos.CurrentCell = null;
            }
        }

        private void btnVerBackoffice_Click(object sender, EventArgs e)
        {
            LinkedServer linkedServer = new LinkedServer();

            FrmBACKOFFICE frmBACKOFFICE = new FrmBACKOFFICE(factory,linkedServer);
            frmBACKOFFICE.Show();
        }
    }
}
