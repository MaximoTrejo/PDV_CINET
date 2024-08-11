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
    public partial class FrmCF : Form
    {
        Factory Factory;
        LinkedServer LinkedServer_;
        parametros_controller parametros_;
        public FrmCF(Factory factory, LinkedServer linkedServer_)
        {
            this.Factory = factory;
            InitializeComponent();
            LinkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
        }

        private void FrmCF_Load(object sender, EventArgs e)
        {
            List<string> opcionesSiNo = new List<string> { "N", "S" };
            cbxUsaHasar.Items.AddRange(opcionesSiNo.ToArray());
            tbxIpHasar.Text = parametros_.TraerValorParametro("HASARIP");
            cbxUsaHasar.Text = parametros_.TraerValorParametro("CFISCAL") == "HASAR" ? "S" : "N";
            tbxModeloCF.Text = parametros_.TraerValorParametro("CFMODELO");
            tbxPuertoF.Text = parametros_.TraerValorParametro("FISCALPORT");
            //cambiar titulo formulario
            this.Text = "FrmCF " + LinkedServer_._equipo + LinkedServer_._puerto;
        }

        private void btnIpHasar_Click(object sender, EventArgs e)
        {
            string IpHasar = tbxIpHasar.Text;
            parametros_.modificarParametros("HASARIP","",IpHasar);
        }

        private void btnUsaHasar_Click(object sender, EventArgs e)
        {
            string usaHasar = cbxUsaHasar.Text;
            if (usaHasar == "S")
            {
                parametros_.modificarParametros("HASARMODEL","","250");
                parametros_.modificarParametros("CFISCAL", "", "HASAR");
                parametros_.modificarParametros("CFMODELO", "", "250");

            }
            else
            {
                parametros_.modificarParametros("HASARMODEL", "", "NE");
                parametros_.modificarParametros("CFISCAL", "", "NE");
                parametros_.modificarParametros("CFMODELO", "", "NE");
            }
        }

        private void btnModeloCF_Click(object sender, EventArgs e)
        {
            string modeloCF = tbxModeloCF.Text;
            switch (modeloCF)
            {
                case "T900":
                    parametros_.modificarParametros("CFISCAL", "", "EPSON2");
                    parametros_.modificarParametros("CFMODELO", "", modeloCF);
                    break;

                case "250":
                    parametros_.modificarParametros("CFISCAL", "", "HASAR");
                    parametros_.modificarParametros("CFMODELO", "", modeloCF);
                    parametros_.modificarParametros("HASARMODEL", "", "250");
                    break;

                case "U220":
                    parametros_.modificarParametros("CFISCAL", "", "EPSON2");
                    parametros_.modificarParametros("CFMODELO", "", modeloCF);
                    break;

                default:
                    parametros_.modificarParametros("CFMODELO", "", modeloCF);
                    break;  

            }
        }

        private void tbxPuertoF_Click(object sender, EventArgs e)
        {
            string puertoF = tbxPuertoF.Text;
            parametros_.modificarParametros("FISCALPORT","",puertoF);
        }
    }
}
