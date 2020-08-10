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
                        usr.Celular = (long)drUsr["celular"];
                    }
					usr.Contraseña = (string)drUsr["contraseña"];
                    usr.Tipo = (string)drUsr["tipo"];
                    usr.Email = (string)drUsr["email"];
                    usr.Estado = (string)drUsr["estado"];
                    if (drUsr["cuit"] != null)
                    {
                        usr.Cuit = (long)drUsr["cuit"];
                    }
                   
					
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

        public DataTable GetallxEdificio(int idEdificio)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdUsuarios = new SqlCommand("select u.nombreUsuario nombreUsuario, u.nombreyapellido nombreyApellido, u.celular celular, u.email, email from Usuarios u inner join UsuariosEdificios ue on ue.nombreUsuario = u.nombreUsuario where ue.idEdificio = @idEdificio ", sqlConn);
                cmdUsuarios.Parameters.Add("@idEdificio", SqlDbType.Int).Value = idEdificio;

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmdUsuarios;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar los edificios de las inmobiliarias" + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    } 
}
