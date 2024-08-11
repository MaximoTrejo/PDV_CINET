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
    public class comprobantes_n
    {
        Factory _conexion;
        string _suc_codigo;

        public comprobantes_n(Factory conexion , string suc_codigo)
        {
            _conexion = conexion;
            _suc_codigo = suc_codigo;
        }

        public int BuscarComprobantes(string ConexionEquipo , string sucursal)
        {
            int exito = 0;

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT count(suc_codigo) FROM {ConexionEquipo}.comprobantes_n  WHERE  suc_codigo = @suc_codigo ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@suc_codigo", sucursal);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader.GetInt32(0);
            }

            reader.Close();

            return exito;
        }

        public void editarComprobantesFE(string ConexionEquipo, string sucAnterior)
        {

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"Update {ConexionEquipo}.comprobantes_n set CBTEN_IMPRESORA = '' , suc_codigo =@suc_codigo  WHERE  suc_codigo = @suc_codigo_anterior and CBTEE_MODULO = 'vtas' ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@suc_codigo_anterior",sucAnterior);
            comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);
            comando.ExecuteReader();

        }
        public void editarComprobantesCF(string ConexionEquipo, string sucAnterior)
        {

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"Update {ConexionEquipo}.comprobantes_n set CBTEN_IMPRESORA = 'CF', suc_codigo =@suc_codigo  WHERE  suc_codigo = @suc_codigo_anterior and CBTEE_MODULO = 'vtas'";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@suc_codigo_anterior", sucAnterior);
            comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);

            comando.ExecuteReader();

        }

        public void editarComprobantesManual(string ConexionEquipo, string sucAnterior)
        {

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"Update {ConexionEquipo}.comprobantes_n set CBTEN_IMPRESORA = '' , suc_codigo = @suc_codigo   WHERE  suc_codigo = @suc_codigo_anterior and CBTEE_MODULO = 'vtas' ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@suc_codigo_anterior", sucAnterior);
            comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);

            comando.ExecuteReader();

        }

        public void insertarUnoVtas(string ConexionEquipo , string comprobante)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $@"
                 INSERT INTO {ConexionEquipo}.comprobantes_n
                     (
                        [CBTEE_MODULO]
                        ,[CBTEE_CODIGO]
                        ,[SUC_CODIGO]
                        ,[CBTEN_NUMERO]
                        ,[CBTEN_REPORTE]
                        ,[CBTEN_IMPRESORA]
                        ,[CBTEN_NUMERAENCOD]
                        ,[CBTEN_COPIAS]
                    )
                 VALUES 
                     (
                         @cbtee_modulo,
                         @cbtee_codigo,
                         @suc_codigo,
                         @cbten_numero,
                         @cben_reporte,
                         @cbten_impresora,
                         @cbten_numeroencod,
                         @cbten_copias
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@cbtee_modulo", "VTAS");
                comando.Parameters.AddWithValue("@cbtee_codigo", comprobante);
                comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);
                comando.Parameters.AddWithValue("@cbten_numero", 0);
                comando.Parameters.AddWithValue("@cben_reporte", "VTA_FAB");
                comando.Parameters.AddWithValue("@cbten_impresora", "");
                comando.Parameters.AddWithValue("@cbten_numeroencod", comprobante);
                comando.Parameters.AddWithValue("@cbten_copias", 0);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el comprobantes_n: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        

    }
}
