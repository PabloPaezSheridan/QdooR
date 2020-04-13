using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class Usuario : BusinessEntity

	{
		private string _Dpto;
		public string Dpto
		{
			get { return _Dpto; }
			set { _Dpto = value; }
		}

        public int CodigoPostalEdificio { get; set; }

        public string CalleEdificio { get; set; }

        public string NroCalleEdificio { get; set; }

        private string _NombreyApellido;
		public string NombreyApellido
		{
			get { return _NombreyApellido; }
			set { _NombreyApellido = value; }
		}

		private string _Celular;
		public string Celular
		{
			get { return _Celular; }
			set { _Celular = value; }
		}

        private string _Contraseña;
        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }



	}
}
