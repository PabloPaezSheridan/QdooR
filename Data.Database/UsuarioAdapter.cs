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
		public Usuario GetOne(string NombreUsuario)
		{
			Usuario usr = new Usuario();
			try
			{
				this.OpenConnection();
				SqlCommand cmdUsr = new SqlCommand("select * from usuarios where nombreUsuario = @nombreUsuario", sqlConn);
                cmdUsr.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;
                SqlDataReader drUsr = cmdUsr.ExecuteReader();
				if (drUsr.Read())
				{
                    usr.NombreUsuario = (string)drUsr["nombreUsuario"];
                    usr.NombreyApellido= (string)drUsr["nombreyapellido"];
                    if(drUsr["celular"] != null)
                    {
                        usr.Celular = (Int64)drUsr["celular"];
                    }
					usr.Contraseña = (string)drUsr["contraseña"];
                    usr.Tipo = (string)drUsr["tipo"];
                    usr.Email = (string)drUsr["email"];
                    usr.Estado = (string)drUsr["estado"];
					
				}
				drUsr.Close();
			}
			catch (Exception Ex)
			{
				Exception ExcepcionManejada = new Exception("No te encontramos, verificá el nombre de usuario que ingresaste " + Ex.Message, Ex);
				throw ExcepcionManejada;
			}
			finally
			{
				this.CloseConnection();
			}
			return usr;
		}

        public Usuario ValidarUsuario(string NombreUsuario, string Contraseña)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsr = new SqlCommand("select * from usuarios where nombreUsuario = @nombreUsuario and contraseña = @contraseña ", sqlConn);
                cmdUsr.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;
                cmdUsr.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = Contraseña;

                SqlDataReader drUsr = cmdUsr.ExecuteReader();
                if (drUsr.Read())
                {
                    usr.NombreUsuario = (string)drUsr["nombreUsuario"];
                    usr.NombreyApellido = (string)drUsr["nombreyapellido"];
                    usr.Celular = (int)drUsr["celular"];
                    usr.Contraseña = (string)drUsr["contraseña"];
                    usr.Tipo = (string)drUsr["tipo"];
                    usr.Email = (string)drUsr["email"];
                    usr.Estado = (string)drUsr["estado"];

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
