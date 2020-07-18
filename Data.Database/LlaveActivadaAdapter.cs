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
                SqlCommand cmdLlave = new SqlCommand("insert into llavesActivadas (cadenaQr,FechayHoraActivacion)" +
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

        public DataTable GetAllxLlaveEdificio(string CadenaQr)
        {
            List<Llave> llaves = new List<Llave>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdLlave = new SqlCommand("select la.fechayHoraActivacion fechoract from LlavesActivadas la where la.cadenaQr = @cadenaQr", sqlConn);
                cmdLlave.Parameters.Add("@cadenaQr", SqlDbType.VarChar).Value = CadenaQr;
               

                SqlDataAdapter adaptador = new SqlDataAdapter();
                adaptador.SelectCommand = cmdLlave;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                return tabla;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar las activaciones " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }
    }
}
