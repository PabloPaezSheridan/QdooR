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
    public class LlaveActivadaLogic
    {
        LlaveActivadaAdapter llaveActivadaData { get; set; }

        public LlaveActivadaLogic()
        {
            llaveActivadaData = new LlaveActivadaAdapter();
        }

        public void Add(Llave llave)
        {
            llaveActivadaData = new LlaveActivadaAdapter();
            llaveActivadaData.Insert(llave);
        }

        public DataTable GetAllxLlave(string CadenaQr)
        {
            return llaveActivadaData.GetAllxLlaveEdificio(CadenaQr);
        }

    }
    
}
