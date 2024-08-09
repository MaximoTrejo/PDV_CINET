using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System.Data.SqlClient;

namespace ConfiguradorPDV.Controllers
{
    public class dataBase_controllers
    {

        Factory _conexion;
        LinkedServer _equipo;

        public dataBase_controllers(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public string ReorganizarCierre()
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $@"
                 DECLARE @ULTPDV VARCHAR(10); SET @ULTPDV = (SELECT para_valor FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'VTAPUNTO');
                 DECLARE @ULTCIERRE VARCHAR(10); SET @ULTCIERRE = (SELECT MAX(CIECAJA_NUMEROCIERRE) FROM {ConexionEquipo}.cierre_caja_e WHERE CIECAJA_FECHA IS NOT NULL);
                 
                 DELETE FROM {ConexionEquipo}.CIERRE_CAJA_D WHERE CIECAJA_NUMEROCIERRE<> @ULTCIERRE and CIECAJA_VTAPTO <> @ULTPDV  and CIECAJA_VTAPTO <> '9999' ;
                 DELETE FROM {ConexionEquipo}.CIERRE_CAJA_E WHERE CIECAJA_NUMEROCIERRE<> @ULTCIERRE and CIECAJA_VTAPTO<> @ULTPDV; 
                 
                 BEGIN TRY 
                 DROP TABLE #cierre1; 
                 END TRY BEGIN CATCH END CATCH; 
                 
                 SELECT * INTO #cierre1 FROM {ConexionEquipo}.CIERRE_CAJA_E; UPDATE #cierre1 SET CIECAJA_NUMEROCIERRE = 1; 
                 
                 BEGIN TRY 
                 INSERT INTO {ConexionEquipo}.CIERRE_CAJA_E SELECT * FROM #cierre1; 
                 END TRY BEGIN CATCH END CATCH; 
                 
                 
                 BEGIN TRY 
                 DROP TABLE #cierre1; 
                 END TRY BEGIN CATCH END CATCH; 
                 
                 UPDATE {ConexionEquipo}.CIERRE_CAJA_D SET CIECAJA_NUMEROCIERRE = '1';
                 UPDATE {ConexionEquipo}.CIERRE_CAJA_D SET CIECAJA_VTAPTO = @ULTPDV; 
                 DELETE FROM {ConexionEquipo}.CIERRE_CAJA_E WHERE CIECAJA_NUMEROCIERRE <> '1';
                 DELETE FROM {ConexionEquipo}.CIERRE_CAJA_D WHERE CIECAJA_NUMEROCIERRE <> '1' and CIECAJA_VTAPTO <> '9999'; 
                 UPDATE {ConexionEquipo}.CIERRE_CAJA_E SET CIECAJA_VTAPTO = @ULTPDV; 
                 UPDATE {ConexionEquipo}.PARAMETROS SET PARA_VALOR = '1' WHERE PARA_CODIGO = 'ULTCIERREC'; UPDATE COMPROBANTES_N SET CBTEN_NUMERO = 0;";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.ExecuteReader();

            return exito;
        }



    }
}
