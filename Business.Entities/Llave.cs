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
		
		private string _Dpto;
		public string Dpto
		{
			get { return _Dpto; }
			set { _Dpto = value; }
		}
        public int CodigoPostalEdificio { get; set; }

        public string CalleEdificio { get; set; }

        public string NroCalleEdificio { get; set; }

        // No olvidarse de las variables de solo lectura 

        private DateTime _FechayHoraIni;
		public DateTime FechayHoraIni
		{
			get { return _FechayHoraIni; }
			set { _FechayHoraIni = value; }
		}

		private Nullable< DateTime> _FechayHoraFin;
		public Nullable<DateTime> FechayHoraFin
		{
			get { return _FechayHoraFin; }
			set { _FechayHoraFin = value; }
		}

		private bool _desechable;
		public bool desechable
		{
			get { return _desechable; ; }
			set { _desechable = value; }
		}

        public bool Habilitada { get; set; }

    }
}
