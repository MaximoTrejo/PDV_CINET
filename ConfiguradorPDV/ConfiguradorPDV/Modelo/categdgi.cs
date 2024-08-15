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

        public void modificarUno(string ConexionEquipo ,string codigo, string comprobante)
        {

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"UPDATE {ConexionEquipo}.categdgi SET catdgi_cbtexdefa = @comprobante WHERE catdgi_codigo = @codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@comprobante", comprobante);

            comando.ExecuteNonQuery();
        }
    }
}
