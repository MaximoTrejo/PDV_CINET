using ConfiguradorPDV.Controllers;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.FormularioPDV.SubFormulariosPDV;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            tbxRMarcha.Text = parametros_.TraerValorParametro("RECOMANDA");
            tbxBandejas.Text = parametros_.TraerValorParametro("BANDEJAS");
            tbxMarcha.Text = parametros_.TraerValorParametro("MARCHA");
            tbxZonaActiva.Text = parametros_.TraerValorParametro("DUALPOINT");
            tbxZonaCafe.Text = parametros_.TraerValorParametro("ZONACAFE");
            tbxDNF.Text = parametros_.TraerValorParametro("DNFCOPFI");
            tbxUsaCarriles.Text = parametros_.TraerValorParametro("ELIGECOMA");
            tbxUsaZonaLocal.Text = parametros_.TraerValorParametro("ZONALOCAL");
            tbxTUnico.Text = parametros_.TraerValorParametro("USATURNO1");
            tbxDeliveryHero.Text = parametros_.TraerValorParametro("SERV_DVY");
            tbxUsaRappi.Text = parametros_.TraerValorParametro("RAPPI");
            tbxUsaAppMtz.Text = parametros_.TraerValorParametro("APP_MTZ");
            tbxUsaTotem.Text = parametros_.TraerValorParametro("TOTEM");
            tbxUsaLectorQr.Text = parametros_.TraerValorParametro("QRCupon");
            tbxUsaBanda.Text = parametros_.TraerValorParametro("SINBANDA");
            tbxCentraliza.Text = parametros_.TraerValorParametro("USAREMOTO");
            tbxCodigoB.Text = parametros_.TraerValorParametro("CODPUERTA");
            tbxLimiteCobro.Text = parametros_.TraerValorParametro("FAMAXVALOR");
            tbxUsaPedidoYa.Text = parametros_.TraerValorParametro("PEDIDOYA");
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
            parametros_.modificarParametros("USACOMMANU", "","S");
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

        private void btnBandejas_Click(object sender, EventArgs e)
        {
            string UsaBandejas = tbxBandejas.Text; 

            switch (UsaBandejas)
            {
                case "S":
                    parametros_.modificarParametros("BANDEJAS", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("BANDEJAS", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("BANDEJAS", "", "N");
                    break;
            }

            tbxBandejas.Text = parametros_.TraerValorParametro("BANDEJAS");
        }

        private void btnRMarcha_Click(object sender, EventArgs e)
        {
            string Rmarcha = tbxRMarcha.Text;

            switch (Rmarcha)
            {
                case "S":
                    parametros_.modificarParametros("RECOMANDA", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("RECOMANDA", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("RECOMANDA", "", "S");
                    break;
            }

            tbxRMarcha.Text = parametros_.TraerValorParametro("RECOMANDA");
        }

        private void btnMarcha_Click(object sender, EventArgs e)
        {
            string marcha = tbxMarcha.Text;

            switch (marcha)
            {
                case "S":
                    parametros_.modificarParametros("MARCHA", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("MARCHA", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("MARCHA", "", "S");
                    break;
            }
            tbxMarcha.Text = parametros_.TraerValorParametro("MARCHA");
        }

        private void btnZonaActiva_Click(object sender, EventArgs e)
        {
            string ZonaActiva = tbxZonaActiva.Text;

            switch (ZonaActiva)
            {
                case "S":
                    parametros_.modificarParametros("DUALPOINT", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("DUALPOINT", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("DUALPOINT", "", "S");
                    break;
            }
            tbxZonaActiva.Text = parametros_.TraerValorParametro("DUALPOINT");
        }

        private void btnZonaCafe_Click(object sender, EventArgs e)
        {

            string ZonaCafe = tbxZonaCafe.Text;

            switch (ZonaCafe)
            {
                case "S":
                    parametros_.modificarParametros("ZONACAFE", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("ZONACAFE", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("ZONACAFE", "", "S");
                    break;
            }
            tbxZonaCafe.Text = parametros_.TraerValorParametro("ZONACAFE");
        }

        private void btnDNF_Click(object sender, EventArgs e)
        {
            string DNF = tbxDNF.Text;

            switch (DNF)
            {
                case "S":
                    parametros_.modificarParametros("DNFCOPFI", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("DNFCOPFI", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("DNFCOPFI", "", "S");
                    break;

            }
            tbxDNF.Text = parametros_.TraerValorParametro("DNFCOPFI");
        }

        private void btnUsaCarriles_Click(object sender, EventArgs e)
        {
            string UsaCarriles = tbxUsaCarriles.Text;

            switch (UsaCarriles)
            {
                case "S":
                    parametros_.modificarParametros("ELIGECOMA", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("ELIGECOMA", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("ELIGECOMA", "", "S");
                    break;
            }
            tbxUsaCarriles.Text = parametros_.TraerValorParametro("ELIGECOMA");
        }

        private void btnUsaZonaLocal_Click(object sender, EventArgs e)
        {
            string UsaZonaLocal = tbxUsaZonaLocal.Text;

            switch (UsaZonaLocal)
            {
                case "S":
                    parametros_.modificarParametros("ZONALOCAL", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("ZONALOCAL", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("ZONALOCAL", "", "S");
                    break;
            }
            tbxUsaZonaLocal.Text = parametros_.TraerValorParametro("ZONALOCAL");
        }

        private void btnTurnoUnico_Click(object sender, EventArgs e)
        {
            string tUnico = tbxTUnico.Text;

            switch (tUnico)
            {
                case "S":
                    parametros_.modificarParametros("USATURNO1", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("USATURNO1", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("USATURNO1", "", "S");
                    break;
            }
            tbxTUnico.Text = parametros_.TraerValorParametro("USATURNO1");
        }

        private void btnDeliveryHero_Click(object sender, EventArgs e)
        {
            string deliveryHero = tbxDeliveryHero.Text;

            switch (deliveryHero)
            {
                case "S":
                    parametros_.modificarParametros("SERV_DVY", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("SERV_DVY", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("SERV_DVY", "", "S");
                    break;
            }
            tbxDeliveryHero.Text = parametros_.TraerValorParametro("SERV_DVY");
        }

        private void btnUsaPedidoYa_Click(object sender, EventArgs e)
        {
            string UsaPedidoYa = tbxUsaPedidoYa.Text;

            switch (UsaPedidoYa)
            {
                case "S":
                    parametros_.modificarParametros("PEDIDOYA", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("PEDIDOYA", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("PEDIDOYA", "", "S");
                    break;
            }
            tbxUsaPedidoYa.Text = parametros_.TraerValorParametro("PEDIDOYA");
        }

        private void btnUsaRappi_Click(object sender, EventArgs e)
        {
            string UsaRappi = tbxUsaRappi.Text;

            switch (UsaRappi)
            {
                case "S":
                    parametros_.modificarParametros("RAPPI", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("RAPPI", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("RAPPI", "", "S");
                    break;
            }
            tbxUsaRappi.Text = parametros_.TraerValorParametro("RAPPI");
        }

        private void btnUsaAppMtz_Click(object sender, EventArgs e)
        {
            string UsaAppMtz = tbxUsaAppMtz.Text;

            switch (UsaAppMtz)
            {
                case "S":
                    parametros_.modificarParametros("APP_MTZ", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("APP_MTZ", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("APP_MTZ", "", "S");
                    break;
            }
            tbxUsaAppMtz.Text = parametros_.TraerValorParametro("APP_MTZ");
        }


        private void btnUsaTotem_Click(object sender, EventArgs e)
        {
            string UsaTotem = tbxUsaTotem.Text;

            switch (UsaTotem)
            {
                case "S":
                    parametros_.modificarParametros("TOTEM", "", "N");
                    parametros_.modificarParametros("TOTEMPAU", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("TOTEM", "", "S");
                    parametros_.modificarParametros("TOTEMPAU", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("TOTEM", "", "S");
                    parametros_.modificarParametros("TOTEMPAU", "", "S");
                    break;
            }

            tbxUsaTotem.Text = parametros_.TraerValorParametro("TOTEM");
        }

        private void btnUsaLectorQr_Click(object sender, EventArgs e)
        {
            string UsaLectorQr = tbxUsaLectorQr.Text;

            switch (UsaLectorQr)
            {
                case "S":
                    parametros_.modificarParametros("QRCupon", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("QRCupon", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("QRCupon", "", "S");
                    break;
            }

            tbxUsaLectorQr.Text = parametros_.TraerValorParametro("QRCupon");
        }

        private void btnUsaBanda_Click(object sender, EventArgs e)
        {
            string UsaBanda = tbxUsaBanda.Text;

            switch (UsaBanda)
            {
                case "S":
                    parametros_.modificarParametros("SINBANDA", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("SINBANDA", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("SINBANDA", "", "S");
                    break;
            }
            tbxUsaBanda.Text = parametros_.TraerValorParametro("SINBANDA");

        }

        private void btnCentraliza_Click(object sender, EventArgs e)
        {
            string Centraliza = tbxCentraliza.Text;

            switch (Centraliza)
            {
                case "S":
                    parametros_.modificarParametros("USAREMOTO", "", "N");
                    break;
                case "N":
                    parametros_.modificarParametros("USAREMOTO", "", "S");
                    break;
                default:
                    parametros_.modificarParametros("USAREMOTO", "", "S");
                    break;
            }

            tbxCentraliza.Text = parametros_.TraerValorParametro("USAREMOTO");
        }

        private void btnCodigoB_Click(object sender, EventArgs e)
        {
            string CodigoB = tbxCodigoB.Text;
            parametros_.modificarParametros("CODPUERTA", "", CodigoB);
        }

        private void btnLimiteCobro_Click(object sender, EventArgs e)
        {
            string LimteCobro = tbxLimiteCobro.Text;
            parametros_.modificarParametros("FAMAXVALOR", "", LimteCobro);
        }

        private void btnLapos_Click(object sender, EventArgs e)
        {   
            FrmLapos lapos = new FrmLapos(factory, linkedServer_);
            lapos.Show();
        }
    }
}
