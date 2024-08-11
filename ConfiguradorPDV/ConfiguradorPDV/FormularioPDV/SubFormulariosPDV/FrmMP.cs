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
    
    public partial class FrmMP : Form
    {
        Factory factory;
        LinkedServer linkedServer_;
        parametros_controller parametros_;
        public FrmMP(Factory factory, LinkedServer linkedServer_)
        {
            InitializeComponent();
            this.factory = factory;
            this.linkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
        }

        private void FrmMP_Load(object sender, EventArgs e)
        {
            List<string> opcionesSiNo = new List<string> { "N", "S" };
            cbxUsaMP.Items.AddRange(opcionesSiNo.ToArray());
            cbxUsaCashout.Items.AddRange(opcionesSiNo.ToArray());
            cbxUsaPorcion.Items.AddRange(opcionesSiNo.ToArray());
            //traer parametros
            cbxUsaMP.Text = parametros_.TraerValorParametro("MERPAGO");
            cbxUsaCashout.Text = parametros_.TraerValorParametro("CASHOUT");
            cbxUsaPorcion.Text = parametros_.TraerValorParametro("UsaMedPor");
            tbxExternalID.Text = parametros_.TraerValorParametro("EXTERIDMP");
            tbxToken.Text = parametros_.TraerValorParametro("TOKENMP");
            tbxClientID.Text = parametros_.TraerValorParametro("C_IDMP");
            tbxClientSecret.Text = parametros_.TraerValorParametro("C_SECRETMP");
            //cambiar titulo formulario
            this.Text = "FrmPDV " + linkedServer_._equipo + linkedServer_._puerto;
        }

        private void btnExternalId_Click(object sender, EventArgs e)
        {
            string externalID = tbxExternalID.Text;
            parametros_.modificarParametros("EXTERIDMP","",externalID);
        }

        private void btnToken_Click(object sender, EventArgs e)
        {
            string token = tbxToken.Text;
            parametros_.modificarParametros("TOKENMP", "",token);
        }

        private void btnClientID_Click(object sender, EventArgs e)
        {
            string clientId = tbxClientID.Text;
            parametros_.modificarParametros("C_IDMP","",clientId);
        }

        private void btnClientSecret_Click(object sender, EventArgs e)
        {
            string clientSecret = tbxClientSecret.Text;
            parametros_.modificarParametros("C_SECRETMP","", clientSecret);
        }

        private void btnMediaPorcion_Click(object sender, EventArgs e)
        {
            string MediaPorcion = cbxUsaPorcion.Text;
            parametros_.modificarParametros("UsaMedPor","",MediaPorcion);
        }

        private void btnUsaMP_Click(object sender, EventArgs e)
        {
            string UsaMP = cbxUsaMP.Text;
            parametros_.modificarParametros("MERPAGO","",UsaMP);

            if (UsaMP == "S")
            {
                tbxToken.Enabled =true;
                tbxClientID.Enabled = true;
                tbxClientSecret.Enabled = true;
            }
            else
            {
                tbxToken.Enabled = false;
                tbxClientID.Enabled = false;
                tbxClientSecret.Enabled = false;
                parametros_.modificarParametros("UsaMedPor", "", "N");
                parametros_.modificarParametros("C_SECRETMP", "", "NE");
                parametros_.modificarParametros("C_IDMP", "", "NE");
                parametros_.modificarParametros("TOKENMP", "", "NE");
                parametros_.modificarParametros("EXTERIDMP", "", "NE");
                parametros_.modificarParametros("CASHOUT", "", "N");
            }
        }

        private void btnUsaCashout_Click(object sender, EventArgs e)
        {
            string cashout = cbxUsaCashout.Text;
            parametros_.modificarParametros("CASHOUT","",cashout);
        }
    }





}
