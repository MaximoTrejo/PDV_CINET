using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class cbte_egresos_n_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public cbte_egresos_n_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void insertarEgreso(string pdv)
        {

            string ConexionEquipo = _equipo.VerificarLinkedServer();

            cbte_egresos_n cbte_Egresos_N = new cbte_egresos_n(_conexion,pdv);


            string existeCIE = cbte_Egresos_N.BuscarUno(ConexionEquipo, "CIE");

            if (existeCIE == "NE")
            {
                cbte_Egresos_N.insertarUno(ConexionEquipo, "CIE");
            }

            string existeOPA = cbte_Egresos_N.BuscarUno(ConexionEquipo, "OPA");

            if (existeOPA == "NE")
            {
                cbte_Egresos_N.insertarUno(ConexionEquipo, "OPA");
            }

            string existeOPC = cbte_Egresos_N.BuscarUno(ConexionEquipo, "OPC");

            if (existeOPC == "NE")
            {
                cbte_Egresos_N.insertarUno(ConexionEquipo, "OPC");
            }

        }
    }
}
