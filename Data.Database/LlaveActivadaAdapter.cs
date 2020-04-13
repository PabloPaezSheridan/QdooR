using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class LlaveActivadaAdapter: Adapter
    {
        public void Insert(Llave llave)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("insert into llaves (cadenaQr,FechayHoraActivacion)" +
                                                        "values (@cadenaQr, @FechayHoraAct) ", sqlConn);

                cmdLlave.Parameters.Add("@FechayHoraAct", SqlDbType.DateTime).Value = DateTime.Now;
                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar, 50).Value = llave.CadenaQr;
                cmdLlave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar una llave Activada", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
