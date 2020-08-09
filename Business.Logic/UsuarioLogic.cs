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
    public class UsuarioLogic : BusinessLogic
    {
        public Data.Database.UsuarioAdapter UsuarioData { get; set; }

        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        public Business.Entities.Usuario GetOne(string NombreUsuario)
        {
            return UsuarioData.GetOne(NombreUsuario);
        }

        public Business.Entities.Usuario ValidarUsuario(string NombreUsuario, string Contraseña)
        { 
            return UsuarioData.ValidarUsuario(NombreUsuario, Contraseña);
        }

        public DataTable GetallxEdificio(int IdEdificio)
        {
            return UsuarioData.GetallxEdificio(IdEdificio);
        }


    }
}
