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
    public class cbtein_sucursal
    {
        Factory _conexion;
        string _cbteinsuc_codigo;

        public cbtein_sucursal(Factory conexion, string cbteinsuc_codigo)
        {
            _conexion = conexion;
            _cbteinsuc_codigo = cbteinsuc_codigo;
        }


        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (cbteinsuc_codigo) FROM {ConexionEquipo}.cbtein_sucursal  WHERE cbteinsuc_codigo = @cbteinsuc_codigo and cbtein_codigo = @cbtein_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@cbteinsuc_codigo", _cbteinsuc_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["cbteinsuc_codigo"].ToString();
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
                 INSERT INTO {ConexionEquipo}.cbtein_sucursal
                     (
                         [CBTEINSUC_CODIGO]
                        ,[CBTEINSUC_DESCRIPCION]
                     )
                 VALUES 
                     (
                        @cbteinsuc_codigo,
                        @cbteinsuc_descripcion
                        
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@cbteinsuc_codigo", _cbteinsuc_codigo);
                comando.Parameters.AddWithValue("@cbteinsuc_descripcion", "");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el dato en cbtein_sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
