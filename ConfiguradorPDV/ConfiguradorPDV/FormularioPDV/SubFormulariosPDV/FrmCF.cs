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
    public partial class FrmCF : Form
    {
        Factory Factory;
        public FrmCF(Factory factory)
        {
            this.Factory = factory;
            InitializeComponent();
        }
    }
}
