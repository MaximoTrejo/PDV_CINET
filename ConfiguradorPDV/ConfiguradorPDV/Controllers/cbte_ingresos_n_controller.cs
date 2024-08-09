using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class cbte_ingresos_n_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public cbte_ingresos_n_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }


        public string BuscarUno(string pdv, string reporte)
        {
            string exito;
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            cbte_ingresos_n cbte_Ingresos = new cbte_ingresos_n(_conexion,pdv);
            exito = cbte_Ingresos.BuscarUno(ConexionEquipo, reporte);
            return exito;
        }

        public void modificarCbteIngresos(string pdv)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            cbte_ingresos_n cbte_Ingresos = new cbte_ingresos_n(_conexion, pdv);

            string existeREA = cbte_Ingresos.BuscarUno(ConexionEquipo, "REA");

            if (existeREA == "NE")
            {
                cbte_Ingresos.insertarUno(ConexionEquipo, "REA");
            }

            string existeREC = cbte_Ingresos.BuscarUno(ConexionEquipo, "REA");

            if (existeREC == "NE")
            {
                cbte_Ingresos.insertarUno(ConexionEquipo, "REC");
            }

        }
    }
}
