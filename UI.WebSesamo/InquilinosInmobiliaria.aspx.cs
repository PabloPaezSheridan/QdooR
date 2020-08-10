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
    public partial class InquilinosInmobiliaria : System.Web.UI.Page
    {
        static Usuario usrActual = new Usuario();
        static Inmobiliaria inmActual = new Inmobiliaria();

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
                        this.LoadGrid();
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

        protected void LoadDropDownList()
        {
            EdificioLogic el = new EdificioLogic();
            DataTable tabla = el.GetEdificiosxInmobiliaria(inmActual);
            this.ddlEdificiosxInmobiliaria.DataTextField = tabla.Columns["concatenacion"].ToString();
            this.ddlEdificiosxInmobiliaria.DataValueField = tabla.Columns["idEdificio"].ToString();
            this.ddlEdificiosxInmobiliaria.DataSource = tabla;
            this.ddlEdificiosxInmobiliaria.DataBind();
        }

        public void LoadGrid()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.gvInquilinosxEdificio.DataSource = ul.GetallxEdificio(Int32.Parse(ddlEdificiosxInmobiliaria.SelectedValue));
            this.gvInquilinosxEdificio.DataBind();

        }


        protected void ddlEdificiosxInmobiliaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        protected void gvInquilinosxEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            string nombreUsuario = gvInquilinosxEdificio.DataKeys[gvInquilinosxEdificio.SelectedRow.RowIndex]["nombreUsuario"].ToString();
            Usuario InquilinoActual = ul.GetOne(nombreUsuario);
            this.txtNombreUsuario.Text = InquilinoActual.NombreUsuario;
            this.txtNombreApellido.Text = InquilinoActual.NombreyApellido;
            this.txtEmail.Text = InquilinoActual.Email;
            this.txtContraseña.Text = InquilinoActual.Contraseña;
            this.txtCelular.Text = InquilinoActual.Celular.ToString();
            this.panelCampos.Visible = true;
            this.panelAcciones.Visible = true;
        }
    }
}