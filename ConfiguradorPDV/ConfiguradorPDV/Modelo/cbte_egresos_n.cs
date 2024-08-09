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
    public class cbte_egresos_n
    {
        Factory _conexion;
        string _cbteegsuc_codigo;


        public cbte_egresos_n(Factory conexion,  string cbteegsuc_codigo)
        {
            _conexion = conexion;
            _cbteegsuc_codigo = cbteegsuc_codigo;
        }


        public string BuscarUno(string ConexionEquipo , string reporte)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (cbteegsuc_codigo) FROM {ConexionEquipo}.cbte_egresos_n  WHERE cbteeg_codigo=@cbteeg_codigo and cbteegsuc_codigo=@cbteegsuc_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@cbteeg_codigo", reporte);
            comando.Parameters.AddWithValue("@cbteegsuc_codigo", _cbteegsuc_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["cbteegsuc_codigo"].ToString();
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
                 INSERT INTO {ConexionEquipo}.cbte_egresos_n
                     (
                        [CBTEEG_CODIGO]
                        ,[ETAL_CODIGO]
                        ,[CBTEEGSUC_CODIGO]
                        ,[CBTEEGN_NUMERO]
                        ,[CBTEEGN_REPORTE]
                        ,[CBTEEGN_IMPRESORA]
                        ,[CBTEEGN_NUMERAENCOD]
                        ,[CBTEEGN_COPIAS]
                      )
                 VALUES 
                     (
                         @cbteeg_codigo,
                         @etal_codigo,
                         @cbteegsuc_codigo,
                         @cbteegn_numero,
                         @cbteegn_reporte,
                         @cbteegn_imopresora,
                         @cbteegn_numeroencod,
                         @cbteegn_copias
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);

                comando.Parameters.AddWithValue("@cbteeg_codigo", reporte);
                comando.Parameters.AddWithValue("@etal_codigo", "01");
                comando.Parameters.AddWithValue("@cbteegsuc_codigo", _cbteegsuc_codigo);
                comando.Parameters.AddWithValue("@cbteegn_numero", 1);
                comando.Parameters.AddWithValue("@cbteegn_reporte", reporte);
                comando.Parameters.AddWithValue("@cbteegn_imopresora", "");
                comando.Parameters.AddWithValue("@cbteegn_numeroencod", "");
                comando.Parameters.AddWithValue("@cbteegn_copias", 0);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el dato en cbte_egresos_n: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
