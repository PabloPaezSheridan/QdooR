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
                SqlCommand cmdLlave = new SqlCommand("insert into llaves (cadenaQr,dpto,codigoPostalEdificio,calleEdificio,nroCalleEdificio,FechayHoraIni,FechayHoraFin,desechable,habilitada)" +
                                                        "values (@cadenaQr,@dpto,@CP,@calle,@nro,@FechayHoraIni,@FechayHoraFin,@desechable, @habilitada) ", sqlConn);

                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar, 50).Value = llave.CadenaQr;
                cmdLlave.Parameters.Add("@dpto", SqlDbType.VarChar, 50).Value = llave.Dpto;

                cmdLlave.Parameters.Add("@CP", SqlDbType.Int).Value = llave.CodigoPostalEdificio;
                cmdLlave.Parameters.Add("@calle", SqlDbType.VarChar, 50).Value = llave.CalleEdificio;
                cmdLlave.Parameters.Add("@nro", SqlDbType.VarChar, 50).Value = llave.NroCalleEdificio;

                cmdLlave.Parameters.Add("@FechayHoraIni", SqlDbType.DateTime).Value = llave.FechayHoraIni;
                if (llave.FechayHoraFin == null)
                {
                    cmdLlave.Parameters.Add("@FechayHoraFin", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmdLlave.Parameters.Add("@FechayHoraFin", SqlDbType.DateTime).Value = llave.FechayHoraFin;
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


        public Llave GetOnexEdificio(string qr, int CP, string Calle, string nroCalle)
        {
            Llave llave = new Llave();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select * from llaves ll inner join edificios e on e.codigoPostal = @CP and e.calle =@calle  and e.nroCalle = @nroCalle and ll.cadenaQr = @qr ", sqlConn);
                cmdLlave.Parameters.Add("@qr", SqlDbType.VarChar, 50).Value = qr;

                cmdLlave.Parameters.Add("@CP", SqlDbType.Int).Value = CP;
                cmdLlave.Parameters.Add("@calle", SqlDbType.VarChar, 50).Value =Calle;
                cmdLlave.Parameters.Add("@nroCalle", SqlDbType.VarChar, 50).Value = nroCalle;
                SqlDataReader drLlaves = cmdLlave.ExecuteReader();
                if (drLlaves.Read())
                {
                    llave.CadenaQr = (string)drLlaves["cadenaQr"];
                    llave.FechayHoraIni = (DateTime)drLlaves["FechayHoraIni"];
                    llave.FechayHoraFin = (DateTime)drLlaves["FechayHoraFin"];
                    llave.CodigoPostalEdificio = (int)drLlaves["codigoPostal"];
                    llave.CalleEdificio = (string)drLlaves["calleEdificio"];
                    llave.NroCalleEdificio = (string)drLlaves["nroCalleEdificio"];
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

        public void Delete(int CP, string calleEdificio,string nroCalleEdificio, string dpto,DateTime fechayhoraini)
        {
            Llave llave = new Llave();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("Delete from llaves where convert(datetime, convert(char(19), FechayHoraIni, 126)) = @fechahoraini and dpto = @dpto and codigoPostalEdifcio = @CP and calleEdificio = @calleEdificio and nroCalleEdificio = @nroCalleEdificio", sqlConn);
                cmdLlave.Parameters.Add("@fechahoraini", SqlDbType.DateTime).Value = fechayhoraini;
                cmdLlave.Parameters.Add("@dpto", SqlDbType.VarChar).Value = dpto;
                cmdLlave.Parameters.Add("@CP", SqlDbType.Int).Value = CP;
                cmdLlave.Parameters.Add("@calleEdificio", SqlDbType.VarChar).Value = calleEdificio;
                cmdLlave.Parameters.Add("@nroCalleEdificio", SqlDbType.VarChar).Value = nroCalleEdificio;
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

        public void Inhabilitar(int CP, string calleEdificio, string nroCalleEdificio, string dpto, DateTime fechayhoraini)
        {
            Llave llave = new Llave();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("update llaves set habilitada = 'false' where FechayHoraini = @fechahoraini and dpto = @dpto and codigoPostalEdificio = @CP and calleEdificio = @calleEdificio and nroCalleEdificio = @nroCalleEdificio ", sqlConn);
                cmdLlave.Parameters.Add("@fechahoraini", SqlDbType.DateTime).Value = fechayhoraini;
                cmdLlave.Parameters.Add("@dpto", SqlDbType.VarChar).Value = dpto;
                cmdLlave.Parameters.Add("@CP", SqlDbType.Int).Value = CP;
                cmdLlave.Parameters.Add("@calleEdificio", SqlDbType.VarChar).Value = calleEdificio;
                cmdLlave.Parameters.Add("@nroCalleEdificio", SqlDbType.VarChar).Value = nroCalleEdificio;
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

        public DataTable GetAllxUsuario(Usuario usr)
        {
            List<Llave> llaves = new List<Llave>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select ll.FechayHoraIni fechorCre,case  when ll.FechayHoraFin IS NULL then 'Sin especificar' else  CONVERT(varchar, getdate(), 1) end fechorCad , case ll.desechable  when '1' then 'Desechable' when '0' then 'No Desechable'  end as desechable from llaves ll where dpto=@dpto and codigoPostalEdificio = @CP and calleEdificio = @calleEdificio and nroCalleEdificio = @nroCalleEdificio", sqlConn);
                cmdLlave.Parameters.Add("@CP", SqlDbType.Int).Value = usr.CodigoPostalEdificio;
                cmdLlave.Parameters.Add("@calleEdificio", SqlDbType.VarChar).Value = usr.CalleEdificio;
                cmdLlave.Parameters.Add("@nroCalleEdificio", SqlDbType.VarChar).Value = usr.NroCalleEdificio;
                cmdLlave.Parameters.Add("@dpto", SqlDbType.VarChar, 50).Value = usr.Dpto;

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

        public DataTable GetAllHabilitadasxUsuario(Usuario usr)
        {
            List<Llave> llaves = new List<Llave>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select ll.FechayHoraIni fechorCre,case  when ll.FechayHoraFin IS NULL then 'Sin especificar' else  CONVERT(varchar, getdate(), 1) end fechorCad , case ll.desechable  when '1' then 'Desechable' when '0' then 'No Desechable'  end as desechable from llaves ll where dpto=@dpto and codigoPostalEdificio = @CP and calleEdificio = @calleEdificio and nroCalleEdificio = @nroCalleEdificio and habilitada= 'true'", sqlConn);
                cmdLlave.Parameters.Add("@CP", SqlDbType.Int).Value = usr.CodigoPostalEdificio;
                cmdLlave.Parameters.Add("@calleEdificio", SqlDbType.VarChar).Value = usr.CalleEdificio;
                cmdLlave.Parameters.Add("@nroCalleEdificio", SqlDbType.VarChar).Value = usr.NroCalleEdificio;
                cmdLlave.Parameters.Add("@dpto", SqlDbType.VarChar, 50).Value = usr.Dpto;

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

        public void Update(Llave llave)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("update from llaves (cadenaQr,dpto,codigoPostalEdificio,calleEdificio,nroCalleEdificio,FechayHoraIni,FechayHoraFin,desechable,habilitada)" +
                                                        "values (@cadenaQr,@dpto,@CP,@calle,@nro,@FechayHoraIni,@FechayHoraFin,@desechable, @habilitada) ", sqlConn);

                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar, 50).Value = llave.CadenaQr;
                cmdLlave.Parameters.Add("@dpto", SqlDbType.VarChar, 50).Value = llave.Dpto;

                cmdLlave.Parameters.Add("@CP", SqlDbType.Int).Value = llave.CodigoPostalEdificio;
                cmdLlave.Parameters.Add("@calle", SqlDbType.VarChar, 50).Value = llave.CalleEdificio;
                cmdLlave.Parameters.Add("@nro", SqlDbType.VarChar, 50).Value = llave.NroCalleEdificio;

                cmdLlave.Parameters.Add("@FechayHoraIni", SqlDbType.DateTime).Value = llave.FechayHoraIni;
                if (llave.FechayHoraFin == null)
                {
                    cmdLlave.Parameters.Add("@FechayHoraFin", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmdLlave.Parameters.Add("@FechayHoraFin", SqlDbType.DateTime).Value = llave.FechayHoraFin;
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
    }
}
