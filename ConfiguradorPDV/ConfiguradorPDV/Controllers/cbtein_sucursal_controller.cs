using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class cbtein_sucursal_controller
    {

        Factory _conexion;
        LinkedServer _equipo;

        public cbtein_sucursal_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public string BuscarUno(string pdv)
        {
            string exito;
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            cbtein_sucursal cbtein_Sucursal = new cbtein_sucursal(_conexion, pdv);

            exito = cbtein_Sucursal.BuscarUno(ConexionEquipo);
            return exito;
        }

        public void modificarCbteinSuc(string pdv)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            cbtein_sucursal cbtein_Sucursal = new cbtein_sucursal(_conexion, pdv);


            string existe = cbtein_Sucursal.BuscarUno(ConexionEquipo);

            if (existe == "NE")
            {
                cbtein_Sucursal.insertarUno(ConexionEquipo);
            }

        }
    }
}
