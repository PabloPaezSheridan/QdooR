using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Globalization;
using Business.Entities;
using Business.Logic;

namespace UI.WebSesamo
{
    public partial class ListadoEdificios : System.Web.UI.Page
    {
        static Usuario usrActual = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usrActual"] != null)
            {
                usrActual = (Usuario)Session["usrActual"];
                LoadGrid();
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
        }

        public void LoadGrid()
        {
            EdificioLogic edificioLogic = new EdificioLogic();
            gvEdificiosxUsuario.DataSource = edificioLogic.GetEdificiosxUsuario(usrActual.NombreUsuario);
            gvEdificiosxUsuario.DataBind();
        }

        protected void gvEdificiosxUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            EdificioLogic edificioLogic = new EdificioLogic();
            int IdEdificio = Int32.Parse(gvEdificiosxUsuario.DataKeys[gvEdificiosxUsuario.SelectedRow.RowIndex]["idEdificio"].ToString());
            Session["edificioActual"] = edificioLogic.GetOne(IdEdificio);
            Server.Transfer("CrearLlave.aspx");
        }
    }
}