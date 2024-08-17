using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfiguradorPDV.Modelo
{
    public class cbte_ingresos
    {
        Factory _conexion;
        string _cbtein_codigo;
        string _cbtein_descripcion;
        string _cbtein_sucdefa;

        public cbte_ingresos(Factory conexion, string cbtein_codigo, string cbtein_descripcion, string cbtein_sucdefa)
        {
            _conexion = conexion;
            _cbtein_codigo = cbtein_codigo;
            _cbtein_descripcion = cbtein_descripcion;
            _cbtein_sucdefa = cbtein_sucdefa;
        }

        public void insertarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $@"
                 INSERT INTO {ConexionEquipo}.cbte_ingresos
                      ([CBTEIN_CODIGO]
                       ,[CBTEIN_DESCRIPCION]
                       ,[CBTEIN_SUCDEFA])
                 VALUES 
                     (
                        @cbtein_codigo,
                        @cbtein_descripcion,
                        @cbtein_sucdefa
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);

                comando.Parameters.AddWithValue("@cbtein_codigo", _cbtein_codigo);
                comando.Parameters.AddWithValue("@cbtein_descripcion", _cbtein_descripcion);
                comando.Parameters.AddWithValue("@cbtein_sucdefa", _cbtein_sucdefa);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el dato en cbte_ingresos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (cbtein_codigo) FROM {ConexionEquipo}.cbte_ingresos  WHERE cbtein_codigo=@cbtein_codigo and cbtein_sucdefa = @cbtein_sucdefa";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@cbtein_codigo", _cbtein_codigo);
            comando.Parameters.AddWithValue("@cbtein_descripcion", _cbtein_descripcion);
            comando.Parameters.AddWithValue("@cbtein_sucdefa", _cbtein_sucdefa);
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["cbtein_codigo"].ToString();
            }

            reader.Close();

            return exito;
        }
    }
}
