using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConfiguradorPDV.DB
{
    public class AccesoDatos
    {
        private static AccesoDatos _instancia;
        private SqlConnection _conexion;

        public AccesoDatos(string server, string port, string database, string password)
        {
           string connectionString = $"Server={server},{port};Database={database};User Id=sa;Password={password};";
           _conexion = new SqlConnection(connectionString);
           _conexion.Open();
            
        }

        public static AccesoDatos ObtenerInstancia(string server, string port, string database, string password)
        {
           _instancia = new AccesoDatos(server, port, database, password);
           return _instancia;
        }
        public SqlCommand PrepararConsulta(string sql)
        {
            return new SqlCommand(sql, _conexion);
        }

        public void CerrarConexion()
        {
            if (_conexion != null && _conexion.State == ConnectionState.Open)
            {
                _conexion.Close();
            }
        }

    }
}
