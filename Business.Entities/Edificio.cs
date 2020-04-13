using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class Edificio : BusinessEntity
	{
        public int CodigoPostal { get; set; }

        public string Calle { get; set; }

        public int NroCalle { get; set; }

        private string _Nombre;
		public string Nombre
		{
			get { return _Nombre; }
			set { _Nombre = value; }
		}

		private string _Contacto;
		public string Contacto
		{
			get { return _Contacto; }
			set { _Contacto = value; }
		}

		private string _NombreEmpresa;
		public string NombreEmpresa
		{
			get { return _NombreEmpresa; }
			set { _NombreEmpresa = value; }
		}

	}
}
