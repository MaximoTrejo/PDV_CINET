using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConfiguradorPDV.DB;
using System.Windows.Forms;

namespace ConfiguradorPDV.DB
{
    public class LinkedServer
    {

        Factory factory;
        string _equipo;
        string _baseDatos;
        string _clave;
        public string _puerto;
        public bool EsLinkedServer = false;
        public LinkedServer(Factory factory =null, string equipo = null, string clave = null, string puerto = null)
        {
            this.factory = factory;
            _equipo = equipo;
            _clave = clave;
            _puerto = puerto;
            _baseDatos = TraerNombreBase();
        }

        public void CrearLinkedServer()
        {
            try
            {
                AccesoDatos accesoDatos = factory.ObtenerConexion();

                string queryLinkedServer = $@"
                EXEC sp_addlinkedserver 
                @server = '{_equipo},{_puerto}', 
                @srvproduct = N'SQL Server';

                EXEC sp_addlinkedsrvlogin 
                @rmtsrvname = '{_equipo},{_puerto}', 
                @useself = 'false', 
                @locallogin = NULL, 
                @rmtuser = 'sa', 
                @rmtpassword = '{_clave}';
                ";

                SqlCommand comando = accesoDatos.PrepararConsulta(queryLinkedServer);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public string VerificarLinkedServer()
        {
            if (EsLinkedServer is true)
            {
                return $"[{_equipo},{_puerto}].[{_baseDatos}].dbo";
            }
            else
            {
                return "";
            }
        }

        public string TraerNombreBase()
        {
            string nombreBase = null;

            if (factory != null)
            {
                AccesoDatos accesoDatos = factory.ObtenerConexion();

                string linkedDatabase = $"{_equipo},{_puerto}";
                string query = $"SELECT name FROM [{linkedDatabase}].master.sys.databases WHERE name LIKE @pattern;";

                try
                {
                    using (SqlCommand comando = accesoDatos.PrepararConsulta(query))
                    {
                        comando.Parameters.AddWithValue("@pattern", "%PDV%");

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombreBase = reader["name"].ToString();
                            }
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
            }

            return nombreBase;
        }




    }
}
