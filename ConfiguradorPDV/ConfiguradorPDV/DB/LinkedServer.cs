using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConfiguradorPDV.DB;
using System.Windows.Forms;

namespace ConfiguradorPDV.DB
{
    public class LinkedServer
    {

        Factory factory;
        public LinkedServer(Factory factory)
        {
            this.factory = factory;
        }

        public void CrearLinkedServer(string clave, string nombreLinked)
        {
            try
            {
                AccesoDatos accesoDatos = factory.ObtenerConexion();

                string queryLinkedServer = $@"
                EXEC sp_addlinkedserver 
                @server = '{nombreLinked}', 
                @srvproduct = N'SQL Server';

                EXEC sp_addlinkedsrvlogin 
                @rmtsrvname = '{nombreLinked}', 
                @useself = 'false', 
                @locallogin = NULL, 
                @rmtuser = 'sa', 
                @rmtpassword = '{clave}';
                ";

                SqlCommand comando = accesoDatos.PrepararConsulta(queryLinkedServer);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



    }
}
