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
    public class datos_empresa
    {
        Factory _conexion;
        string _dae_codigo;
        string _dae_valor;

        public datos_empresa(Factory conexion, string dae_codigo, string dae_valor)
        {
            _conexion = conexion;
            _dae_codigo = dae_codigo;
            _dae_valor = dae_valor;
        }

        public string traerUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT dae_codigo FROM {ConexionEquipo}.datos_empresa WHERE dae_codigo = @dae_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@dae_codigo", _dae_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["dae_codigo"].ToString();
            }

            reader.Close();

            return exito;
        }


        public void modificarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();

                string query = $"UPDATE {ConexionEquipo}.datos_empresa SET dae_valor = @dae_valor  WHERE dae_codigo = @dae_codigo";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@dae_codigo", _dae_codigo);
                comando.Parameters.AddWithValue("@dae_valor", _dae_valor);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el datos_empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void insertarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $"insert into {ConexionEquipo}.datos_empresa ([dae_codigo],[dae_valor]) values (@dae_codigo,@dae_valor)";
                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@dae_codigo", _dae_codigo);
                comando.Parameters.AddWithValue("@dae_valor", _dae_valor);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar en datos_empresa: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
