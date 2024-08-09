using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;

namespace ConfiguradorPDV.Controllers
{
    public class clientes_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public clientes_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }


        public void modificarClientes(string pdv)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            clientes clientes = new clientes(_conexion,suc_codigo: pdv);

            clientes.modificarSucursalClientes(ConexionEquipo);

        }
    }
}
