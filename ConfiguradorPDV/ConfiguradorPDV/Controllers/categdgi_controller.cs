using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;

namespace ConfiguradorPDV.Controllers
{
    public class categdgi_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public categdgi_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void modificarComprobanteCategdgi(string tipo)
        {
            if (tipo == "M")
            {
                string ConexionEquipo = _equipo.VerificarLinkedServer();
                categdgi categdgi = new categdgi(_conexion);
                categdgi.modificarComprobanteDefault(ConexionEquipo, "I", "FAB");
                categdgi.modificarComprobanteDefault(ConexionEquipo, "N", "FAB");
                categdgi.modificarComprobanteDefault(ConexionEquipo, "M", "FAB");
            }
            else
            {
                string ConexionEquipo = _equipo.VerificarLinkedServer();
                categdgi categdgi = new categdgi(_conexion);
                categdgi.modificarComprobanteDefault(ConexionEquipo, "I", "FAA");
                categdgi.modificarComprobanteDefault(ConexionEquipo, "N", "FAA");
                categdgi.modificarComprobanteDefault(ConexionEquipo, "M", "FAA");
            }
          


        }
        
        public void modificarComprobanteFacturaM()
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            categdgi categdgi = new categdgi(_conexion);
            categdgi.modificarComprobanteDefault(ConexionEquipo, "I", "FMA");
            categdgi.modificarComprobanteNotaCreditoDefault(ConexionEquipo, "I", "NCM");
            categdgi.modificarComprobanteDefault(ConexionEquipo, "M", "FMA");
            categdgi.modificarComprobanteNotaCreditoDefault(ConexionEquipo, "M", "NCM");
        }

        public void modificarComprobanteFacturaA()
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            categdgi categdgi = new categdgi(_conexion);
            categdgi.modificarComprobanteDefault(ConexionEquipo, "I", "FAA");
            categdgi.modificarComprobanteNotaCreditoDefault(ConexionEquipo, "I", "NCA");
            categdgi.modificarComprobanteDefault(ConexionEquipo, "M", "FAA");
            categdgi.modificarComprobanteNotaCreditoDefault(ConexionEquipo, "M", "NCA");
        }


        public string UsaFacturaAoM()
        {
            string exito;
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            categdgi categdgi = new categdgi(_conexion);
            exito=categdgi.traerUno(ConexionEquipo,"M");
            return exito;
        }
    }
}
