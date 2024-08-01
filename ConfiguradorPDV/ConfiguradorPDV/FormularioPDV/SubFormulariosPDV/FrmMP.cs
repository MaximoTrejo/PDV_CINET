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
        string equipo;
        public FrmMP(Factory factory, string equipo)
        {
            InitializeComponent();
            this.factory = factory;
            this.equipo = equipo;
        }

        private void FrmMP_Load(object sender, EventArgs e)
        {

        }
    }





}
