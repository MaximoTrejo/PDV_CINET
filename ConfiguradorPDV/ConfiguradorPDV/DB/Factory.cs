using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;

namespace ConfiguradorPDV.DB
{

    public class Factory
    {
        private string server;
        private string port;
        private string database;
        private string password;

        public Factory(string server, string port, string database, string password)
        {
            this.server = server;
            this.port = port;
            this.database = database;
            this.password = password;
        }

        public AccesoDatos ObtenerConexion()
        {
            return AccesoDatos.ObtenerInstancia(server, port, database, password);
        }


    }
}
