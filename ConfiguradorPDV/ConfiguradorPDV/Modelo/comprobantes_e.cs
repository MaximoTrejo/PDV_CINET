using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConfiguradorPDV.DB;

namespace ConfiguradorPDV.Modelo
{
    public class comprobantes_e
    {
        Factory _conexion;
        

        public comprobantes_e(Factory conexion)
        {
            _conexion = conexion;
            
        }

        public int BuscarComprobante(string ConexionEquipo, string comprobante)
        {
            int exito = 0;

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT count(*) FROM {ConexionEquipo}.comprobantes_e  WHERE cbtee_codigo = @cbtee_codigo and cbtee_modulo ='VTAS' ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.Parameters.AddWithValue("@cbtee_codigo", comprobante);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader.GetInt32(0);
            }

            reader.Close();

            return exito;
        }



        public void modificarComprobantes(string ConexionEquipo , string comprobante , string codigo)
        {
            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"UPDATE {ConexionEquipo}.comprobantes_e SET cbtee_coddgi = @cbtee_coddgi where cbtee_codigo = @cbtee_codigo and cbtee_modulo ='VTAS'";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@cbtee_coddgi", codigo);
            comando.Parameters.AddWithValue("@cbtee_codigo", comprobante);

            comando.ExecuteReader();
        }

    }
}
