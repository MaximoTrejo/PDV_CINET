using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.Modelo;

namespace ConfiguradorPDV.Controllers
{
    public class cbte_ingresos_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public cbte_ingresos_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void insertarComprobante(string cbtein_codigo, string cbtein_descripcion, string cbtein_sucdefa)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            cbte_ingresos cbte_Ingresos = new cbte_ingresos(_conexion, cbtein_codigo, cbtein_descripcion, cbtein_sucdefa);

            string existe = cbte_Ingresos.BuscarUno(ConexionEquipo);

            if (existe == "NE")
            {
                cbte_Ingresos.insertarUno(ConexionEquipo);
            }

        }

    }
}
