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
    public class Periodos
    {
        Factory _conexion;
        string _peri_codigo;
        DateTime _peri_desde;
        DateTime _peri_hasta;
        decimal _peri_ultasi;
        string _peri_default;

        public Periodos(

            Factory conexion,
            string peri_codigo = null,
            DateTime peri_desde = default(DateTime),
            DateTime peri_hasta = default(DateTime),
            decimal peri_ultasi = 0m,
            string peri_default = null)
        {
            _conexion = conexion;
            _peri_codigo = peri_codigo;
            _peri_desde = peri_desde;
            _peri_hasta = peri_hasta;
            _peri_ultasi = peri_ultasi;
            _peri_default = peri_default;
        }


        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (peri_codigo) FROM {ConexionEquipo}.periodos  WHERE peri_codigo = @peri_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@peri_codigo", _peri_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["peri_codigo"].ToString();
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
                 INSERT INTO {ConexionEquipo}.periodos 
                     (
                        [PERI_CODIGO]
                        ,[PERI_DESCRIPCION]
                        ,[PERI_DESDE]
                        ,[PERI_HASTA]
                        ,[PERI_ULTASI]
                        ,[PERI_DEFAULT]
                    )
                          VALUES 
                     (
                         @peri_codigo,
                         @peri_descripcion,
                         @peri_desde,
                         @peri_hasta,
                         @peri_ultasi,
                         @peri_default
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@peri_codigo", _peri_codigo);
                comando.Parameters.AddWithValue("@peri_descripcion", _peri_codigo);
                comando.Parameters.AddWithValue("@peri_desde", DateTime.Now);
                comando.Parameters.AddWithValue("@peri_hasta", DateTime.Now);
                comando.Parameters.AddWithValue("@peri_ultasi", "2000");
                comando.Parameters.AddWithValue("@peri_default", "S");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Periodo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void deshailitarPeriodos(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $@"
                        UPDATE  {ConexionEquipo}.periodos 
                            set peri_default = 'N' 
                            where peri_codigo != @peri_codigo
                        ";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@peri_codigo", _peri_codigo);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el Periodo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
