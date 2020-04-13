using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
	class EdificioLogic : BusinessLogic
	{
		private Data.Database.EdificioAdapter _EdificioData;
		public Data.Database.EdificioAdapter EdificioData
		{
			get { return _EdificioData; }
			set { _EdificioData = value; }
		}

		
		public EdificioLogic()
		{
			EdificioData = new EdificioAdapter();
		}
		
	}
}
