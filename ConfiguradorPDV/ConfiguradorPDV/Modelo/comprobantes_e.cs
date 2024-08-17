using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConfiguradorPDV.DB;
using System.Windows.Forms;

namespace ConfiguradorPDV.Modelo
{
    public class comprobantes_e
    {
        Factory _conexion;
        string _cbtee_codigo;
        string _cbtee_modulo;
        string _cbtee_descripcion;
        string _cbtee_padre;
        string _cbtee_vaalibro;
        string _cbtee_vaactacte;
        string _cbtee_vaastock;
        string _cbtee_coddgi;
        string _cbtee_signoctacte;
        string _cbtee_sgnostock;
        string _cbtee_signolibro;
        int _cbtee_nivelaplic;
        string _cbtee_enlibroes;
        string _cbtee_detotal;
        string _cbtee_lote;
        string _cbtee_ivaenprecio;
        string _cbtee_monimpre;
        string _cbtee_enrecibo;
        string _cbtee_vaasiento;
        string _cbtee_cuit0;
        string _cbtee_vesstock;
        string _cbtee_numauto;
        int _cbtee_mpe;
        string _cbtee_moncta;



        public comprobantes_e
        (
            Factory conexion,
            string cbtee_codigo = "",
            string cbtee_modulo = "",
            string cbtee_descripcion = ""       ,
            string cbtee_padre = "",
            string cbtee_vaalibro = "",
            string cbtee_vaactacte= "",
            string cbtee_vaastock = "",
            string cbtee_coddgi = "",
            string cbtee_signoctacte = "",
            string cbtee_sgnostock = "",
            string cbtee_signolibro = "",
            int cbtee_nivelaplic = 0,
            string cbtee_enlibroes = "",
            string cbtee_detotal = "",
            string cbtee_lote = "",
            string cbtee_ivaenprecio = "",
            string cbtee_monimpre = "",
            string cbtee_enrecibo = "",
            string cbtee_vaasiento = "",
            string cbtee_cuit0 = "",
            string cbtee_vesstock = "",
            string cbtee_numauto = "",
            int cbtee_mpe = 0,
            string cbtee_moncta = ""
        )
        {
            _conexion = conexion;
            _cbtee_codigo = cbtee_codigo;
            _cbtee_modulo = cbtee_modulo;
            _cbtee_descripcion = cbtee_descripcion;
            _cbtee_padre = cbtee_padre;
            _cbtee_vaalibro = cbtee_vaalibro;
            _cbtee_vaactacte = cbtee_vaactacte;
            _cbtee_vaastock = cbtee_vaastock;
            _cbtee_coddgi = cbtee_coddgi;
            _cbtee_signoctacte = cbtee_signoctacte;
            _cbtee_sgnostock = cbtee_sgnostock;
            _cbtee_signolibro = cbtee_signolibro;
            _cbtee_nivelaplic = cbtee_nivelaplic;
            _cbtee_enlibroes = cbtee_enlibroes;
            _cbtee_detotal = cbtee_detotal;
            _cbtee_lote = cbtee_lote;
            _cbtee_ivaenprecio = cbtee_ivaenprecio;
            _cbtee_monimpre = cbtee_monimpre;
            _cbtee_enrecibo = cbtee_enrecibo;
            _cbtee_vaasiento = cbtee_vaasiento;
            _cbtee_cuit0 = cbtee_cuit0;
            _cbtee_vesstock = cbtee_vesstock;
            _cbtee_numauto = cbtee_numauto;
            _cbtee_mpe = cbtee_mpe;
            _cbtee_moncta = cbtee_moncta;
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



        public void insertarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $@"
                     INSERT INTO {ConexionEquipo}.comprobantes_e
                         (
                          [CBTEE_CODIGO]
                          ,[CBTEE_MODULO]
                          ,[CBTEE_DESCRIPCION]
                          ,[CBTEE_PADRE]
                          ,[CBTEE_VAALIBRO]
                          ,[CBTEE_VAACTACTE]
                          ,[CBTEE_VAASTOCK]
                          ,[CBTEE_CODDGI]
                          ,[CBTEE_SIGNOCTACTE]
                          ,[CBTEE_SIGNOSTOCK]
                          ,[CBTEE_SIGNOLIBRO]
                          ,[CBTEE_NIVELAPLIC]
                          ,[CBTEE_ENLIBROES]
                          ,[CBTEE_DETOTAL]
                          ,[CBTEE_LOTE]
                          ,[CBTEE_IVAENPRECIO]
                          ,[CBTEE_MONIMPRE]
                          ,[CBTEE_ESRECIBO]
                          ,[CBTEE_VAASIENTO]
                          ,[CBTEE_CUIT0]
                          ,[CBTEE_VESTOCK]
                          ,[CBTEE_NUMAUTO]
                          ,[CBTEE_MPE]
                          ,[CBTEE_MONCTA]
                          )
                     VALUES 
                         (
                          @cbtee_codigo
                         ,@cbtee_modulo
                         ,@cbtee_descripcion
                         ,@cbtee_padre
                         ,@cbtee_vaalibro
                         ,@cbtee_vaactacte
                         ,@cbtee_vaastock
                         ,@cbtee_coddgi
                         ,@cbtee_signoctacte
                         ,@cbtee_signostock
                         ,@cbtee_signolibro
                         ,@cbtee_nivelaplic
                         ,@cbtee_enlibroes
                         ,@cbtee_detotal
                         ,@cbtee_lote
                         ,@cbtee_ivaenprecio
                         ,@cbtee_monimpre
                         ,@cbtee_esrecibo
                         ,@cbtee_vaasiento
                         ,@cbtee_cuit0
                         ,@cbtee_vesstock
                         ,@cbtee_numauto
                         ,@cbtee_mpe
                         ,@cbtee_moncta
                         )";

                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@cbtee_codigo", _cbtee_codigo);
                comando.Parameters.AddWithValue("@cbtee_modulo", _cbtee_modulo); 
                comando.Parameters.AddWithValue("@cbtee_descripcion", _cbtee_descripcion);
                comando.Parameters.AddWithValue("@cbtee_padre", _cbtee_padre);
                comando.Parameters.AddWithValue("@cbtee_vaalibro", _cbtee_vaalibro);
                comando.Parameters.AddWithValue("@cbtee_vaactacte", _cbtee_vaactacte);
                comando.Parameters.AddWithValue("@cbtee_vaastock", _cbtee_vaastock);
                comando.Parameters.AddWithValue("@cbtee_coddgi", _cbtee_coddgi);
                comando.Parameters.AddWithValue("@cbtee_signoctacte", _cbtee_signoctacte);
                comando.Parameters.AddWithValue("@cbtee_signostock", _cbtee_sgnostock);
                comando.Parameters.AddWithValue("@cbtee_signolibro", _cbtee_signolibro);
                comando.Parameters.AddWithValue("@cbtee_nivelaplic", _cbtee_nivelaplic);
                comando.Parameters.AddWithValue("@cbtee_enlibroes", _cbtee_enlibroes);
                comando.Parameters.AddWithValue("@cbtee_detotal", _cbtee_detotal);
                comando.Parameters.AddWithValue("@cbtee_lote", _cbtee_lote);
                comando.Parameters.AddWithValue("@cbtee_ivaenprecio", _cbtee_ivaenprecio);
                comando.Parameters.AddWithValue("@cbtee_monimpre", _cbtee_monimpre);
                comando.Parameters.AddWithValue("@cbtee_esrecibo", _cbtee_enrecibo);
                comando.Parameters.AddWithValue("@cbtee_vaasiento", _cbtee_vaasiento);
                comando.Parameters.AddWithValue("@cbtee_cuit0", _cbtee_cuit0);
                comando.Parameters.AddWithValue("@cbtee_vesstock", _cbtee_vesstock);
                comando.Parameters.AddWithValue("@cbtee_numauto", _cbtee_numauto);
                comando.Parameters.AddWithValue("@cbtee_mpe", _cbtee_mpe);
                comando.Parameters.AddWithValue("@cbtee_moncta", _cbtee_moncta);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el comprobantes_e: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
