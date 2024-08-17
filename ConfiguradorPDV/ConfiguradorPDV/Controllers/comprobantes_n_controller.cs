using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfiguradorPDV.Controllers
{
    public class comprobantes_n_controller
    {
        Factory _conexion;
        LinkedServer _equipo;
        parametros_controller _parametros_Controller;

        public comprobantes_n_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
            _parametros_Controller = new parametros_controller(conexion,equipo);
        }


        public void modificarComprobantes(string pdv ,int tipo)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            string sucAnterior = _parametros_Controller.TraerValorParametro("VTAPUNTO");

            comprobantes_n comprobantes_N = new comprobantes_n(_conexion, pdv);

            if (sucAnterior != "NE")
            {
                if (comprobantes_N.BuscarComprobantes(ConexionEquipo,sucAnterior) > 0 )
                {
                    if (tipo == 2)
                    {
                        comprobantes_N.editarComprobantesFE(ConexionEquipo,sucAnterior);
                    }
                    else
                    {
                        comprobantes_N.editarComprobantesCF(ConexionEquipo,sucAnterior);
                    }
                }
                else
                {
                    comprobantes_N.insertarUnoVtas(ConexionEquipo , "FAB");
                    comprobantes_N.insertarUnoVtas(ConexionEquipo, "FAA");
                    comprobantes_N.insertarUnoVtas(ConexionEquipo, "NCB");
                    comprobantes_N.insertarUnoVtas(ConexionEquipo, "NCA");
                }
            }
            else
            {
                MessageBox.Show("El parametro VTAPUNTO se encuentra vacio , no se encuentra la sucursal anterior");
            }


        }


        public void modificarComprobantesManuales(string pdv)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            string sucAnterior = _parametros_Controller.TraerValorParametro("PTOVTAMAN");

            comprobantes_n comprobantes_N = new comprobantes_n(_conexion, pdv);

            if (sucAnterior != "NE")
            {
                if (comprobantes_N.BuscarComprobantes(ConexionEquipo, sucAnterior) > 0)
                {
                    comprobantes_N.editarComprobantesManual(ConexionEquipo, sucAnterior);
                }
                else
                {
                    comprobantes_N.insertarUnoVtas(ConexionEquipo, "FAB");
                    comprobantes_N.insertarUnoVtas(ConexionEquipo, "FAA");
                    comprobantes_N.insertarUnoVtas(ConexionEquipo, "NCB");
                    comprobantes_N.insertarUnoVtas(ConexionEquipo, "NCA");
                }
            }
            else
            {
                MessageBox.Show("El parametro VTAPUNTO se encuentra vacio , no se encuentra la sucursal anterior");
            }


        }

        public void insertarComprobantes(string comprobante)
        {
            string ConexionEquipo = _equipo.VerificarLinkedServer();

            string sucActual = _parametros_Controller.TraerValorParametro("VTAPUNTO");

            comprobantes_n comprobantes_N = new comprobantes_n(_conexion, sucActual);


            if (comprobantes_N.BuscarComprobantes(ConexionEquipo, sucActual) == 0)
            {
                comprobantes_N.insertarUnoVtas(ConexionEquipo, comprobante);

            }

        }
    }
}
