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
    public class Depositos
    {
        Factory _conexion;
        string _dep_codigo;
        string _dep_descripcion;
        string _dep_nombre;
        string _catdgi_codigo;
        string _provin_codigo;
        int _planning;
        string _suc_codigo;
        string _dep_quienlove;

        public Depositos(

            Factory conexion,
            string dep_codigo = null,
            string dep_descripcion = null,
            string dep_nombre = null,
            string catdgi_codigo = null,
            string provin_codigo = null,
            int planning = 0,
            string suc_codigo = null,
            string dep_quienlove = null)
        {
            _conexion = conexion;
            _dep_codigo = dep_codigo;
            _dep_descripcion = dep_descripcion;
            _dep_nombre = dep_nombre;
            _catdgi_codigo = catdgi_codigo;
            _provin_codigo = provin_codigo;
            _planning = planning;
            _suc_codigo = suc_codigo;
            _dep_quienlove = dep_quienlove;
        }

        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (dep_codigo) FROM {ConexionEquipo}.depositos  WHERE dep_codigo = @dep_codigo ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@dep_codigo", _dep_codigo);
            
            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["dep_codigo"].ToString();
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
                 INSERT INTO {ConexionEquipo}.depositos
                     (
                         [DEP_CODIGO]
                        ,[DEP_DESCRIPCION]
                        ,[DEP_NOMBRE]
                        ,[CATDGI_CODIGO]
                        ,[PROVIN_CODIGO]
                        ,[planning]
                        ,[SUC_CODIGO]
                        ,[DEP_QUIENLOVE]
                      )
                 VALUES 
                     (
                         @dep_codigo,
                         @dep_descripcion,
                         @dep_nombre,
                         @catdgi_codigo,
                         @provin_codigo,
                         @planning,
                         @suc_codigo,
                         @dep_quienlove
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@dep_codigo", _dep_codigo);
                comando.Parameters.AddWithValue("@dep_descripcion", _dep_codigo);
                comando.Parameters.AddWithValue("@dep_nombre", _dep_codigo);
                comando.Parameters.AddWithValue("@catdgi_codigo", "I");
                comando.Parameters.AddWithValue("@provin_codigo", "");
                comando.Parameters.AddWithValue("@planning", 0);
                comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);
                comando.Parameters.AddWithValue("@dep_quienlove", ",,");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el Depositos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
