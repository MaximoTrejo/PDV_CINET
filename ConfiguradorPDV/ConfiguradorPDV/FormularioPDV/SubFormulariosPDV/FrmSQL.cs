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
    public partial class FrmSQL : Form
    {
        Factory factory;
        LinkedServer LinkedServer_;
        dataBase_controllers dataBase_;
        public FrmSQL(Factory factory, LinkedServer linkedServer_)
        {
            this.factory = factory;
            InitializeComponent();
            LinkedServer_ = linkedServer_;
            dataBase_= new dataBase_controllers(factory, linkedServer_);
        }

        private void btnLimpiarPDV_Click(object sender, EventArgs e)
        {
            dataBase_.LimpiarPDV();
        }


        private void btnElimSucInactivas_Click(object sender, EventArgs e)
        {
            dataBase_.eliminarSucursalesInactivas();
        }

        private void FrmSQL_Load(object sender, EventArgs e)
        {
            //cambiar titulo formulario
            this.Text = "FrmMP " + LinkedServer_._equipo + LinkedServer_._puerto;
        }
    }
}
