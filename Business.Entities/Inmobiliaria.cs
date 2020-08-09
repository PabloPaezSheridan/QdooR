using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Inmobiliaria : BusinessEntity
    {
        public Int64 Cuit { get; set; }

        public string Denominacion { get; set; }

        public Int64 Telefono { get; set; }

        public string Email { get; set; }

    }
}
