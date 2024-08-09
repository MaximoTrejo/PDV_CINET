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
    public class cbte_ingresos_n
    {
        Factory _conexion;
        string _cbteinsuc_codigo;

        public cbte_ingresos_n
        (
            Factory conexion,
            string cbteinsuc_codigo

        )
        {
            _conexion = conexion;
            _cbteinsuc_codigo = cbteinsuc_codigo;

        }


        public string BuscarUno(string ConexionEquipo , string reporte)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (cbteinsuc_codigo) FROM {ConexionEquipo}.cbte_ingresos_n  WHERE cbteinsuc_codigo = @cbteinsuc_codigo and cbtein_codigo = @cbtein_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@cbteinsuc_codigo", _cbteinsuc_codigo);
            comando.Parameters.AddWithValue("@cbtein_codigo", reporte);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["cbteinsuc_codigo"].ToString();
            }

            reader.Close();

            return exito;
        }



        public void insertarUno(string ConexionEquipo, string reporte)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $@"
                 INSERT INTO {ConexionEquipo}.cbte_ingresos_n
                     (
                      [CBTEIN_CODIGO]
                     ,[ITAL_CODIGO]
                     ,[CBTEINSUC_CODIGO]
                     ,[CBTEINN_NUMERO]
                     ,[CBTEINN_REPORTE]
                     ,[CBTEINN_IMPRESORA]
                     ,[CBTEINN_NUMERAENCOD]
                     ,[CBTEINN_COPIAS]
                     ,[CBTEINN_MODO]
                    )
                 VALUES 
                     (
                         @cbtein_codigo,
                         @ital_codigo,
                         @cbteinsuc_codigo,
                         @cbteinn_numero,
                         @cbteinn_reporte,
                         @cbteinn_impresora,
                         @cbteinn_numeraencod,
                         @cbteinn_copias,
                         @cbteinn_modo
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@cbtein_codigo", reporte);
                comando.Parameters.AddWithValue("@ital_codigo", "01");
                comando.Parameters.AddWithValue("@cbteinsuc_codigo", _cbteinsuc_codigo);
                comando.Parameters.AddWithValue("@cbteinn_numero",1);
                comando.Parameters.AddWithValue("@cbteinn_reporte", reporte);
                comando.Parameters.AddWithValue("@cbteinn_impresora", "");
                comando.Parameters.AddWithValue("@cbteinn_numeraencod", "");
                comando.Parameters.AddWithValue("@cbteinn_copias", 1);
                comando.Parameters.AddWithValue("@cbteinn_modo","VISTA");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el dato en Cbte_ingresos_n: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
