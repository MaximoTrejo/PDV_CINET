using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConfiguradorPDV.Controllers
{
    public class linkedServer_controller
    {
        Factory factory;

        public linkedServer_controller(Factory factory)
        {
            this.factory = factory;
        }

        public string TraerNombreBase(string equipo, string puerto)
        {
            AccesoDatos accesoDatos = factory.ObtenerConexion();

            string linkedDatabase = $"{equipo}";

            string query = $"SELECT name FROM [{linkedDatabase}].master.sys.databases WHERE name LIKE '%PDV%';";
            
            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            string nombreBase = null;
            try
            {
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nombreBase = reader["name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }

            return nombreBase;
        }


        public string TraerDatoParametroLinked(string parametro, string equipo)
        {
            string exito = "NE";

            try
            {
                AccesoDatos accesoDatos = factory.ObtenerConexion();
                string database = TraerNombreBase(equipo, "1433");
                string linkedDatabase = $"[{equipo}].{database}.dbo";
                string query = $"SELECT para_valor FROM {linkedDatabase}.parametros WHERE para_codigo = @parametro";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@parametro", parametro);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    exito = reader["para_valor"].ToString();
                }

                reader.Close();
            }
            catch
            {
                exito = "NE";
            }

            return exito;
        }


    }
}
