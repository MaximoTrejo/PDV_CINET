using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class cbteeg_sucursal_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public cbteeg_sucursal_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }


        public string BuscarUno(string pdv, string reporte)
        {
            string exito;
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            cbteeg_sucursal cbteeg_Sucursal = new cbteeg_sucursal(_conexion, pdv);
            exito = cbteeg_Sucursal.BuscarUno(ConexionEquipo);
            return exito;
        }

        public void modificarCbteegSucursal(string pdv)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            cbteeg_sucursal cbteeg_Sucursal = new cbteeg_sucursal(_conexion, pdv);

            string existe = cbteeg_Sucursal.BuscarUno(ConexionEquipo);

            if (existe == "NE")
            {
                cbteeg_Sucursal.insertarUno(ConexionEquipo);
            }

        }
    }
}
