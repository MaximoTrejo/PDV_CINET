using ConfiguradorPDV.Controllers;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
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
    public partial class FrmMail : Form
    {
        Factory factory;
        LinkedServer linkedServer_;
        parametros_controller parametros_;

        public FrmMail(Factory factory, LinkedServer linkedServer_)
        {
            InitializeComponent();
            this.factory = factory;
            this.linkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
        }

        private void FrmMail_Load(object sender, EventArgs e)
        {
            List<string> opcionesSiNo = new List<string> { "N", "S" };
            cbxUsaCierreMail.Items.AddRange(opcionesSiNo.ToArray());
            //traer parametros
            tbxCorreoEnvia.Text = parametros_.TraerValorParametro("@MAILSERV");
            tbxPuertoSMTP.Text = parametros_.TraerValorParametro("@PORTSERV");
            tbxSSL.Text = parametros_.TraerValorParametro("@SSLSERV");
            tbxServicioSMTP.Text = parametros_.TraerValorParametro("@SMTPSERV");
            tbxEnviaMaila.Text = parametros_.TraerValorParametro("MAILCAJA");
            cbxUsaCierreMail.Text = parametros_.TraerValorParametro("CAJAXMAIL");
            tbxPasswordCorreo.Text = parametros_.TraerValorParametro("@PSWSERV");
            //cambiar titulo formulario
            this.Text = "FrmMail " + linkedServer_._equipo + linkedServer_._puerto;

        }

        private void btnCierreMail_Click(object sender, EventArgs e)
        {
            string correoEnvia = tbxCorreoEnvia.Text;
            string puertoSMTP = tbxPuertoSMTP.Text;
            string passwordCorreo = tbxPasswordCorreo.Text;
            string SSL = tbxSSL.Text;
            string servicioSMTP  = tbxServicioSMTP.Text;
            string enviaMail = tbxEnviaMaila.Text;
            string UsaCierreMail = cbxUsaCierreMail.Text;

            if (UsaCierreMail == "S")
            {
                parametros_.modificarParametros("@MAILSERV", "", correoEnvia);
                parametros_.modificarParametros("@PORTSERV", "", puertoSMTP);
                parametros_.modificarParametros("@PSWSERV", "", passwordCorreo);
                parametros_.modificarParametros("@SSLSERV", "", SSL);
                parametros_.modificarParametros("@SMTPSERV", "", servicioSMTP);
                parametros_.modificarParametros("MAILCAJA", "", enviaMail);
                parametros_.modificarParametros("CAJAXMAIL", "", UsaCierreMail);
            }
            else
            {
                parametros_.modificarParametros("@MAILSERV", "", "NE");
                parametros_.modificarParametros("@PORTSERV", "", "NE");
                parametros_.modificarParametros("@PSWSERV", "", "NE");
                parametros_.modificarParametros("@SSLSERV", "", "NE");
                parametros_.modificarParametros("@SMTPSERV", "", "NE");
                parametros_.modificarParametros("MAILCAJA", "", "NE");
                parametros_.modificarParametros("CAJAXMAIL", "", UsaCierreMail);
            }

        }


    }
}
