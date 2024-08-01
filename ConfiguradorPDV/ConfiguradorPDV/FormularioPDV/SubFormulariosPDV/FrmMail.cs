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
        string equipo;
        public FrmMail(Factory factory,string equipo)
        {
            InitializeComponent();
            this.factory = factory;
            this.equipo = equipo;
        }
    }
}
