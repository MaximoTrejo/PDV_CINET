using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class master_controller
    {
        Factory factory;

        public master_controller(Factory factory)
        {
            this.factory = factory;
        }


        public List<string> GetDB()
        {
            List<string> databases = new List<string>();

            AccesoDatos accesoDatos = factory.ObtenerConexion();

            try
            {
                SqlCommand comando = accesoDatos.PrepararConsulta("SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');");
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    
                    string dbName = reader.GetString(0);
                    databases.Add(dbName);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("No es posible conectarse", ex);
            }

            return databases;
        }
    }
}
