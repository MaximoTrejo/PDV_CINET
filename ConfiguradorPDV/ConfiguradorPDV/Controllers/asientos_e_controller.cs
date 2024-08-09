using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{

    public class asientos_e_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public asientos_e_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void insertarAsiento(string asiento, string sucursal)
        {

            string ConexionEquipo = _equipo.VerificarLinkedServer();

            Asientos_E asientos = new Asientos_E(_conexion ,asiento , sucursal );

            string existe = asientos.BuscarUno(ConexionEquipo);

            if (existe == "NE")
            {
                asientos.insertarUno(ConexionEquipo);
            }

        }

    }
}
