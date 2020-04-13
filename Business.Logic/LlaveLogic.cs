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

        public void Delete(string dpto, int CP, string Calle, string nroCalle, DateTime fechayhoraini)
        {
            LlaveData.Delete(CP,Calle,nroCalle,dpto,fechayhoraini);
        }

        public void Inhabilitar(string dpto, int CP, string Calle, string nroCalle, DateTime fechayhoraini)
        {
            LlaveData.Inhabilitar(CP, Calle, nroCalle, dpto, fechayhoraini);
        }

        public DataTable GetLlavesxUsuario(Usuario usr)
        {
            return LlaveData.GetAllxUsuario(usr);
        }

        public DataTable GetLlavesHabilitadasxUsuario(Usuario usr)
        {
            return LlaveData.GetAllHabilitadasxUsuario(usr);
        }

        public Llave GetOnexEdificio(string qr, int CP, string Calle, string nroCalle)
        {
            return LlaveData.GetOnexEdificio(qr, CP,Calle,nroCalle);
        }

        public void Update(Llave llave)
        {
            LlaveData.Update(llave);
        }
    }
}
