using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class datos_empresa_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public datos_empresa_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void modificarDatoEmpresa(string parametro, string valor)
        {

            string ConexionEquipo = _equipo.VerificarLinkedServer();

            datos_empresa datos_Empresa = new datos_empresa(_conexion , parametro , valor);
            

            string existeDato = datos_Empresa.traerUno(ConexionEquipo);

            if (existeDato != "NE")
            {
                datos_Empresa.modificarUno(ConexionEquipo);
            }
            else
            {
                datos_Empresa.insertarUno(ConexionEquipo);
            }

        }
    }
}
