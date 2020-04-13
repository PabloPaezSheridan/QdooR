using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class LlaveActivadaLogic
    {
        LlaveActivadaAdapter llaveActivadaData { get; set; }

        public LlaveActivadaLogic()
        {

        }

        public void Add(Llave llave)
        {
            llaveActivadaData = new LlaveActivadaAdapter();
            llaveActivadaData.Insert(llave);
        }

    }
    
}
