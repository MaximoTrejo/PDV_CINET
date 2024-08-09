using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using System.Data.SqlClient;

namespace ConfiguradorPDV.Modelo
{
    public class clientes
    {

        Factory _conexion;
        string _cli_codigo;
        string _provid_codigo;
        string _catdgi_codigo;
        string _vene_codigo;
        string _plan_codigo;
        string _cli_lglnombre;
        string _cli_lglcuit;
        string _lisp_codigo;
        string _fpag_codigo;
        string _cli_telefonos;
        string _suc_codigo;
        string _cobdor_codigo;
        decimal _cli_limitecred;
        string _estacli_codigo;
        int _cli_abono;
        string _cli_mesasabono;
        int _cli_acuccuds;
        int __cli_acuchuds;
        int _cli_acuccud;
        int _cli_porcevaluaremito;
        int _cli_acudiascc;
        int _cli_acudiasch;
        int _cli_acuinventario;
        int _ciecaja_numerocierre;
        int _cli_acuccvenc;
        int _cli_porceiibb;

        public clientes
        (
            Factory conexion,
            string cli_codigo = "",
            string provid_codigo = "",
            string catdgi_codigo = "",
            string vene_codigo = "",
            string plan_codigo = "",
            string cli_lglnombre = "",
            string cli_lglcuit = "",
            string lisp_codigo = "",
            string fpag_codigo = "",
            string cli_telefonos = "",
            string suc_codigo = "",
            string cobdor_codigo = "",
            decimal cli_limitecred = 0,
            string estacli_codigo = "",
            int cli_abono = 0,
            string cli_mesasabono = "",
            int cli_acuccuds = 0,
            int cli_acuchuds = 0,
            int cli_acuccud = 0,
            int cli_porcevaluaremito = 0,
            int cli_acudiascc = 0,
            int cli_acudiasch = 0,
            int cli_acuinventario = 0,
            int ciecaja_numerocierre = 0,
            int cli_acuccvenc = 0,
            int cli_porceiibb = 0

        )
        
        {
            _conexion = conexion;
            _cli_codigo = cli_codigo;
            _provid_codigo = provid_codigo;
            _catdgi_codigo = catdgi_codigo;
            _vene_codigo = vene_codigo;
            _plan_codigo = plan_codigo;
            _cli_lglnombre = cli_lglnombre;
            _cli_lglcuit = cli_lglcuit;
            _lisp_codigo = lisp_codigo;
            _fpag_codigo = fpag_codigo;
            _cli_telefonos = cli_telefonos;
            _suc_codigo = suc_codigo;
            _cobdor_codigo = cobdor_codigo;
            _cli_limitecred = cli_limitecred;
            _estacli_codigo = estacli_codigo;
            _cli_abono = cli_abono;
            _cli_mesasabono = cli_mesasabono;
            _cli_acuccuds = cli_acuccuds;
            __cli_acuchuds = cli_acuchuds;
            _cli_acuccud = cli_acuccud;
            _cli_porcevaluaremito = cli_porcevaluaremito;
            _cli_acudiascc = cli_acudiascc;
            _cli_acudiasch = cli_acudiasch;
            _cli_acuinventario = cli_acuinventario;
            _ciecaja_numerocierre = ciecaja_numerocierre;
            _cli_acuccvenc = cli_acuccvenc;
            _cli_porceiibb = cli_porceiibb;
        }

        public string modificarSucursalClientes(string ConexionEquipo)
        {
            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $"UPDATE {ConexionEquipo}.clientes set suc_codigo = @suc_codigo";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@suc_codigo", _suc_codigo);

            comando.ExecuteReader();

            return exito;
        }



    }
}
