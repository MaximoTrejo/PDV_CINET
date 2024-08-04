using ConfiguradorPDV.DB;
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
        public FrmMail(Factory factory)
        {
            InitializeComponent();
            this.factory = factory;
        }
    }
}
