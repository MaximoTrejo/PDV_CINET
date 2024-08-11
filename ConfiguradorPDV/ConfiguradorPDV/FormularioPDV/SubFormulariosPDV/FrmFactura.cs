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
    public partial class FrmFactura : Form
    {
        Factory factory;
        LinkedServer LinkedServer_;
        parametros_controller parametros_;
        datos_empresa_controller datos_;
        public FrmFactura(Factory factory ,LinkedServer linkedServer_)
        {
            InitializeComponent();
            this.factory = factory;  
            LinkedServer_ = linkedServer_;
            parametros_ = new parametros_controller(factory, linkedServer_);
            datos_ = new datos_empresa_controller(factory, linkedServer_);
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            tbxRazonSocial.Text = parametros_.TraerValorParametro("COMALIN1");
            tbxCuitEmpresa.Text = parametros_.TraerValorParametro("COMALIN4");
            tbxDireccion.Text = parametros_.TraerValorParametro("COMALIN2");
            tbxTelefono.Text = parametros_.TraerValorParametro("COMALIN5");
            tbxLocalidad.Text = parametros_.TraerValorParametro("COMALIN3");
            //cambiar titulo formulario
            this.Text = "FrmFactura " + LinkedServer_._equipo + LinkedServer_._puerto;
        }

        private void btnEFactura_Click(object sender, EventArgs e)
        {
            string razonSocial = tbxRazonSocial.Text;
            string cuitEmpresa = tbxCuitEmpresa.Text;
            string direccion = tbxDireccion.Text;
            string telefono = tbxTelefono.Text;
            string localidad = tbxLocalidad.Text;
            //ticket cierreCaja
            parametros_.modificarParametros("COMALIN1","",razonSocial);
            parametros_.modificarParametros("COMALIN4","",cuitEmpresa);
            parametros_.modificarParametros("COMALIN2","",direccion);
            parametros_.modificarParametros("COMALIN5","",telefono);
            parametros_.modificarParametros("COMALIN3","",localidad);
            //ticket manual
            parametros_.modificarParametros("PRNLIN1", "", razonSocial);
            parametros_.modificarParametros("PRNLIN2", "", cuitEmpresa);
            parametros_.modificarParametros("PRNLIN3", "", direccion);
            parametros_.modificarParametros("PRNLIN4", "", telefono);
            parametros_.modificarParametros("PRNLIN5", "", localidad);
            //comanda
            parametros_.modificarParametros("COMALIN01", "", razonSocial);
            parametros_.modificarParametros("COMALIN02", "", cuitEmpresa);
            parametros_.modificarParametros("COMALIN03", "", direccion);
            parametros_.modificarParametros("COMALIN04", "", telefono);
            parametros_.modificarParametros("COMALIN05", "", localidad);
            //ticket fiscal Electronico
            datos_.modificarDatoEmpresa("DATOS1",razonSocial);
            datos_.modificarDatoEmpresa("DATOS2",direccion);
            datos_.modificarDatoEmpresa("DATOS3", localidad);
            datos_.modificarDatoEmpresa("DATOS6", cuitEmpresa);
            datos_.modificarDatoEmpresa("LEYENDA1", telefono);



        }
    }
}
