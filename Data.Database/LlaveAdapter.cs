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
    public class LlaveAdapter : Adapter

    {
        public void Insert(Llave llave)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("insert into llaves (cadenaQr,idEdificio,nombreUsuario,FechayHoraIni,FechayHoraFin,desechable,habilitada)" +
                                                        "values (@cadenaQr,@idEdificio,@nombreUsuario,@fechayHoraIni,@fechayHoraFin,@desechable, @habilitada) ", sqlConn);

                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar, 50).Value = llave.CadenaQr;

                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = llave.IdEdificio;
                cmdLlave.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = llave.NombreUsuario;

                cmdLlave.Parameters.Add("@fechayHoraIni", SqlDbType.DateTime).Value = llave.FechayHoraIni;
                if (llave.FechayHoraFin == null)
                {
                    cmdLlave.Parameters.Add("@fechayHoraFin", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmdLlave.Parameters.Add("@fechayHoraFin", SqlDbType.DateTime).Value = llave.FechayHoraFin;
                }
                cmdLlave.Parameters.Add("@desechable", SqlDbType.Bit).Value = llave.desechable;

                cmdLlave.Parameters.Add("@habilitada", SqlDbType.Bit).Value = llave.Habilitada;
                cmdLlave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una llave", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public Llave GetOnexEdificio(string qr, int IdEdificio)
        {
            Llave llave = new Llave();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select * from llaves ll inner join edificios e on e.idEdificio = @idEdificio and ll.cadenaQr = @qr ", sqlConn);
                cmdLlave.Parameters.Add("@qr", SqlDbType.VarChar, 50).Value = qr;

                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = IdEdificio;
                SqlDataReader drLlaves = cmdLlave.ExecuteReader();
                if (drLlaves.Read())
                {
                    llave.CadenaQr = (string)drLlaves["cadenaQr"];
                    llave.FechayHoraIni = (DateTime)drLlaves["FechayHoraIni"];
                    llave.FechayHoraFin = (DateTime)drLlaves["FechayHoraFin"];
                    llave.IdEdificio = (int)drLlaves["idEdificio"];
                    llave.NombreUsuario = (string)drLlaves["nombreUsuario"];
                    llave.Habilitada = (bool)drLlaves["Habilitada"];
                }
                drLlaves.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la llave " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return llave;
        }

        public void Delete(DateTime FechayHoraIni, int IdEdificio, string NombreUsuario)
        {
            Llave llave = new Llave();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("Delete from llaves where convert(datetime, convert(char(19), FechayHoraIni, 126)) = @fechahoraini and nombreUsuario = @nombreUsuario and idEdificio = @idEdificio", sqlConn);
                cmdLlave.Parameters.Add("@fechahoraini", SqlDbType.DateTime).Value = FechayHoraIni;
                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = IdEdificio;
                cmdLlave.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = NombreUsuario;
                cmdLlave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la llave " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Inhabilitar(DateTime FechayHoraIni, int IdEdificio, string NombreUsuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("update llaves set habilitada = 'false' where FechayHoraini = @fechayHoraIni and idEdifcio = @idEdifcio and  nombreUsuario = @nombreUsuario", sqlConn);
                cmdLlave.Parameters.Add("@fechahoraini", SqlDbType.DateTime).Value = FechayHoraIni;
                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = IdEdificio;
                cmdLlave.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = NombreUsuario;
                cmdLlave.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al inhabilitar la llave " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public DataTable GetAllxUsuarioEdificio(Usuario usr, Edificio edificio)
        {
            List<Llave> llaves = new List<Llave>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select ll.FechayHoraIni fechorCre,case  when ll.FechayHoraFin IS NULL then 'Sin especificar' else  CONVERT(varchar, getdate(), 1) end fechorCad , case ll.desechable  when '1' then 'Desechable' when '0' then 'No Desechable'  end as desechable from llaves ll where nombreUsuario = @nombreUsuario and idEdificio = @idEdificio", sqlConn);
                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = edificio.IdEdificio;
                cmdLlave.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = usr.NombreUsuario;

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmdLlave;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la llave " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public DataTable GetAllHabilitadasxUsuarioEdificio(Usuario usr, Edificio edificio)
        {
            List<Llave> llaves = new List<Llave>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select ll.FechayHoraIni fechorCre,case  when ll.FechayHoraFin IS NULL then 'Sin especificar' else  CONVERT(varchar, getdate(), 1) end fechorCad , case ll.desechable  when '1' then 'Desechable' when '0' then 'No Desechable'  end as desechable from llaves ll where dpto=@dpto and codigoPostalEdificio = @CP and calleEdificio = @calleEdificio and nroCalleEdificio = @nroCalleEdificio and habilitada= 'true'", sqlConn);
                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = usr.NombreUsuario;
                cmdLlave.Parameters.Add("@nombreUsuario", SqlDbType.VarChar, 50).Value = edificio.IdEdificio;

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmdLlave;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la llave " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void UpdateDenominacion(string CadenaQr, string Denominacion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("update from llaves (denominacion)" +
                                                        "values (@denominacion) where cadenaQr = @cadenaQr", sqlConn);

                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar, 50).Value = CadenaQr;
                cmdLlave.Parameters.Add("@denominacion", SqlDbType.VarChar, 250).Value = Denominacion;

                cmdLlave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear una llave", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


        }

    }
}
