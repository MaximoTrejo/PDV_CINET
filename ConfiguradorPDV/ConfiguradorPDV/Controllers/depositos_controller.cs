using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguradorPDV.Controllers
{
    public class depositos_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public depositos_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }

        public void insertarDeposito(string deposito, string sucursal)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            Depositos depositos = new Depositos(_conexion, deposito, suc_codigo: sucursal);

            string existe = depositos.BuscarUno(ConexionEquipo);

            if (existe == "NE")
            {
                depositos.insertarUno(ConexionEquipo);
            }

        }
    }
}
