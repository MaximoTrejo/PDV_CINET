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
    public class comprobantes_d
    {
        Factory _conexion;
        string _cbtee_codigo;
        string _cbtee_modulo;
        string _cpto_codigo;
        string _cbted_formula;

        public comprobantes_d(Factory conexion, 
            string cbtee_codigo = null,
            string cbtee_modulo=null,
            string cpto_codigo=null,
            string cbted_formula=null)
        {
            _conexion = conexion;
            _cbtee_codigo = cbtee_codigo;
            _cbtee_modulo = cbtee_modulo;
            _cpto_codigo = cpto_codigo;
            _cbted_formula = cbted_formula;
        }

        public void eliminarUno(string ConexionEquipo)
        {
            AccesoDatos accesoDatos = _conexion.ObtenerConexion();
            string query = $"delete {ConexionEquipo}.comprobantes_d WHERE CBTEE_CODIGO = @comprobante AND CBTEE_MODULO = @modulo AND CPTO_CODIGO = @concepto";
            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@comprobante", _cbtee_codigo);
            comando.Parameters.AddWithValue("@modulo", _cbtee_modulo);
            comando.Parameters.AddWithValue("@concepto", _cpto_codigo);
            comando.ExecuteNonQuery();

        }

        public void modificarFormula(string ConexionEquipo)
        {
           
            AccesoDatos accesoDatos = _conexion.ObtenerConexion();
            
            string query = $"UPDATE {ConexionEquipo}.comprobantes_d SET cbted_formula = @formula   WHERE CBTEE_CODIGO = @comprobante AND CBTEE_MODULO = @modulo AND CPTO_CODIGO = @concepto";
            
            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@comprobante", _cbtee_codigo);
            comando.Parameters.AddWithValue("@modulo", _cbtee_modulo);
            comando.Parameters.AddWithValue("@concepto", _cpto_codigo);
            comando.Parameters.AddWithValue("@formula", _cbted_formula);

            comando.ExecuteNonQuery();
           
        }

        public void insertarUno(string ConexionEquipo)
        {
            try
            {
                AccesoDatos accesoDatos = _conexion.ObtenerConexion();
                string query = $@"insert into {ConexionEquipo}.comprobantes_d ([CBTEE_CODIGO]
                                 ,[CBTEE_MODULO]
                                 ,[CPTO_CODIGO]
                                 ,[CBTED_FORMULA]
                                 ,[CBTED_ORDEN]
                                 ,[CBTED_PIE]
                                 ,[CBTED_CONDICION]
                                 ,[CBTED_PORCE]) values (@comprobante,@modulo,@concepto@formula,@orden,@pie,@condicion,@porcentaje)";
                SqlCommand comando = accesoDatos.PrepararConsulta(query);
                comando.Parameters.AddWithValue("@comprobante", _cbtee_codigo);
                comando.Parameters.AddWithValue("@modulo", _cbtee_modulo);
                comando.Parameters.AddWithValue("@concepto", _cpto_codigo);
                comando.Parameters.AddWithValue("@formula", _cbted_formula);
                comando.Parameters.AddWithValue("@orden","8");
                comando.Parameters.AddWithValue("@pie", "N");
                comando.Parameters.AddWithValue("@condicion", ".T.");
                comando.Parameters.AddWithValue("@porcentaje", "0.00");

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar el comprobante (D): " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
