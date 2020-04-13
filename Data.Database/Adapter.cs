using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
	public class Adapter
	{
		//No se como hacer el app.config ... Es esta una alternativa viable?
		const string consKeyDefaultCnnString = "ConnStringServer";

		private SqlConnection _sqlConn;

		public SqlConnection sqlConn
		{
			get { return _sqlConn; }
			set { _sqlConn = value; }
		}

		protected void OpenConnection()
		{
			string connectionstring = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
			
			sqlConn = new SqlConnection(connectionstring);
			sqlConn.Open();

			//throw new Exception("Metodo no implementado");
		}

		protected void CloseConnection()
		{
			sqlConn.Close();
			sqlConn = null;
			//throw new Exception("Metodo no implementado");
		}

		protected SqlDataReader ExecuteReader(String commandText)
		{
			throw new Exception("Metodo no implementado");
		}
	}
}
