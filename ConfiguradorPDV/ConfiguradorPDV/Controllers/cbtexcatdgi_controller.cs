using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;

namespace ConfiguradorPDV.Controllers
{
    public class cbtexcatdgi_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public cbtexcatdgi_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }


        public void insertarCbtexcatdgi(string cardgi, string modulo, string codigo)
        {

            string ConexionEquipo = _equipo.VerificarLinkedServer();

            cbtexcatdgi cbtexcatdgi = new cbtexcatdgi(_conexion, cardgi, modulo, codigo);

            string existe = cbtexcatdgi.BuscarUno(ConexionEquipo);

            if (existe == "NE")
            {
                cbtexcatdgi.insertarUno(ConexionEquipo);
            }

        }

    }
}
