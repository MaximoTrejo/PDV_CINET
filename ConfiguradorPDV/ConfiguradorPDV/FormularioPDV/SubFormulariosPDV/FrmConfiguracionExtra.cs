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
    public partial class FrmConfiguracionExtra : Form
    {
        Factory factory;
        public FrmConfiguracionExtra(Factory factory)
        {
            InitializeComponent();
            this.factory = factory;
        }
    }
}
