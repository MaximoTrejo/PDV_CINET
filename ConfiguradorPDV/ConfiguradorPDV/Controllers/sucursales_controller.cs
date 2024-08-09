using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class sucursales_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public sucursales_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public string BuscarUno(string pdv , int tipo)
        {
            string exito;
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            Sucursales sucursal = new Sucursales(_conexion, pdv, tipo);
            exito = sucursal.BuscarUno(ConexionEquipo);
            return exito;
        }

        public void modificarSucursal(string pdv, int tipo)
        {

            string ConexionEquipo = _equipo.VerificarLinkedServer();

            Sucursales sucursal = new Sucursales(_conexion, pdv, tipo);

            string existe = sucursal.BuscarUno(ConexionEquipo);

            if (existe != "NE")
            {
                sucursal.modificarUno(ConexionEquipo);
            }
            else
            {
                sucursal.insertarUno(ConexionEquipo);
            }

        }
    }
}
