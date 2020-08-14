using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

using System.Data;

namespace Business.Logic
{
	public class EdificioLogic : BusinessLogic
	{
		public Data.Database.EdificioAdapter EdificioData { get; set; }

		
		public EdificioLogic()
		{
			EdificioData = new EdificioAdapter();
		}

        public Edificio GetOne(int IdEdificio)
        {
            return EdificioData.GetOne(IdEdificio);
        }

        public Edificio GetOnexUsuario(string NombreUsuario)
        {
            return EdificioData.GetOnexUsuario(NombreUsuario);
        }

        public int ContarEdificios(string NombreUsuario)
        {
            return EdificioData.ContarEdificiosxUsuario(NombreUsuario);
        }

        public DataTable GetEdificiosxUsuario(string NombreUsuario)
        {
            return EdificioData.GetEdificiosxUsuario(NombreUsuario);
        }

        public DataTable GetEdificiosxInmobiliaria(Inmobiliaria inmobiliaria)
        {
            return EdificioData.GetEdificiosxInmobiliaria(inmobiliaria);
        }

        public void InsertUsuarioEdificio(int IdEdificio, string NombreUsuario, string Dpto)
        {
            EdificioData.InsertUsuarioEdificio(IdEdificio, NombreUsuario, Dpto);
        }
		
	}
}
