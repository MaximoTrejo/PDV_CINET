using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConfiguradorPDV.DB;

namespace ConfiguradorPDV.DB
{
    public class LinkedServer
    {

        Factory factory;
        public LinkedServer(Factory factory)
        {
            this.factory = factory;
        }

        public int CrearLinkedServer(string clave, string nombreLinked)
        {
            int exito = 1;

            try
            {
                AccesoDatos accesoDatos = factory.ObtenerConexion();

                string queryLinkedServer = $@"
                EXEC sp_addlinkedserver 
                @server = {nombreLinked}, 
                @srvproduct = N'SQL Server';
                EXEC sp_addlinkedsrvlogin 
                @rmtsrvname = {nombreLinked}, 
                @useself = 'false', 
                @locallogin = NULL, 
                @rmtuser = 'sa', 
                @rmtpassword = {clave};
                ";

                SqlCommand comando = accesoDatos.PrepararConsulta(queryLinkedServer);
                SqlDataReader reader = comando.ExecuteReader();
                reader.Close();

            }
            catch (Exception ex)
            {
                
                exito = 0;
            }

            return exito;
        }



    }
}
