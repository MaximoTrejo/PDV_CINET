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

            
        }

        private void cbxLinkedserver_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxLinkedserver.Checked)
            {
                tbxClaveLinked.Enabled = true;
                cbxCajasLinked.Enabled = true;
            }
            else
            {
                tbxClaveLinked.Enabled = false;
                cbxCajasLinked.Enabled = false;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            tbxClaveLinked.Enabled = false;
            cbxCajasLinked.Enabled = false;
            tbxClaveCaja.Enabled = false;
        }

        private void btnVerPDV_Click(object sender, EventArgs e)
        {
            LinkedServer linkedServer = new LinkedServer(factory);

            string cajaSeleccionada = dgvEquipos.CurrentRow.Cells[2].Value.ToString();

            if (cbxClaveEquipo.Enabled)
            {
                linkedServer.CrearLinkedServer(tbxClaveCaja.Text , cajaSeleccionada);
            }
            else
            {
                linkedServer.CrearLinkedServer("cinettorcel", cajaSeleccionada);
            }

            FrmPDV pDV = new FrmPDV(factory);
            pDV.Show();
        }

        private void cbxClaveEquipo_CheckedChanged(object sender, EventArgs e)
        {

            if (cbxClaveEquipo.Checked)
            {
                tbxClaveCaja.Enabled = true;
            }
            else
            {
                tbxClaveCaja.Enabled = false;
            }
        }
    }
}
