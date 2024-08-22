using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System.Data.SqlClient;
using System.Data;

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
                 DECLARE @ULTPDV VARCHAR(10); SET @ULTPDV = (select para_valor from {ConexionEquipo}.PARAMETROS where PARA_CODIGO = 'VTAPUNTO'); 
                 UPDATE {ConexionEquipo}.CIERRE_CAJA_D SET CIECAJA_VTAPTO = @ULTPDV where CIECAJA_VTAPTO <> '9999'; 
                 UPDATE {ConexionEquipo}.CIERRE_CAJA_E SET CIECAJA_VTAPTO = @ULTPDV; 
                 update {ConexionEquipo}.COMPROBANTES_N set CBTEN_NUMERO = 0 where suc_codigo = @ULTPDV;";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.ExecuteReader();

            return exito;
        }





        public string LimpiarPDV()
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            string exito = "NE";

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $@"
                delete {ConexionEquipo}.ven_aplicacion; 
                delete {ConexionEquipo}.ventas_d; 
                delete {ConexionEquipo}.ventas_t; 
                delete {ConexionEquipo}.ingresos_d; 
                delete {ConexionEquipo}.val_movimientos; 
                delete {ConexionEquipo}.ingresos_E; 
                delete {ConexionEquipo}.ventas_e; 
                DELETE {ConexionEquipo}.COMPRAS_T; 
                DELETE {ConexionEquipo}.COMPRAS_D; 
                DELETE {ConexionEquipo}.COMPRAS_E; 
                delete {ConexionEquipo}.asientos_d where asi_numero <> '0'; 
                delete {ConexionEquipo}.asientos_e where asi_numero <> '0'; 
                delete {ConexionEquipo}.EGRESOS_D; delete EGRESOS_E; 
                delete {ConexionEquipo}.stock; delete cupredimido; 
                delete {ConexionEquipo}.VENTAS_PRM; 
                delete {ConexionEquipo}.librocaja; 
                delete {ConexionEquipo}.aya; 
                delete {ConexionEquipo}.zeta_e; 
                delete {ConexionEquipo}.hparamloc; 
                delete {ConexionEquipo}.auditoriaoperaciones;
                delete {ConexionEquipo}.auditoria; 
                delete {ConexionEquipo}.LPOperaciones; 
                delete {ConexionEquipo}.LPLOTE;
                delete {ConexionEquipo}.VAL_MOVIMIENTOS; 
                DELETE {ConexionEquipo}.cupones; 
                DELETE {ConexionEquipo}.CPRAS_CTACTE; 
                DELETE {ConexionEquipo}.Pauto_cancel; 
                delete {ConexionEquipo}.CPRA_IMPUTACION; 
                delete from {ConexionEquipo}.ventas_t;
                delete from {ConexionEquipo}.ventas_d; 
                delete from {ConexionEquipo}.ventas_e; 
                delete {ConexionEquipo}.COMPRAS_D; 
                delete {ConexionEquipo}.COMPRAS_T; 
                delete {ConexionEquipo}.COMPRAS_E; 
                delete {ConexionEquipo}.ASIENTOS_D; 
                delete {ConexionEquipo}.ASIENTOS_E WHERE ASI_NUMERO <> 0; 
                delete {ConexionEquipo}.VAL_MOVIMIENTOS; 
                delete FROM {ConexionEquipo}.VAL_COTIZACION where VCOT_FECHA <> (select max(VCOT_FECHA) from VAL_COTIZACION); 
                delete from {ConexionEquipo}.LIBROCAJA; 
                delete {ConexionEquipo}.equis; 
                delete {ConexionEquipo}.ZETA_E; 
                delete {ConexionEquipo}.hven; 
                delete {ConexionEquipo}.itemscancelados;
                delete {ConexionEquipo}.cupredimido; 
                delete {ConexionEquipo}.EVENTOS; 
                delete {ConexionEquipo}.fiscalctrol; 
                delete {ConexionEquipo}.HParamLoc; 
                delete {ConexionEquipo}.Acomanda;
                
                DECLARE @ULTPDV VARCHAR(10);SET @ULTPDV = (SELECT para_valor FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'VTAPUNTO');
                DECLARE @ULTCIERRE VARCHAR(10); SET @ULTCIERRE = (SELECT MAX(CIECAJA_NUMEROCIERRE) FROM {ConexionEquipo}.cierre_caja_e WHERE CIECAJA_FECHA IS NOT NULL);
                
                DELETE FROM {ConexionEquipo}.CIERRE_CAJA_D WHERE CIECAJA_NUMEROCIERRE != @ULTCIERRE  
                DELETE FROM {ConexionEquipo}.CIERRE_CAJA_E WHERE CIECAJA_NUMEROCIERRE != @ULTCIERRE  
                
                BEGIN TRY 
                DROP TABLE #cierre1;
                END TRY BEGIN CATCH END CATCH;
                
                SELECT * INTO #cierre1 FROM {ConexionEquipo}.CIERRE_CAJA_E;
                UPDATE #cierre1 SET CIECAJA_NUMEROCIERRE = 1; 
                
                BEGIN TRY 
                INSERT INTO {ConexionEquipo}.CIERRE_CAJA_E 
                SELECT * FROM #cierre1; 
                END TRY BEGIN CATCH END CATCH; 
                
                BEGIN TRY 
                DROP TABLE #cierre1; 
                END TRY BEGIN CATCH END CATCH; 
                
                UPDATE {ConexionEquipo}.CIERRE_CAJA_D SET CIECAJA_NUMEROCIERRE = '1'; 
                UPDATE {ConexionEquipo}.CIERRE_CAJA_D SET CIECAJA_VTAPTO = @ULTPDV where CIECAJA_VTAPTO != '9999'; 
                DELETE FROM {ConexionEquipo}.CIERRE_CAJA_E WHERE CIECAJA_NUMEROCIERRE <> '1'; 
                DELETE FROM {ConexionEquipo}.CIERRE_CAJA_D WHERE CIECAJA_NUMEROCIERRE <> '1'; 
                UPDATE {ConexionEquipo}.CIERRE_CAJA_E SET CIECAJA_VTAPTO = @ULTPDV; 
                UPDATE {ConexionEquipo}.PARAMETROS SET PARA_VALOR = '1' WHERE PARA_CODIGO = 'ULTCIERREC'; 

                 ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.ExecuteReader();

            return exito;
        }



        public void eliminarSucursalesInactivas()
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $@"
                            DELETE FROM {ConexionEquipo}.COMPROBANTES_N
                            WHERE NOT EXISTS (
                                SELECT 1
                                FROM ventas_e ve
                                WHERE ve.SUC_CODIGO = COMPROBANTES_N.suc_codigo
                            ) 
                            AND SUC_CODIGO NOT IN (
                                SELECT para_valor
                                FROM PARAMETROS
                                WHERE para_codigo IN ('vtapunto', 'PTOVTAMAN')
                            );
                            
                            
                            DELETE FROM {ConexionEquipo}.SUCURSALES
                            WHERE NOT EXISTS (
                                SELECT 1
                                FROM ventas_e ve
                                WHERE ve.SUC_CODIGO = SUCURSALES.suc_codigo
                            ) 
                            AND SUC_CODIGO NOT IN (
                                SELECT para_valor
                                FROM PARAMETROS
                                WHERE para_codigo IN ('vtapunto', 'PTOVTAMAN')
                            );
                            ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.ExecuteReader();

        }


        public void CorregirCorrelatividad()
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            AccesoDatos accesoDatos = _conexion.ObtenerConexion();

            string query = $@"
                
                UPDATE {ConexionEquipo}.COMPROBANTES_N
                SET cbten_numero = COALESCE((
                    SELECT CAST(MAX(VENE_NUMERO) AS INT)
                    FROM {ConexionEquipo}.ventas_e ve
                    WHERE ve.cbtee_codigo = COMPROBANTES_N.cbtee_codigo
                    AND ve.SUC_CODIGO = (SELECT PARA_VALOR FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'PTOVTAMAN')
                ), 0)
                WHERE cbtee_codigo IN (
                    SELECT cbtee_codigo
                    FROM {ConexionEquipo}.COMPROBANTES_N
                    WHERE SUC_CODIGO = (SELECT PARA_VALOR FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'PTOVTAMAN')
                )and SUC_CODIGO = (SELECT PARA_VALOR FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'PTOVTAMAN');
                
                
                UPDATE {ConexionEquipo}.COMPROBANTES_N
                SET cbten_numero = COALESCE((
                    SELECT CAST(MAX(VENE_NUMERO) AS INT)
                    FROM {ConexionEquipo}.ventas_e ve
                    WHERE ve.cbtee_codigo = COMPROBANTES_N.cbtee_codigo
                    AND ve.SUC_CODIGO = (SELECT PARA_VALOR FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'VTAPUNTO')
                ), 0)
                WHERE cbtee_codigo IN (
                    SELECT cbtee_codigo
                    FROM {ConexionEquipo}.COMPROBANTES_N
                    WHERE SUC_CODIGO = (SELECT PARA_VALOR FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'VTAPUNTO')
                )and SUC_CODIGO = (SELECT PARA_VALOR FROM {ConexionEquipo}.PARAMETROS WHERE PARA_CODIGO = 'VTAPUNTO');


            ";

            SqlCommand comando = accesoDatos.PrepararConsulta(query);

            comando.ExecuteReader();
        }


    }
}
