using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class LlaveActivada: BusinessEntity
	{
		private DateTime _FechayHoraActivacion;
		public DateTime FechayHoraActivacion
		{
			get { return _FechayHoraActivacion; }
			set { _FechayHoraActivacion = value; }
		}

		private string _CadenaQr;
		public string CadenaQr
		{
			get { return _CadenaQr; }
			set { _CadenaQr = value; }
		}
	}
}
