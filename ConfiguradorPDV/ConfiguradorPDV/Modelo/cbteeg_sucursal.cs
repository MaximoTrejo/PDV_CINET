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
    public class cbteeg_sucursal
    {
        Factory _conexion;
        string _cbteegsuc_codigo;

        public cbteeg_sucursal(Factory conexion, string cbteegsuc_codigo)
        {
            _conexion = conexion;
            _cbteegsuc_codigo = cbteegsuc_codigo;
        }



        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (cbteegsuc_codigo) FROM {ConexionEquipo}.cbteeg_sucursal  WHERE cbteegsuc_codigo = @cbteegsuc_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@cbteegsuc_codigo", _cbteegsuc_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["cbteegsuc_codigo"].ToString();
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
                 INSERT INTO {ConexionEquipo}.cbteeg_sucursal
                     (
                        [CBTEEGSUC_CODIGO]
                        ,[CBTEEGSUC_DESCRIPCION]
                     )
                 VALUES 
                     (
                        @cbteegsuc_codigo,
                        @cbteegsuc_descripcion
                        
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@cbteegsuc_codigo", _cbteegsuc_codigo);
                comando.Parameters.AddWithValue("@cbteegsuc_descripcion", "");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el dato en cbteeg_sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
