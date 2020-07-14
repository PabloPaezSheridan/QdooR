using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class Edificio : BusinessEntity
	{
        public int IdEdificio { get; } //Solo lectura

        public int CodigoPostal { get; set; }

        public string Calle { get; set; }

        public int NroCalle { get; set; }

		public string Nombre { get; set; }

		public string Contacto { get; set; }

		public string NombreEmpresa { get; set; }

        public string TipoAcceso { get; set; }



    }
}
