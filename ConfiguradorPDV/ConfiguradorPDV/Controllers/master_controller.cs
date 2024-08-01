using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ConfiguradorPDV.Controllers
{
    public class master_controller
    {
        Factory factory;

        public master_controller(Factory factory)
        {
            this.factory = factory;
        }


        public List<string> GetDB()
        {
            List<string> databases = new List<string>();

            AccesoDatos accesoDatos = factory.ObtenerConexion();

            try
            {
                SqlCommand comando = accesoDatos.PrepararConsulta("SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb', 'model', 'msdb');");
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    
                    string dbName = reader.GetString(0);
                    databases.Add(dbName);
                }

                reader.Close();
            }
            catch
            {
                MessageBox.Show("No es posible conectarse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return databases;
        }

        public DataTable GetEquipos()
        {
            DataTable dataTable = new DataTable();

            AccesoDatos accesoDatos = factory.ObtenerConexion();

            try
            {
                SqlCommand comando = accesoDatos.PrepararConsulta(@"
                    DECLARE @infoCaja TABLE(
    [caja] VARCHAR(2), 
    [equipo] VARCHAR(100), 
    [version] VARCHAR(100)
);

INSERT INTO @infoCaja
SELECT DISTINCT 
    caja, 
    LEFT(EQUIPO, CHARINDEX('#', EQUIPO) - 1) AS equipo, 
    valor 
FROM (
    SELECT 
        RANK() OVER(
            PARTITION BY caja, parametro
            ORDER BY fechatrans DESC
        ) AS rango, 
        *
    FROM hparamloc
    WHERE parametro = 'VERSION'
) AS query
WHERE rango = 1
ORDER BY equipo;

SELECT 
    vene_caja, 
    suc_codigo, 
    equipo
FROM (
    SELECT
        ROW_NUMBER() OVER(
            PARTITION BY v.vene_caja 
            ORDER BY v.vene_fecha DESC
        ) AS rn,
        v.vene_caja,
        v.suc_codigo,
        i.equipo
    FROM VENTAS_E v
    INNER JOIN @infoCaja i 
        ON v.vene_caja = i.caja COLLATE SQL_Latin1_General_CP1_CI_AS
    WHERE v.vene_caja != ''
) AS subquery
WHERE rn = 1
ORDER BY equipo;");

                SqlDataReader reader = comando.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro equipos " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

            return dataTable;
        }

    }
}
