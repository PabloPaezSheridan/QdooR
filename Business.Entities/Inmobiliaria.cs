using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class Inmobiliaria : BusinessEntity
    {
        public int Cuit { get; set; }

        public string Denominacion { get; set; }

        public int Telefono { get; set; }

        public string Email { get; set; }

    }
}
