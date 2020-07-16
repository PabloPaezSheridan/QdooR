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
	public partial class MisLlaves : System.Web.UI.Page
	{
        static Usuario usrActual = new Usuario();
        static Edificio edificioActual = new Edificio();

        protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["usrActual"] != null)
            {
                usrActual = (Usuario)Session["usrActual"];
                edificioActual = (Edificio)Session["edificioActual"];
                LoadGrid();
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
        }

        public void LoadGrid()
        {
            LlaveLogic ll = new LlaveLogic();
            gvLlavesxUsuario.DataSource = ll.GetLlavesHabilitadasxUsuario(usrActual, edificioActual);
            gvLlavesxUsuario.DataBind();
        }

        
        protected void btnCrearLlave_Click(object sender, EventArgs e)
        {
            Server.Transfer("CrearLlave.aspx");
        }

        protected void gvGetLlavexUsuario_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void gvGetLlavexUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlaveLogic llaveLogic = new LlaveLogic();
            string cadenaQr = gvLlavesxUsuario.DataKeys[gvLlavesxUsuario.SelectedRow.RowIndex]["cadenaQr"].ToString();
            llaveLogic.Inhabilitar(edificioActual.IdEdificio, cadenaQr);
            LoadGrid();
        }

        //protected void gvGetLlavexUsuario_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DateTime fechayhoraini = DateTime.ParseExact("MM-dd-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        //    //DateTime fechayhoraini = DateTime.Parse(gvGetLlavesxUsuario.SelectedRow.Cells[0].Text); /// esto es el problema no se guara nada en fechahoraini
        //    LlaveLogic llaveLogic = new LlaveLogic();
        //    llaveLogic.Inhabilitar(usrActual.Dpto, usrActual.CodigoPostalEdificio, usrActual.CalleEdificio, usrActual.NroCalleEdificio, fechayhoraini);
        //    LoadGrid();
        //}
    }
}