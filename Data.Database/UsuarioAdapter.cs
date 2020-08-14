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
				SqlCommand cmdUsr = new SqlCommand("select u.nombreUsuario nombreUsuario, u.nombreyapellido nombreyapellido, isnull(u.celular, 0) celular, u.contraseña contraseña, u.tipo tipo, u.email email, u.estado estado, isnull(u.cuit, 0) cuit from usuarios u where nombreUsuario = @nombreUsuario", sqlConn);
                cmdUsr.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;
                SqlDataReader drUsr = cmdUsr.ExecuteReader();
				if (drUsr.Read())
				{
                    usr.NombreUsuario = (string)drUsr["nombreUsuario"];
                    usr.NombreyApellido= (string)drUsr["nombreyapellido"];
					usr.Contraseña = (string)drUsr["contraseña"];
                    usr.Tipo = (string)drUsr["tipo"];
                    usr.Email = (string)drUsr["email"];
                    usr.Estado = (string)drUsr["estado"];
                    if ((long)drUsr["celular"] != 0)
                    {
                        usr.Celular = (long)drUsr["celular"];
                    }
                    else
                    {
                        usr.Celular = null;
                    }

                    if ((long)drUsr["cuit"] != 0)
                    {
                        usr.Cuit = (long)drUsr["cuit"];
                    }
                    else
                    {
                        usr.Cuit = null;
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

                SqlCommand cmdUsuarios = new SqlCommand("select u.nombreUsuario nombreUsuario, u.nombreyapellido nombreyApellido, u.celular celular, u.email email, u.estado estado from Usuarios u inner join UsuariosEdificios ue on ue.nombreUsuario = u.nombreUsuario where ue.idEdificio = @idEdificio and (u.estado = 'habilitado' or u.estado = 'deshabilitado') ", sqlConn);
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

        public void bajaUsuarioxInmobiliaria(string NombreUsuario, int idEdificio)
        {
            Usuario usuario = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("Delete from usuariosEdificios where nombreUsuario = @nombreUsuario and idEdificio = @idEdificio", sqlConn);
                cmdUsuario.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = NombreUsuario;
                cmdUsuario.Parameters.Add("@idEdificio", SqlDbType.Int).Value = idEdificio;
                cmdUsuario.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la usuario " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Update(Usuario usuario, string nombreUsuario, DateTime fechayHoraEdicion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("update usuarios set contraseña = @contraseña, nombreyapellido = @nombreyapellido, estado = @estado, celular = @celular, cuit = @cuit, tipo = @tipo, email = @email, nombreEditor = @nombreEditor, fechayHoraEdicion = @fechayHoraEdicion" +
                                                        " where nombreUsuario = @nombreUsuario", sqlConn);

                cmdUsuario.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdUsuario.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = usuario.Contraseña;
                cmdUsuario.Parameters.Add("@nombreyapellido", SqlDbType.VarChar).Value = usuario.NombreyApellido;
                cmdUsuario.Parameters.Add("@estado", SqlDbType.VarChar).Value = usuario.Estado;
                if (usuario.Celular == null)
                {
                    cmdUsuario.Parameters.Add("@celular", SqlDbType.BigInt).Value = DBNull.Value;
                }
                else
                {
                    cmdUsuario.Parameters.Add("@celular", SqlDbType.BigInt).Value = usuario.Celular;
                }

                if (usuario.Cuit == null)
                {
                    cmdUsuario.Parameters.Add("@cuit", SqlDbType.BigInt).Value = DBNull.Value;
                }
                else
                {
                    cmdUsuario.Parameters.Add("@cuit", SqlDbType.BigInt).Value = usuario.Cuit;
                }
                cmdUsuario.Parameters.Add("@tipo", SqlDbType.VarChar).Value = usuario.Tipo;
                cmdUsuario.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                cmdUsuario.Parameters.Add("@nombreEditor", SqlDbType.VarChar).Value = nombreUsuario;
                cmdUsuario.Parameters.Add("@fechayHoraEdicion", SqlDbType.DateTime).Value = fechayHoraEdicion;
                cmdUsuario.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar un usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Usuario usuario, string nombreUsuario, DateTime fechayHoraEdicion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("insert into Usuarios (nombreUsuario, contraseña, nombreyapellido, estado, celular, cuit, tipo, email, nombreEditor, fechayHoraEdicion) values (@nombreUsuario, @contraseña, @nombreyapellido, @estado, @celular, @cuit, @tipo, @email, @nombreEditor, @fechayHoraEdicion)", sqlConn);

                cmdUsuario.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = usuario.NombreUsuario;
                cmdUsuario.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = usuario.Contraseña;
                cmdUsuario.Parameters.Add("@nombreyapellido", SqlDbType.VarChar).Value = usuario.NombreyApellido;
                cmdUsuario.Parameters.Add("@estado", SqlDbType.VarChar).Value = usuario.Estado;
                if (usuario.Celular == null)
                {
                    cmdUsuario.Parameters.Add("@celular", SqlDbType.BigInt).Value = DBNull.Value;
                }
                else
                {
                    cmdUsuario.Parameters.Add("@celular", SqlDbType.BigInt).Value = usuario.Celular;
                }

                if (usuario.Cuit == null)
                {
                    cmdUsuario.Parameters.Add("@cuit", SqlDbType.BigInt).Value = DBNull.Value;
                }
                else
                {
                    cmdUsuario.Parameters.Add("@cuit", SqlDbType.BigInt).Value = usuario.Cuit;
                }
                cmdUsuario.Parameters.Add("@tipo", SqlDbType.VarChar).Value = usuario.Tipo;
                cmdUsuario.Parameters.Add("@email", SqlDbType.VarChar).Value = usuario.Email;
                cmdUsuario.Parameters.Add("@nombreEditor", SqlDbType.VarChar).Value = nombreUsuario;
                cmdUsuario.Parameters.Add("@fechayHoraEdicion", SqlDbType.DateTime).Value = fechayHoraEdicion;
                cmdUsuario.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar el usuario", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    } 
}
