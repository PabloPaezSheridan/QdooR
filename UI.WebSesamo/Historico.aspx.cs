using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business.Entities;
using Business.Logic;
using System.Data;

namespace UI.WebSesamo
{
    public partial class Historico : System.Web.UI.Page
    {
        static Usuario usrActual = new Usuario();
        static Inmobiliaria inmActual = new Inmobiliaria();
        static Usuario InquilinoActual = new Usuario();
        static DateTime fechaInicio = new DateTime();
        static DateTime fechaFin = new DateTime();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usrActual"] != null)
            {
                usrActual = (Usuario)Session["usrActual"];
                inmActual = (Inmobiliaria)Session["inmobiliariaActual"];

                if (usrActual.Tipo == "inmobiliaria")
                {
                    if (!this.IsPostBack)
                    {
                        this.LoadDropDownList();
                        this.calInicio.SelectedDate = DateTime.Now.AddDays(-7);
                        this.calFin.SelectedDate = DateTime.Now;
                    }

                }
                else
                {
                    Server.Transfer("Login.aspx");
                }

            }
            else
            {
                Server.Transfer("Login.aspx");
            }
        }
        protected void LoadgdvHistorico(int idEdificio, DateTime fechahoraIni, DateTime fechahoraFin)
        {
            EdificioLogic el = new EdificioLogic();
            this.gdvHistorico.DataSource = el.GetLlavesActivadasxEdificioyRango(idEdificio, fechahoraIni, fechahoraFin);
            this.gdvHistorico.DataBind();
        }

        protected void LoadDropDownList()
        {
            EdificioLogic el = new EdificioLogic();
            DataTable tabla = el.GetEdificiosxInmobiliaria(inmActual);
            this.ddlEdificiosxInmobiliaria.DataTextField = tabla.Columns["concatenacion"].ToString();
            this.ddlEdificiosxInmobiliaria.DataValueField = tabla.Columns["idEdificio"].ToString();
            this.ddlEdificiosxInmobiliaria.DataSource = tabla;
            this.ddlEdificiosxInmobiliaria.DataBind();
        }

        protected void ddlEdificiosxInmobiliaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadgdvHistorico(Int32.Parse(ddlEdificiosxInmobiliaria.SelectedValue), calInicio.SelectedDate, calFin.SelectedDate);
        }

        protected void calInicio_SelectionChanged(object sender, EventArgs e)
        {
            this.LoadgdvHistorico(Int32.Parse(ddlEdificiosxInmobiliaria.SelectedValue), calInicio.SelectedDate, calFin.SelectedDate);
        }

        protected void calFin_SelectionChanged(object sender, EventArgs e)
        {
            this.LoadgdvHistorico(Int32.Parse(ddlEdificiosxInmobiliaria.SelectedValue), calInicio.SelectedDate, calFin.SelectedDate);
        }
    }
}
