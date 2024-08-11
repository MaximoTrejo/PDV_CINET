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
    public class Sucursales
    {
        Factory _conexion;
        string _suc_codigo;
        int _suc_manual;

        public Sucursales(Factory conexion, string suc_codigo, int suc_manual)
        {
            _conexion = conexion;
            _suc_codigo = suc_codigo;
            _suc_manual = suc_manual;
        }

        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (suc_codigo) FROM {ConexionEquipo}.sucursales  WHERE suc_codigo = @suc_codigo ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["suc_codigo"].ToString();
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
                 INSERT INTO {ConexionEquipo}.sucursales
                     (
                         [SUC_CODIGO]
                        ,[SUC_MANUAL]
                        ,[SUC_LOCAL]
                    )
                 VALUES 
                     (
                         @suc_codigo,
                         @suc_manual,
                         @suc_local
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);
                comando.Parameters.AddWithValue("@suc_manual", _suc_manual);
                comando.Parameters.AddWithValue("@suc_local", "S");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void modificarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();

                string query = $"UPDATE {ConexionEquipo}.sucursales SET suc_manual = @suc_manual WHERE suc_codigo = @suc_codigo";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);
                comando.Parameters.AddWithValue("@suc_manual", _suc_manual);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la sucursal: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }






}
