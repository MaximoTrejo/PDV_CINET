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
    public class categdgi
    {
        Factory _conexion;

        public categdgi(Factory conexion)
        {

            _conexion = conexion;
        }

        public void modificarComprobanteDefault(string ConexionEquipo ,string codigo, string comprobante)
        {

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"UPDATE {ConexionEquipo}.categdgi SET catdgi_cbtexdefa = @comprobante WHERE catdgi_codigo = @codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@comprobante", comprobante);

            comando.ExecuteNonQuery();
        }
        public void modificarComprobanteNotaCreditoDefault(string ConexionEquipo, string codigo, string comprobante)
        {

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"UPDATE {ConexionEquipo}.categdgi SET catdgi_cbtexdefac = @comprobante WHERE catdgi_codigo = @codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@comprobante", comprobante);

            comando.ExecuteNonQuery();
        }

        public string traerUno(string ConexionEquipo ,string codigo)
        {
            string exito = "NE";
            try
            {

                AccesoDatos accesoDatos = _conexion.ObtenerConexion();

                string query = $"SELECT catdgi_cbtexdefa FROM {ConexionEquipo}.categdgi WHERE catdgi_codigo = @codigo";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);

                comando.Parameters.AddWithValue("@codigo", codigo);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    exito = reader["catdgi_cbtexdefa"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se perdio la conexion " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return exito;
            }

            return exito;
        }


    }
}
