using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfiguradorPDV.Controllers
{
    public class parametros_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public parametros_controller(Factory conexion ,LinkedServer linked)
        {
            _conexion = conexion;
            _equipo = linked;
        }


        public string TraerValorParametro(string parametro)
        {
            string exito;
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            Parametros parametros = new Parametros(_conexion,parametro);
            exito = parametros.traerUno(ConexionEquipo);
            return exito;
        }

        public void eliminarParametro(string parametro)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();
            Parametros parametros = new Parametros(_conexion, parametro);
            parametros.eliminarUno(ConexionEquipo);
        }

        public void modificarParametros(string parametro , string descrpcion,string valor)
        {
            
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            Parametros parametros = new Parametros(_conexion, parametro,descrpcion, valor);

            string existeParametro = parametros.traerUno(ConexionEquipo);

            if (existeParametro != "NE")
            {
                parametros.modificarUno(ConexionEquipo);
            }
            else
            {
                parametros.insertarUno(ConexionEquipo);
            }

        }
    }
}
