using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class Usuario : BusinessEntity

	{
        public string NombreUsuario { get; set; }

		public string NombreyApellido { get; set; }

		public Int64? Celular { get; set; }

        public string Contraseña { get; set; }

        public string Tipo { get; set; }

        public string Estado { get; set; }

        public string Email { get; set; }

        public Int64? Cuit { get; set; }

    }
}
