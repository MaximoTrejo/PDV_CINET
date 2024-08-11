using ConfiguradorPDV.Controllers;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfiguradorPDV
{
    public partial class FrmPDV : Form
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
        public FrmPDV(Factory factory,LinkedServer linked)
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
            parametros_ = new parametros_controller(factory ,linked);
            comprobantes_E_= new comprobantes_e_controller(factory, linked);
            InitializeComponent();
        }

        private void FrmPDV_Load(object sender, EventArgs e)
        {
            List<string> opcionesFECF = new List<string> { "FE", "CF" };
            cbxTipoFac.Items.AddRange(opcionesFECF.ToArray());
            //traer parametros
            tbxCuit.Text = parametros_.TraerValorParametro("CUIT");
            tbxPDV.Text = parametros_.TraerValorParametro("VTAPUNTO");
            tbxPDVManual.Text = parametros_.TraerValorParametro("PTOVTAMAN");
            tbxNumCaj.Text = parametros_.TraerValorParametro("NUMCAJA");
            cbxTipoFac.Text  = parametros_.TraerValorParametro("MODOFE") == "S" ? "FE" : "CF";
            tbxCodLocal.Text = parametros_.TraerValorParametro("NOMLOCAL");
            //cambiar titulo formulario
            this.Text = "FrmPDV " + linkedServer_._equipo + linkedServer_._puerto;
        }

        private void btnMP_Click(object sender, EventArgs e)
        {
            FrmMP frmMP = new FrmMP(factory,linkedServer_);
            frmMP.Show();
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            FrmMail frmMail = new FrmMail(factory,linkedServer_) ;
            frmMail.Show();
        }

        private void btnCF_Click(object sender, EventArgs e)
        {
            FrmCF frmCF = new FrmCF(factory,linkedServer_);
            frmCF.Show();
        }

        private void btnTicket_Click(object sender, EventArgs e)
        {
            FrmFactura frmFactura = new FrmFactura(factory,linkedServer_);
            frmFactura.Show();
        }

        private void btnSql_Click(object sender, EventArgs e)
        {
            FrmSQL frmSQL = new FrmSQL(factory,linkedServer_);
            frmSQL.Show();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            FrmConfiguracionExtra frmConfiguracionExtra = new FrmConfiguracionExtra(factory,linkedServer_);
            frmConfiguracionExtra.Show();
        }

        private void btnNumeroCaja_Click(object sender, EventArgs e)
        {
            string numeroCaja = tbxNumCaj.Text;
            parametros_.modificarParametros("NUMCAJA", "numeroCaja",numeroCaja);
        }

        private void btnCuit_Click(object sender, EventArgs e)
        {
            string cuit = tbxCuit.Text;
            parametros_.modificarParametros("CUIT", "CUIT", cuit);
        }

        private void btnCodLocal_Click(object sender, EventArgs e)
        {
            string codigoLocal = tbxCodLocal.Text;
            string sucursal = tbxPDV.Text;
            string numeroCaja = tbxNumCaj.Text;

            string codigo = codigoLocal + numeroCaja;

            asientos_.insertarAsiento(codigo, sucursal);
            periodos_.insertarPeriodo(codigo);
            depositos_.insertarDeposito(codigoLocal, sucursal);
            parametros_.modificarParametros("NOMLOCAL","CodigoLocal",codigoLocal);
            parametros_.modificarParametros("VTADEPOS", "DepositoVenta", codigoLocal);
        }

        private void btnPDV_Click(object sender, EventArgs e)
        {
            string sucursalFiscal = tbxPDV.Text;
            string tipo = cbxTipoFac.Text;
            string nomLocal = tbxCodLocal.Text;

            if (tipo == "FE")
            {
                sucursales_.modificarSucursal(sucursalFiscal , 2);
                cbtein_Sucursal_.modificarCbteinSuc(sucursalFiscal);
                cbte_Ingresos_N_.modificarCbteIngresos(sucursalFiscal);
                cbteeg_Sucursal_.modificarCbteegSucursal(sucursalFiscal);
                cbte_Egresos_N_.insertarEgreso(sucursalFiscal);
                asientos_E_.insertarAsiento(nomLocal,sucursalFiscal);
                comprobantes_N_.modificarComprobantes(sucursalFiscal, 2);
                parametros_.modificarParametros("VTAPUNTO","Sucursal",sucursalFiscal);
                parametros_.modificarParametros("MODOFE", "ActivaFE", "S");
                parametros_.modificarParametros("CDEFSUC", "", sucursalFiscal);
                parametros_.modificarParametros("PTOVTAFIS","",sucursalFiscal);
                parametros_.modificarParametros("MANFE","","S");
                dataBase_Controllers_.ReorganizarCierre();
                clientes_.modificarClientes(sucursalFiscal);
                sucursales_.modificarSucursalesInactivas();
            }
            else
            {
                sucursales_.modificarSucursal(sucursalFiscal, 0);
                cbtein_Sucursal_.modificarCbteinSuc(sucursalFiscal);
                cbte_Ingresos_N_.modificarCbteIngresos(sucursalFiscal);
                cbteeg_Sucursal_.modificarCbteegSucursal(sucursalFiscal);
                cbte_Egresos_N_.insertarEgreso(sucursalFiscal);
                asientos_E_.insertarAsiento(nomLocal, sucursalFiscal);
                comprobantes_N_.modificarComprobantes(sucursalFiscal, 0);
                parametros_.modificarParametros("VTAPUNTO", "Sucursal", sucursalFiscal);
                parametros_.modificarParametros("MODOFE", "ActivaFE", "N");
                parametros_.modificarParametros("CDEFSUC", "", sucursalFiscal);
                parametros_.modificarParametros("PTOVTAFIS", "", sucursalFiscal);
                parametros_.modificarParametros("MANFE", "", "S");
                dataBase_Controllers_.ReorganizarCierre();
                clientes_.modificarClientes(sucursalFiscal);
                sucursales_.modificarSucursalesInactivas();
            }

        }

        private void btnPDVManual_Click(object sender, EventArgs e)
        {
            string sucursalManual = tbxPDVManual.Text;

            sucursales_.modificarSucursal(sucursalManual,1);
            cbtein_Sucursal_.modificarCbteinSuc(sucursalManual);
            cbte_Ingresos_N_.modificarCbteIngresos(sucursalManual);
            cbteeg_Sucursal_.modificarCbteegSucursal(sucursalManual);
            cbte_Egresos_N_.insertarEgreso(sucursalManual);
            comprobantes_N_.modificarComprobantesManuales(sucursalManual);
            parametros_.modificarParametros("PTOVTAMAN", "SucursalManual", sucursalManual);
            parametros_.modificarParametros("APCAJON", "", "N");
            parametros_.modificarParametros("USACOMMANU", "","N");
            sucursales_.modificarSucursalesInactivas();

        }

        private void btnTFacturacion_Click(object sender, EventArgs e)
        {
            string TipoFac = cbxTipoFac.Text;
            string pdvFiscal = tbxPDV.Text;

            if (TipoFac =="FE") 
            {
                sucursales_.modificarSucursal(pdvFiscal, 2);
                comprobantes_E_.modificarCodigoComprobantes(TipoFac);
                comprobantes_N_.modificarComprobantes(pdvFiscal,2);
                parametros_.modificarParametros("USAFEWS", "", "S");
                parametros_.modificarParametros("USAFEX", "", "S");
                parametros_.modificarParametros("MANFE","","S");
                parametros_.modificarParametros("MODOFE", "", "S");
                parametros_.eliminarParametro("CIECAJFIS");
            }
            else
            {
                sucursales_.modificarSucursal(pdvFiscal, 0);
                comprobantes_E_.modificarCodigoComprobantes(TipoFac);
                comprobantes_N_.modificarComprobantes(pdvFiscal, 0);
                parametros_.modificarParametros("USAFEWS", "", "N");
                parametros_.modificarParametros("USAFEX", "", "N");
                parametros_.modificarParametros("CIECAJFIS","","S");
                parametros_.modificarParametros("MANFE", "", "N");
                parametros_.modificarParametros("MODOFE", "", "N");
            }
        }
    }
}
