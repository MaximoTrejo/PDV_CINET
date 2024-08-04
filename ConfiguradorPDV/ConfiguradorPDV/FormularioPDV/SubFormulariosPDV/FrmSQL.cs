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
        parametros_controller parametros_;
        public FrmSQL(Factory factory, LinkedServer linkedServer_)
        {
            this.factory = factory;
            InitializeComponent();
            LinkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory,linkedServer_);
        }

        private void FrmSQL_Load(object sender, EventArgs e)
        {

        }
    }
}
