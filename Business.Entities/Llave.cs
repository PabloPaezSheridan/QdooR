using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class Llave : BusinessEntity
	{
		private string _CadenaQr;
		public string CadenaQr
		{
			get { return _CadenaQr; }
			set { _CadenaQr = value; }
		}

        public string NombreUsuario { get; set; }

        public int IdEdificio { get; set; }


        // No olvidarse de las variables de solo lectura 

		public DateTime fechayHoraCreacion { get; set; }

        public DateTime fechayHoraCaducacion { get; set; }

        public string Denominacion { get; set; }

        public bool desechable { get; set; }

        public bool Habilitada { get; set; }

    }
}
