using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class valLapos_controller
    {
        Factory _conexion;
        LinkedServer _equipo;


        public valLapos_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }


        public DataTable TraerDatosTarjetas()
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            ValLapos lapos = new ValLapos(_conexion);
            SqlDataReader reader = lapos.TraerDatosTarjetas(ConexionEquipo);
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            return dataTable;
        }

        public void modificarNumerosConercio(string codigo , string valor)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            ValLapos lapos = new ValLapos(_conexion , codigo , valor);

            lapos.modificarUno(ConexionEquipo);
        }

    }
}
