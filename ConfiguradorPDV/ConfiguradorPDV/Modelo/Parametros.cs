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
    public class Parametros
    {
        Factory _conexion;
        string _para_codigo;
        string _para_descripcion;
        string _para_valor;

        public Parametros(Factory conexion,string codigo = null, string descripcion = null, string valor = null)
        {
            _conexion = conexion;
            _para_codigo = codigo;
            _para_descripcion = descripcion;
            _para_valor = valor;
        }

        public string traerUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT para_valor FROM {ConexionEquipo}.parametros WHERE para_codigo = @parametro";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@parametro", _para_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["para_valor"].ToString();
            }

            reader.Close();

            return exito;
        }

        public void modificarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();

                string query = $"UPDATE {ConexionEquipo}.parametros SET para_valor = @valor , para_descripcion = @descripcion WHERE para_codigo = @parametro";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@valor", _para_valor);
                comando.Parameters.AddWithValue("@descripcion", _para_descripcion);
                comando.Parameters.AddWithValue("@parametro", _para_codigo);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el parámetro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void insertarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $"insert into {ConexionEquipo}.parametros ([PARA_CODIGO],[PARA_DESCRIPCION],[PARA_VALOR]) values (@parametro,@descripcion,@valor)";
                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@valor", _para_valor);
                comando.Parameters.AddWithValue("@descripcion", _para_descripcion);
                comando.Parameters.AddWithValue("@parametro", _para_codigo);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el parámetro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
