using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfiguradorPDV.Controllers;

namespace ConfiguradorPDV.Modelo
{
    public class InfoEquipos
    {
        string vene_caja;
        string descripcion_caja;
        public InfoEquipos(string vene_caja , string descripcion_caja)
        {
            this.vene_caja = vene_caja ;
            this.descripcion_caja = descripcion_caja;
        }

       

    }
}
