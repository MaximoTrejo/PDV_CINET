using ConfiguradorPDV.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConfiguradorPDV.Controllers
{
    public class linkedServer_controller
    {
        Factory factory;

        public linkedServer_controller(Factory factory)
        {
            this.factory = factory;
        }


        public string TraerDatoParametroLinked(string parametro, string database, string equipo)
        {
            string exito = "NE";
            
                AccesoDatos accesoDatos = factory.ObtenerConexion();

                string linkedDatabase = $"{equipo}.{database}.dbo";

                string query = $"SELECT para_valor FROM {linkedDatabase}.parametros WHERE para_codigo = @parametro";
                
            SqlCommand comando = accesoDatos.PrepararConsulta(query);
            comando.Parameters.AddWithValue("@parametro", parametro);
            SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    exito = reader["para_valor"].ToString();
                }

                reader.Close();
                accesoDatos.CerrarConexion();
            

            return exito;
        }



    }
}
