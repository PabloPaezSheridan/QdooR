using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Business.Entities;
using Business.Logic;

namespace UI.WebSesamo
{
    /// <summary>
    /// Descripción breve de InteraccionDb
    /// </summary>
    [WebService(Namespace = "http://qdoor.somee.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class InteraccionDb : System.Web.Services.WebService
    {

        [WebMethod]
        public Boolean ValidarLlave(int CP, string calleEdificio, string nroCalleEdificio, string cadenaQr)
        {
            LlaveLogic lL = new LlaveLogic();
            Llave llaveActual = lL.GetOnexEdificio(cadenaQr, CP, calleEdificio, nroCalleEdificio);
            if (llaveActual != null && llaveActual.Habilitada)
            {
                if (llaveActual.desechable)
                {
                    llaveActual.Habilitada = false;
                    lL.Update(llaveActual);
                }
                //Deshabilito las llaves excedidas en su tiempo de caducidad cuando son probada (no cuando se excede su tiempo realmente), quizas sea mejor hacer esto en un trigger o en un sp que limpie la base constanemnte, pero esto alivia la base de datos
                else
                {
                    if(llaveActual.FechayHoraFin < DateTime.Now)
                    {
                        llaveActual.Habilitada = false;
                        return false;
                    }
                }

                LlaveActivadaLogic llal = new LlaveActivadaLogic();
                llal.Add(llaveActual);

                return true;
            }
            else
            {
                return false;
            }
            
        }

        [WebMethod]
        public int suma (int a, int b)
        {
            return a + b;
        }

    }
}
