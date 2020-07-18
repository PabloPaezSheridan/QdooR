using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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


        // Maneje para tener las fechas correctas a nivel aplicacion
        private DateTime _fechayHoraCreacion;
		public DateTime fechayHoraCreacion { get {return FechaFomateada(_fechayHoraCreacion); }
                                             set {_fechayHoraCreacion = value; } }

        private DateTime _fechayHoraCaducacion;
        public DateTime fechayHoraCaducacion
        {
            get { return FechaFomateada(_fechayHoraCaducacion); }
            set { _fechayHoraCaducacion = value; }
        }

        public string Denominacion { get; set; }

        public bool desechable { get; set; }

        public bool Habilitada { get; set; }

        private DateTime FechaFomateada(DateTime fechaOriginal)
        {
            string timeString = fechaOriginal.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            IFormatProvider culture = new CultureInfo("es-AR", true);
            DateTime dateVal = DateTime.ParseExact(timeString, "dd/MM/yyyy HH:mm:ss", culture);

            return dateVal;
        }

    }
}
