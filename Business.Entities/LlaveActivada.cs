using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace Business.Entities
{
	public class LlaveActivada: BusinessEntity
	{
        // Maneje para tener las fechas correctas a nivel aplicacion
        private DateTime _fechayHoraActivacion;
        public DateTime fechayHoraActivacion
        {
            get { return FechaFomateada(_fechayHoraActivacion); }
            set { _fechayHoraActivacion = value; }
        }

        private DateTime FechaFomateada(DateTime fechaOriginal)
        {
            string timeString = fechaOriginal.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            IFormatProvider culture = new CultureInfo("es-AR", true);
            DateTime dateVal = DateTime.ParseExact(timeString, "dd/MM/yyyy HH:mm:ss", culture);

            return dateVal;
        }

        public string CadenaQr { get; set; }
	}
}
