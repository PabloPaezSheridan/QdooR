using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
	public class UsuarioAdapter : Adapter
	{
		public Usuario GetOne(int CP, string calleEdificio, string nroCalleEdificio, string dpto)
		{
			Usuario usr = new Usuario();
			try
			{
				this.OpenConnection();
				SqlCommand cmdUsr = new SqlCommand("select * from usuarios where codigoPostalEdificio = @CP and calleEdificio = @calleEdificio and nroCalleEdificio = @nroCalleEdificio and dpto=@dpto", sqlConn);
                cmdUsr.Parameters.Add("@CP", SqlDbType.Int).Value = CP;
                cmdUsr.Parameters.Add("@calleEdificio", SqlDbType.VarChar).Value = calleEdificio;
                cmdUsr.Parameters.Add("@nroCalleEdificio", SqlDbType.VarChar).Value = nroCalleEdificio;
                cmdUsr.Parameters.Add("@dpto", SqlDbType.VarChar, 50).Value = dpto;
                SqlDataReader drUsr = cmdUsr.ExecuteReader();
				if (drUsr.Read())
				{
					usr.NombreyApellido= (string)drUsr["nombreyapellido"];
					usr.Dpto = (string)drUsr["dpto"];
                    usr.CodigoPostalEdificio = (int)drUsr["codigoPostalEdificio"];
                    usr.CalleEdificio = (string)drUsr["calleEdificio"];
                    usr.NroCalleEdificio = (string)drUsr["nroCalleEdificio"];
					usr.Celular = (string)drUsr["celular"];
                    usr.Contraseña = (string)drUsr["contraseña"];
					
				}
				drUsr.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("No te encontramos, verificá los datos que ingresaste " + Ex.Message, Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return usr;
		}

        public Usuario ValidarUsuario(int CP, string calleEdificio, string nroCalleEdificio, string dpto, string clave)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsr = new SqlCommand("select * from usuarios where codigoPostalEdifcio = @CP and calleEdificio = @calleEdificio and nroCalleEdificio = @nroCalleEdificio and dpto=@dpto and clave = @clave", sqlConn);
                cmdUsr.Parameters.Add("@CP", SqlDbType.Int).Value = CP;
                cmdUsr.Parameters.Add("@calleEdificio", SqlDbType.VarChar).Value = calleEdificio;
                cmdUsr.Parameters.Add("@nroCalleEdificio", SqlDbType.VarChar).Value = nroCalleEdificio;
                cmdUsr.Parameters.Add("@dpto", SqlDbType.VarChar, 50).Value = dpto;
                cmdUsr.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
                SqlDataReader drUsr = cmdUsr.ExecuteReader();
                if (drUsr.Read())
                {
                    usr.NombreyApellido = (string)drUsr["nombreyapellido"];
                    usr.Dpto = (string)drUsr["dpto"];
                    usr.CodigoPostalEdificio = (int)drUsr["codigoPostalEdificio"];
                    usr.CalleEdificio = (string)drUsr["calleEdificio"];
                    usr.NroCalleEdificio = (string)drUsr["nroCalleEdificio"];
                    usr.Celular = (string)drUsr["celular"];
                    usr.Contraseña = (string)drUsr["contraseña"];

                }
                drUsr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("No te encontramos, verificá los datos que ingresaste " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }
    }
}
