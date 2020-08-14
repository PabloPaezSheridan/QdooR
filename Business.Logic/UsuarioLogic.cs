using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Entities;
using Data.Database;
using System.Data;
using System.Globalization;

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

        public void Update(Usuario usr, string nombreEditor, DateTime ahora)
        {

            UsuarioData.Update(usr, nombreEditor, FechaFomateada(ahora));
        }

        public void bajaUsuarioxInmobiliaria(string nombreUsuario, int idEdificio)
        {
            UsuarioData.bajaUsuarioxInmobiliaria(nombreUsuario, idEdificio);
        }

        public void Insert(Usuario usr, string nombreEditor, DateTime ahora)
        {
            UsuarioData.Insert(usr, nombreEditor, FechaFomateada(ahora));
        }

        private DateTime FechaFomateada(DateTime fechaOriginal)
        {
            string timeString = fechaOriginal.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            IFormatProvider culture = new CultureInfo("es-AR", true);
            DateTime dateVal = DateTime.ParseExact(timeString, "dd/MM/yyyy HH:mm:ss", culture);

            return dateVal;
        }
    }
}
