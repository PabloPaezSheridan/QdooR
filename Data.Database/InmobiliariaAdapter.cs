using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Business.Entities;


namespace Data.Database
{
    public class InmobiliariaAdapter : Adapter
    {
        public Inmobiliaria GetOnexUsuario(Usuario usrInmobiliaria)
        {
            Inmobiliaria inmobiliaria = new Inmobiliaria();
            try
            {
                this.OpenConnection();
                SqlCommand cmdInmobiliaria = new SqlCommand("select * from Inmobiliarias i where i.cuit = @cuitUsr", sqlConn);
               
                cmdInmobiliaria.Parameters.Add("@cuitUsr", SqlDbType.BigInt).Value = usrInmobiliaria.Cuit;
                SqlDataReader drInmobiliarias = cmdInmobiliaria.ExecuteReader();
                if (drInmobiliarias.Read())
                {
                    inmobiliaria.Cuit = (Int64)drInmobiliarias["cuit"];
                    inmobiliaria.Denominacion = (string)drInmobiliarias["denominacion"];
                    inmobiliaria.Telefono = (Int64)drInmobiliarias["telefono"];
                    inmobiliaria.Email = (string)drInmobiliarias["email"];
                }
                drInmobiliarias.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la inmobiliaria: " + Ex.Message, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inmobiliaria;
        }
    }
}
