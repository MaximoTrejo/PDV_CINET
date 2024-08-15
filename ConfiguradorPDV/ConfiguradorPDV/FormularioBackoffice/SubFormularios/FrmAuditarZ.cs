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

namespace ConfiguradorPDV.FormularioBackoffice.SubFormularios
{
    public partial class FrmAuditarZ : Form
    {
        dataBase_controllers dataBase_Controllers_;
        Factory factory;
        LinkedServer linkedServer_;
        public FrmAuditarZ(Factory factory, LinkedServer linked)
        {
            this.factory = factory;
            linkedServer_ = linked;
            dataBase_Controllers_ = new dataBase_controllers(factory, linked);
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime FechaDesde = dtpDesde.Value;
            DateTime FechaHasta = dtpHasta.Value;
            string sucursal = cbxPDVs.Text;
            DataTable equiposTable = dataBase_Controllers_.AuditarZ(sucursal, FechaDesde, FechaHasta);
            dbvAuditarZ.DataSource = equiposTable;
        }

        private void AuditarZ_Load(object sender, EventArgs e)
        {
            List<string> pdvs = dataBase_Controllers_.TraerPDVs();
            cbxPDVs.Items.AddRange(pdvs.ToArray());
        }
    }
}
