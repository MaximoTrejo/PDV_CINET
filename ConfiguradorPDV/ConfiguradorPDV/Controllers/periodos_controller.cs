using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class periodos_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public periodos_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void insertarPeriodo(string codigo)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            Periodos periodos = new Periodos(_conexion,codigo);

            string existe = periodos.BuscarUno(ConexionEquipo);

            if (existe == "NE")
            {
                periodos.insertarUno(ConexionEquipo);
                periodos.deshailitarPeriodos(ConexionEquipo);
            }

        }
    }
}
