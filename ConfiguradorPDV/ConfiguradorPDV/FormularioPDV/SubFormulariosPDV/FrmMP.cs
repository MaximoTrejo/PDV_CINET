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
            cbxUsaMP.Text = parametros_.TraerValorParametro("MERPAGO");
            cbxUsaCashout.Text = parametros_.TraerValorParametro("MERPAGO");
            cbxUsaPorcion.Text = parametros_.TraerValorParametro("UsaMedPor");
            tbxExternalID.Text = parametros_.TraerValorParametro("EXTERIDMP");
            tbxToken.Text = parametros_.TraerValorParametro("TOKENMP");
            tbxClientID.Text = parametros_.TraerValorParametro("C_IDMP");
            tbxClientSecret.Text = parametros_.TraerValorParametro("C_SECRETMP");
        }
    }





}
