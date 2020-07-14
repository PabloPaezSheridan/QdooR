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
		public Data.Database.EdificioAdapter EdificioData { get; set; }

		
		public EdificioLogic()
		{
			EdificioData = new EdificioAdapter();
		}
		
	}
}
