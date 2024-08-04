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
            tbxCorreoEnvia.Text = parametros_.TraerValorParametro("@MAILSERV");
            tbxPuertoSMTP.Text = parametros_.TraerValorParametro("@PORTSERV");
            tbxSSL.Text = parametros_.TraerValorParametro("@SSLSERV");
            tbxServicioSMTP.Text = parametros_.TraerValorParametro("@SMTPSERV");
            tbxEnviaMaila.Text = parametros_.TraerValorParametro("MAILCAJA");
            cbxUsaCierreMail.Text = parametros_.TraerValorParametro("CAJAXMAIL");

        }
    }
}
