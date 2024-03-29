﻿using System;
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
                SqlCommand cmdLlave = new SqlCommand("insert into llaves (cadenaQr,idEdificio,nombreUsuario,denominacion,fechayHoraCreacion,fechayHoraCaducacion,desechable,habilitada)" +
                                                        "values (@cadenaQr,@idEdificio,@nombreUsuario,@denominacion,@fechayHoraCreacion,@fechayHoraCaducacion,@desechable, @habilitada) ", sqlConn);

                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar, 50).Value = llave.CadenaQr;

                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = llave.IdEdificio;
                cmdLlave.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = llave.NombreUsuario;
                cmdLlave.Parameters.Add("@denominacion", SqlDbType.VarChar).Value = llave.Denominacion;
                cmdLlave.Parameters.Add("@fechayHoraCreacion", SqlDbType.DateTime).Value = llave.fechayHoraCreacion;
                if (llave.fechayHoraCaducacion == null)
                {
                    cmdLlave.Parameters.Add("@fechayHoraCaducacion", SqlDbType.DateTime).Value = DBNull.Value;
                }
                else
                {
                    cmdLlave.Parameters.Add("@fechayHoraCaducacion", SqlDbType.DateTime).Value = llave.fechayHoraCaducacion;
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


        public Llave GetOne(string qr)
        {
            Llave llave = new Llave();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select * from llaves ll where ll.cadenaQr = @qr ", sqlConn);
                cmdLlave.Parameters.Add("@qr", SqlDbType.VarChar, 50).Value = qr;

                
                SqlDataReader drLlaves = cmdLlave.ExecuteReader();
                if (drLlaves.Read())
                {
                    llave.CadenaQr = (string)drLlaves["cadenaQr"];
                    llave.fechayHoraCreacion = (DateTime)drLlaves["fechayHoraCreacion"];
                    llave.desechable = (Boolean)drLlaves["desechable"];
                    llave.fechayHoraCaducacion = (DateTime)drLlaves["fechayHoraCaducacion"];
                    llave.Denominacion = (string)drLlaves["denominacion"];
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

        public void Delete(DateTime fechayHoraCreacion, int IdEdificio, string NombreUsuario)
        {
            Llave llave = new Llave();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("Delete from llaves where convert(datetime, convert(char(19), fechayHoraCreacion, 126)) = @fechahoraini and nombreUsuario = @nombreUsuario and idEdificio = @idEdificio", sqlConn);
                cmdLlave.Parameters.Add("@fechahoraini", SqlDbType.DateTime).Value = fechayHoraCreacion;
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

        public void Inhabilitar(string CadenaQr, int IdEdificio)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("update llaves set habilitada = 0 where cadenaQr = @cadenaQr and idEdificio = @idEdificio", sqlConn);
                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = IdEdificio;
                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar).Value = CadenaQr;
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
                SqlCommand cmdLlave = new SqlCommand("select u.nombreUsuario nombreUsuario, u.nombreyapellido nombreyApellido,u.celular celular, u.email email from Usuarios u inner join UsuariosEdificios ue on ue.nombreUsuario = u.nombreUsuario where ue.idEdificio = @idEdificio", sqlConn);
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
                SqlCommand cmdLlave = new SqlCommand("select ll.cadenaQr cadenaQr, ll.denominacion  denominacion, ll.fechayHoraCreacion fechorCre, ll.fechayHoraCaducacion fechorCad , ll.desechable desechable from llaves ll where ll.idEdificio = @idEdificio and ll.nombreUsuario = @nombreUsuario and habilitada= 'true'", sqlConn);
                cmdLlave.Parameters.Add("@nombreUsuario", SqlDbType.VarChar).Value = usr.NombreUsuario;
                cmdLlave.Parameters.Add("@idEdificio", SqlDbType.Int).Value = edificio.IdEdificio;

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
