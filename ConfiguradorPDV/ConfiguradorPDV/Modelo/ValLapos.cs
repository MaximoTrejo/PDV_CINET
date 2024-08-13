using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfiguradorPDV.Modelo
{
    public class ValLapos
    {
        Factory _conexion;
        string _val_codigo;
        string _lpo_numcomercio;

        public ValLapos(Factory conexion, string val_codigo =null, string lpo_numcomercio = null)
        {
            _conexion = conexion;
            _val_codigo = val_codigo;
            _lpo_numcomercio = lpo_numcomercio;
        }

        public SqlDataReader TraerDatosTarjetas(string ConexionEquipo)
        {
            AccesoDatos accesoDatos = _conexion.ObtenerConexion();
            string query = $@"select Val_codigo,lpo_numcomercio from {ConexionEquipo}.ValLapos";
            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            SqlDataReader reader = comando.ExecuteReader();
            return reader;
        }

        public void modificarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();

                string query = $"UPDATE {ConexionEquipo}.ValLapos SET lpo_numcomercio = @valor  WHERE Val_codigo = @codigo";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@valor", _lpo_numcomercio);
                comando.Parameters.AddWithValue("@codigo", _val_codigo);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el ValLapos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
