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
    public class Asientos_E
    {
        Factory _conexion;
        string _peri_codigo;
        decimal _asi_numero;
        string _tipoasi_codigo;
        string _asi_leyenda;
        DateTime _asi_fecha;
        short _asi_numerocierre;
        string _suc_codigo;
        decimal _asi_cierrecaja;
        decimal _asi_cotiz;
        string _cco_codigo;

        public Asientos_E(

            Factory conexion,
            string peri_codigo = null,
            decimal asi_numero = 0,
            string tipoasi_codigo = null,
            string asi_leyenda = null,
            DateTime asi_fecha = default(DateTime),
            short asi_numerocierre = 0,
            string suc_codigo = null,
            decimal asi_cierrecaja = 0,
            decimal asi_cotiz = 0,
            string cco_codigo = null)
        {
            _conexion = conexion;
            _peri_codigo = peri_codigo;
            _asi_numero = asi_numero;
            _tipoasi_codigo = tipoasi_codigo;
            _asi_leyenda = asi_leyenda;
            _asi_fecha = asi_fecha;
            _asi_numerocierre = asi_numerocierre;
            _suc_codigo = suc_codigo;
            _asi_cierrecaja = asi_cierrecaja;
            _asi_cotiz = asi_cotiz;
            _cco_codigo = cco_codigo;
        }

        public string BuscarUno(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"SELECT distinct (PERI_CODIGO) FROM {ConexionEquipo}.asientos_E  WHERE peri_codigo = @peri_codigo and suc_codigo = @suc_codigo and asi_numero = '0' ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@peri_codigo", _peri_codigo);
            comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                exito = reader["PERI_CODIGO"].ToString();
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
                 INSERT INTO {ConexionEquipo}.asientos_e 
                     (
                         [PERI_CODIGO],
                         [ASI_NUMERO],
                         [TIPOASI_CODIGO],
                         [ASI_LEYENDA],
                         [ASI_FECHA],
                         [ASI_NUMEROCIERRE],
                         [SUC_CODIGO],
                         [ASI_CIERRECAJA],
                         [ASI_COTIZ],
                         [CCO_CODIGO]
                     ) 
                 VALUES 
                     (
                         @peri_codigo,
                         @asi_numero,
                         @tipoasi_codigo,
                         @asi_leyenda,
                         @asi_fecha,
                         @asi_numerocierre,
                         @suc_codigo,
                         @asi_cierrecaja,
                         @asi_cotiz,
                         @cco_codigo
                     )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@peri_codigo", _peri_codigo);
                comando.Parameters.AddWithValue("@asi_numero", 0);
                comando.Parameters.AddWithValue("@tipoasi_codigo", "OTROS");
                comando.Parameters.AddWithValue("@asi_leyenda", ".");
                comando.Parameters.AddWithValue("@asi_fecha", DateTime.Now);
                comando.Parameters.AddWithValue("@asi_numerocierre", 0);
                comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);
                comando.Parameters.AddWithValue("@asi_cierrecaja", 0);
                comando.Parameters.AddWithValue("@asi_cotiz", 1);
                comando.Parameters.AddWithValue("@cco_codigo", "");
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el asiento_e: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


