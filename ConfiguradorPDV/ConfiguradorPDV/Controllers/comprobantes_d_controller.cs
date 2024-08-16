using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;

namespace ConfiguradorPDV.Controllers
{
    public class comprobantes_d_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public comprobantes_d_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void eliminarComprobante(string comprobante,string modulo , string concepto)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            comprobantes_d comprobantes_D = new comprobantes_d(_conexion, comprobante, modulo, concepto);
            comprobantes_D.eliminarUno(ConexionEquipo);
        }

        public void modificarFormulaComprobante(string comprobante, string modulo, string concepto,string fromula)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            comprobantes_d comprobantes_D = new comprobantes_d(_conexion, comprobante, modulo, concepto, fromula);
            comprobantes_D.modificarFormula(ConexionEquipo);

        }
        public void insertarComprobante(string comprobante, string modulo, string concepto, string fromula)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            comprobantes_d comprobantes_D = new comprobantes_d(_conexion, comprobante, modulo, concepto, fromula);
            comprobantes_D.insertarUno(ConexionEquipo);

        }

    }
}
