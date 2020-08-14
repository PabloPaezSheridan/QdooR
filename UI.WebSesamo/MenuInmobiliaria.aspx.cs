using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business.Entities;
using Business.Logic;

namespace UI.WebSesamo
{
    public partial class MenuInmobiliaria : System.Web.UI.Page
    {
        static Usuario usrActual = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usrActual"] != null)
            {
                InmobiliariaLogic il = new InmobiliariaLogic();
                Inmobiliaria inmobiliariaActual = new Inmobiliaria();

                usrActual = (Usuario)Session["usrActual"];
                inmobiliariaActual = il.GetOnexUsuario(usrActual);
                Session["inmobiliariaActual"] = inmobiliariaActual;

                this.lblInmobiliaria.Text = inmobiliariaActual.Denominacion;
                this.lblusr.Text = usrActual.NombreyApellido;
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Server.Transfer("AltaInquilino.aspx");
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            Server.Transfer("InquilinosInmobiliaria.aspx");
        }

        protected void btnAccesos_Click(object sender, EventArgs e)
        {

        }
    }
}