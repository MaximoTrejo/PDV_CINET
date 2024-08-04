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
        string _equipo;
        string _baseDatos;
        public linkedServer_controller(Factory factory, string equipo)
        {
            this.factory = factory;
            _equipo = equipo;
            _baseDatos = TraerNombreBase(_equipo);
        }

        public string TraerNombreBase(string equipo)
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


        public string TraerDatoParametroLinked(string parametro)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = factory.ObtenerConexion();

            string linkedDatabase = $"[{_equipo}].{_baseDatos}.dbo";

            string query = $"SELECT para_valor FROM {linkedDatabase}.parametros WHERE para_codigo = @parametro";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@parametro", parametro);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["para_valor"].ToString();
            }

            reader.Close();
           
            return exito;
        }


    }
}
