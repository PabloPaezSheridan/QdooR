using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
	public class LlaveActivada: BusinessEntity
	{
		public DateTime FechayHoraActivacion { get; set; }

		public string CadenaQr { get; set; }
	}
}
