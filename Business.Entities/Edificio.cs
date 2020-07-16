using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class Edificio : BusinessEntity
	{
        public int IdEdificio { get; set; } //Solo lectura

        public int CodigoPostal { get; set; }

        public string Calle { get; set; }

        public string NroCalle { get; set; }

		public string Denominacion { get; set; }

		public string Contacto { get; set; }

		public int Cuit { get; set; }

        public string TipoAcceso { get; set; }



    }
}
