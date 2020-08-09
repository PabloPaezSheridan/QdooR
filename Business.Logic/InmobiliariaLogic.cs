using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Entities;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class InmobiliariaLogic: BusinessLogic
    {
        public Data.Database.InmobiliariaAdapter InmobiliariaData { get; set; }

        public InmobiliariaLogic()
        {
            InmobiliariaData = new InmobiliariaAdapter();
        }

        public Inmobiliaria GetOnexUsuario(Usuario usrInmobiliaria)
        {
            return InmobiliariaData.GetOnexUsuario(usrInmobiliaria);
        }
    }
}
