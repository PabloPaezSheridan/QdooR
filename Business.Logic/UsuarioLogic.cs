using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
	public class UsuarioLogic : BusinessLogic
	{
		private Data.Database.UsuarioAdapter _UsuarioData;
		public Data.Database.UsuarioAdapter UsuarioData
		{
			get { return _UsuarioData; }
			set { _UsuarioData = value; }
		}


		public UsuarioLogic()
		{
			UsuarioData = new UsuarioAdapter();
		}

		public Business.Entities.Usuario GetOne(int CP, string Calle, string nroCalle, string dpto)
		{
			return UsuarioData.GetOne(CP,Calle,nroCalle, dpto);
		}

        public Business.Entities.Usuario ValidarUsuario(int CP, string Calle, string nroCalle, string dpto,string clave)
        {
            return UsuarioData.ValidarUsuario(CP, Calle, nroCalle, dpto,clave);
        }

    }
}
