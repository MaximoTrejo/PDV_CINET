using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.Controllers;
using ConfiguradorPDV.DB;
using ConfiguradorPDV.Modelo;

namespace ConfiguradorPDV.Controllers
{
    public class comprobantes_e_controller
    {
        Factory _conexion;
        LinkedServer _equipo;

        public comprobantes_e_controller(Factory conexion, LinkedServer equipo)
        {
            _conexion = conexion;
            _equipo = equipo;
        }


        public void modificarCodigoComprobantes(string tipo)
        {

            string ConexionEquipo = _equipo.VerificarLinkedServer();

            comprobantes_e comprobantes_E = new comprobantes_e(_conexion);

            int existeFAB = comprobantes_E.BuscarComprobante(ConexionEquipo, "FAB");
            int existeFAA = comprobantes_E.BuscarComprobante(ConexionEquipo, "FAA");
            int existeNCB = comprobantes_E.BuscarComprobante(ConexionEquipo, "NCB");
            int existeNCA = comprobantes_E.BuscarComprobante(ConexionEquipo, "NCA");

            switch (tipo)
            {
                case "FE":

                    if (existeFAB > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "FAB", "6");
                    }

                    if (existeFAA > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "FAA", "1");
                    }

                    if (existeNCB > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "NCB", "8");
                    }

                    if (existeNCA > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "NCA", "3");
                    }
                    break;
                case "CF":
                    if (existeFAB > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "FAB", "14");
                    }

                    if (existeFAA > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "FAA", "11");
                    }

                    if (existeNCB > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "NCB", "4");
                    }

                    if (existeNCA > 0)
                    {
                        comprobantes_E.modificarComprobantes(ConexionEquipo, "NCA", "4");
                    }
                    break;
                case "M":
                    comprobantes_E.modificarComprobantes(ConexionEquipo, "FAB", "11");
                    break;
            }




            

        }
    }
}
