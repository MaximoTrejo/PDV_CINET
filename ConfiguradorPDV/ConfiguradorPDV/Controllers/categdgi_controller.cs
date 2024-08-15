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
                categdgi.modificarUno(ConexionEquipo, "I", "FAB");
                categdgi.modificarUno(ConexionEquipo, "N", "FAB");
                categdgi.modificarUno(ConexionEquipo, "M", "FAB");
            }
            else
            {
                string ConexionEquipo = _equipo.VerificarLinkedServer();
                categdgi categdgi = new categdgi(_conexion);
                categdgi.modificarUno(ConexionEquipo, "I", "FAA");
                categdgi.modificarUno(ConexionEquipo, "N", "FAA");
                categdgi.modificarUno(ConexionEquipo, "M", "FAA");
            }
          


        }
    }
}
