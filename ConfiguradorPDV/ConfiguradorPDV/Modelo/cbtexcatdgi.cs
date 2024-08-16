using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ConfiguradorPDV.Modelo
{
    public class cbtexcatdgi
    {
        Factory _conexion;
        string _catdgi_codigo;
        string _cbtee_modulo;
        string _cbtee_codigo;

        public cbtexcatdgi(Factory conexion, string catdgi_codigo, string cbtee_modulo, string cbtee_codigo)
        {
            _conexion = conexion;
            _catdgi_codigo = catdgi_codigo;
            _cbtee_modulo = cbtee_modulo;
            _cbtee_codigo = cbtee_codigo;
        }

        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (catdgi_codigo) FROM {ConexionEquipo}.cbtexcatdgi  WHERE catdgi_codigo=@catdgi_codigo and cbtee_modulo = @cbtee_modulo and cbtee_codigo = @cbtee_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@catdgi_codigo", _catdgi_codigo);
            comando.Parameters.AddWithValue("@cbtee_codigo", _cbtee_codigo);
            comando.Parameters.AddWithValue("@cbtee_modulo", _cbtee_modulo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["catdgi_codigo"].ToString();
            }

            reader.Close();

            return exito;
        }



        public void insertarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $@"
                 INSERT INTO {ConexionEquipo}.cbtexcatdgi
                      ([CATDGI_CODIGO]
                      ,[CBTEE_MODULO]
                      ,[CBTEE_CODIGO])
                 VALUES 
                     (
                        @catdgi_codigo,
                        @cbtee_modulo,
                        @cbtee_codigo
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);

                comando.Parameters.AddWithValue("@catdgi_codigo", _catdgi_codigo);
                comando.Parameters.AddWithValue("@cbtee_codigo", _cbtee_codigo);
                comando.Parameters.AddWithValue("@cbtee_modulo", _cbtee_modulo);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el dato en cbtexcatdgi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void modificarUno(string ConexionEquipo)
        {

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"UPDATE {ConexionEquipo}.cbtexcatdgi SET cbtee_codigo = @cbtee_codigo WHERE catdgi_codigo = @catdgi_codigo and cbtee_modulo=@cbtee_modulo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@catdgi_codigo", _catdgi_codigo);
            comando.Parameters.AddWithValue("@cbtee_codigo", _cbtee_codigo);
            comando.Parameters.AddWithValue("@cbtee_modulo", _cbtee_modulo);

            comando.ExecuteNonQuery();
        }

    }
}
