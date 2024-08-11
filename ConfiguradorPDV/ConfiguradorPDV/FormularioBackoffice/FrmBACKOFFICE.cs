using ConfiguradorPDV.Controllers;
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

namespace ConfiguradorPDV.FormularioBackoffice
{
    public partial class FrmBACKOFFICE : Form
    {
        Factory factory;
        parametros_controller parametros_;
        asientos_e_controller asientos_;
        periodos_controller periodos_;
        depositos_controller depositos_;
        sucursales_controller sucursales_;
        dataBase_controllers dataBase_Controllers_;
        clientes_controller clientes_;
        cbtein_sucursal_controller cbtein_Sucursal_;
        cbte_ingresos_n_controller cbte_Ingresos_N_;
        cbteeg_sucursal_controller cbteeg_Sucursal_;
        cbte_egresos_n_controller cbte_Egresos_N_;
        asientos_e_controller asientos_E_;
        comprobantes_n_controller comprobantes_N_;
        comprobantes_e_controller comprobantes_E_;
        LinkedServer linkedServer_;
        public FrmBACKOFFICE(Factory factory, LinkedServer linked)
        {

            this.factory = factory;
            linkedServer_ = linked;
            sucursales_ = new sucursales_controller(factory, linked);
            clientes_ = new clientes_controller(factory, linked);
            cbtein_Sucursal_ = new cbtein_sucursal_controller(factory, linked);
            cbte_Ingresos_N_ = new cbte_ingresos_n_controller(factory, linked);
            cbteeg_Sucursal_ = new cbteeg_sucursal_controller(factory, linked);
            cbte_Egresos_N_ = new cbte_egresos_n_controller(factory, linked);
            asientos_E_ = new asientos_e_controller(factory, linked);
            comprobantes_N_ = new comprobantes_n_controller(factory, linked);
            dataBase_Controllers_ = new dataBase_controllers(factory, linked);
            periodos_ = new periodos_controller(factory, linked);
            depositos_ = new depositos_controller(factory, linked);
            asientos_ = new asientos_e_controller(factory, linked);
            parametros_ = new parametros_controller(factory, linked);
            comprobantes_E_ = new comprobantes_e_controller(factory, linked);
            InitializeComponent();
        }

        private void FrmBACKOFFICE_Load(object sender, EventArgs e)
        {
            //cambiar titulo formulario
            this.Text = "FrmBackoffice " + linkedServer_._equipo + linkedServer_._puerto;
            tbxCuit.Text = parametros_.TraerValorParametro("CUIT");
            tbxPDV.Text = parametros_.TraerValorParametro("VTAPUNTO");
            tbxCodLocal.Text = parametros_.TraerValorParametro("NOMLOCAL");
        }

        private void btnCuit_Click(object sender, EventArgs e)
        {
            string cuit = tbxCuit.Text;
            parametros_.modificarParametros("CUIT", "CUIT", cuit);
        }

        private void btnPDV_Click(object sender, EventArgs e)
        {
            string sucursalFiscal = tbxPDV.Text;
            string nomLocal = tbxCodLocal.Text;

            sucursales_.modificarSucursal(sucursalFiscal, 0);
            cbtein_Sucursal_.modificarCbteinSuc(sucursalFiscal);
            cbte_Ingresos_N_.modificarCbteIngresos(sucursalFiscal);
            cbteeg_Sucursal_.modificarCbteegSucursal(sucursalFiscal);
            cbte_Egresos_N_.insertarEgreso(sucursalFiscal);
            asientos_E_.insertarAsiento(nomLocal, sucursalFiscal);
            comprobantes_N_.modificarComprobantes(sucursalFiscal, 2);
            parametros_.modificarParametros("VTAPUNTO", "Sucursal", sucursalFiscal);
            parametros_.modificarParametros("CDEFSUC", "", sucursalFiscal);
            parametros_.modificarParametros("PTOVTAFIS", "", sucursalFiscal);
            clientes_.modificarClientes(sucursalFiscal);
        }

        private void btnCodLocal_Click(object sender, EventArgs e)
        {
            string nomLocal = tbxCodLocal.Text;
            string sucursalFiscal = tbxPDV.Text;
            parametros_.modificarParametros("nomlocal", "",nomLocal);
            parametros_.modificarParametros("CDEFFPA","","1");
            parametros_.modificarParametros("CDEFLISTA", "", "1");
            parametros_.modificarParametros("CDEFVENDE", "", "10");
            parametros_.modificarParametros("DEPABAST", "", nomLocal);
            parametros_.modificarParametros("DEPDEFA", "", nomLocal);
            parametros_.modificarParametros("DEPODEFA", "", nomLocal);
            parametros_.modificarParametros("PDEFFPAGO", "", "0");
            parametros_.modificarParametros("PDV_INIE1", "", "N");
            parametros_.modificarParametros("RECDEPFIJO", "", nomLocal);
            parametros_.modificarParametros("STOELIDEP", "", nomLocal);
            parametros_.modificarParametros("VTADEPSTO", "", nomLocal);
            parametros_.modificarParametros("VTADEPOS", "", nomLocal);
            depositos_.insertarDeposito(nomLocal, sucursalFiscal);
        }

        private void btnNomEmpresa_Click(object sender, EventArgs e)
        {
            string nomEmpre = tbxNombreEmpresa.Text;
            parametros_.modificarParametros("EMPRESA2", "", nomEmpre);
        }
    }
}
