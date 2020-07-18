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
    public class LlaveLogic : BusinessLogic
    {
        private Data.Database.LlaveAdapter _LlaveData;
        public Data.Database.LlaveAdapter LlaveData
        {
            get { return _LlaveData; }
            set { _LlaveData = value; }
        }


        public LlaveLogic()
        {
            LlaveData = new LlaveAdapter();
        }

    //Se hizo una query en sql para traer la tabla con las llaves, porque era mas facil ajustar los datos para mostrar
    //Por eso no esta aca el metodo de listado de las llaves
        

        public void Create(Llave llave)
        {
            LlaveData.Insert(llave);
        }

        public void Delete(int IdEdificio, string NombreUsuario, DateTime fechayhoraini)
        {
            LlaveData.Delete(fechayhoraini, IdEdificio, NombreUsuario);
        }

        public void Inhabilitar(int IdEdificio, string CadenaQr)
        {
            LlaveData.Inhabilitar(CadenaQr, IdEdificio);
        }

        public DataTable GetLlavesxUsuario(Usuario usr, Edificio edi)
        {
            return LlaveData.GetAllxUsuarioEdificio(usr, edi);
        }

        public DataTable GetLlavesHabilitadasxUsuario(Usuario usr, Edificio edi)
        {
            return LlaveData.GetAllHabilitadasxUsuarioEdificio(usr, edi);
        }

        public Llave GetOne(string qr)
        {
            return LlaveData.GetOne(qr);
        }

        public void Update(string CadenaQr, string Denominacion)
        {
            LlaveData.UpdateDenominacion(CadenaQr, Denominacion);
        }

        public DateTime FechaFomateada(DateTime fechaOriginal)
        {
            string timeString = fechaOriginal.ToString("dd'/'MM'/'yyyy HH:mm:ss");
            IFormatProvider culture = new CultureInfo("es-AR", true);
            DateTime dateVal = DateTime.ParseExact(timeString, "dd/MM/yyyy HH:mm:ss", culture);

            return dateVal;
        }
    }
}
