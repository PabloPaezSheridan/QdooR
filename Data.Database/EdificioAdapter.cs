using Business.Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class EdificioAdapter: Adapter
	{
        public Edificio GetOne(int IdEdificio)
        {
            Edificio edificio = new Edificio();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEdificio = new SqlCommand("select * from Edificios e where e.idEdificio = @idEdificio", sqlConn);
               
                cmdEdificio.Parameters.Add("@idEdificio", SqlDbType.Int).Value = IdEdificio;
                SqlDataReader drEdificios = cmdEdificio.ExecuteReader();
                if (drEdificios.Read())
                {
                    edificio.IdEdificio = (int)drEdificios["idEdificio"];
                    edificio.Denominacion = (string)drEdificios["denominacion"];
                    edificio.Calle = (string)drEdificios["calle"];
                    edificio.NroCalle = (string)drEdificios["nroCalle"];
                    edificio.CodigoPostal = (int)drEdificios["codigoPostal"];
                    edificio.TipoAcceso = (string)drEdificios["tipoAcceso"];
                }
                drEdificios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el edificio: " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return edificio;
        }

        public Edificio GetOnexUsuario(string NombreUsuario)
        {
            Edificio edificio = new Edificio();
            try
            {
                this.OpenConnection();
                SqlCommand cmdEdificio = new SqlCommand("select * from Edificios e inner join UsuariosEdificios ue on ue.idEdificio = e.idEdificio where ue.nombreUsuario = @nombreUsuario", sqlConn);

                cmdEdificio.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;
                SqlDataReader drEdificios = cmdEdificio.ExecuteReader();
                if (drEdificios.Read())
                {
                    edificio.IdEdificio = (int)drEdificios["idEdificio"];
                    edificio.Denominacion = (string)drEdificios["denominacion"];
                    edificio.Calle = (string)drEdificios["calle"];
                    edificio.NroCalle = (string)drEdificios["nroCalle"];
                    edificio.CodigoPostal = (int)drEdificios["codigoPostal"];
                    edificio.TipoAcceso = (string)drEdificios["tipoAcceso"];
                }
                drEdificios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el edificio: " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return edificio;
        }

        public int ContarEdificiosxUsuario(string NombreUsuario)
        {
            try
            {
                int numeroEdificios = 0;
                this.OpenConnection();
                SqlCommand cmdEdificio = new SqlCommand("select count(e.IdEdificio) numeroEdificios from Edificios e inner join UsuariosEdificios ue on ue.idEdificio = e.idEdificio where ue.nombreUsuario = @nombreUsuario group by ue.nombreUsuario", sqlConn);
                cmdEdificio.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;

                SqlDataReader drEdificio = cmdEdificio.ExecuteReader();
                if (drEdificio.Read())
                {
                    numeroEdificios = (int)drEdificio["numeroEdificios"];

                }
                drEdificio.Close();
                return numeroEdificios;

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el numero de edificios" + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection(); 
            }
            
        }

        public DataTable GetEdificiosxUsuario(string NombreUsuario)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdEdificio = new SqlCommand("select e.idEdificio idEdificio, e.Denominacion denominacion, e.calle calle, e.nroCalle nroCalle from Edificios e inner join UsuariosEdificios ue on ue.idEdificio = e.idEdificio where ue.nombreUsuario = @nombreUsuario", sqlConn);
                cmdEdificio.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = NombreUsuario;

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmdEdificio;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el numero de edificios" + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public DataTable GetEdificiosxInmobiliaria(Inmobiliaria inmActual)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdEdificio = new SqlCommand("select e.idEdificio idEdificio, Concat(e.denominacion,' , ', e.calle, ' , ' ,e.nroCalle) concatenacion from Edificios e where e.cuit = @cuit", sqlConn);
                cmdEdificio.Parameters.Add("@cuit", SqlDbType.BigInt).Value = inmActual.Cuit;

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmdEdificio;
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

        public DataTable GetLlavesActivadasxEdificioyRango(int idEdificio, DateTime fini, DateTime ffin)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdEdificio = new SqlCommand("select u.nombreUsuario nombreUsuario, u.nombreyapellido nombreyapellido, u.email mail, u.celular celular, ue.departamento departamento, lla.fechayHoraActivacion fechayHoraAcceso" +
                    " from Edificios e inner join UsuariosEdificios ue on ue.idEdificio = e.idEdificio inner join Usuarios u on u.nombreUsuario = ue.nombreUsuario inner join Llaves ll on ll.nombreUsuario = u.nombreUsuario inner join LlavesActivadas lla on lla.cadenaQr = ll.cadenaQr" +
                    " where e.idEdificio = @idEdificio and lla.fechayHoraActivacion between @fini and @ffin", sqlConn);

                cmdEdificio.Parameters.Add("@idEdificio", SqlDbType.Int).Value = idEdificio;
                cmdEdificio.Parameters.Add("@fini", SqlDbType.DateTime).Value = fini;
                cmdEdificio.Parameters.Add("@ffin", SqlDbType.DateTime).Value = ffin;

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmdEdificio;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el numero de edificios" + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void InsertUsuarioEdificio(int IdEdificio, string nombreUsuario, string Dpto)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuario = new SqlCommand("insert into UsuariosEdificios (nombreUsuario, idEdificio, departamento) values (@nombreUsuario, @idEdificio, @dpto)", sqlConn);

                cmdUsuario.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = nombreUsuario;
                cmdUsuario.Parameters.Add("@idEdificio", SqlDbType.Int).Value = IdEdificio;
                cmdUsuario.Parameters.Add("@dpto", SqlDbType.VarChar).Value = Dpto;
               
                cmdUsuario.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar el registro en UsuariosEdificios", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
