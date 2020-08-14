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
    public partial class AltaInquilino : System.Web.UI.Page
    {
        static Usuario usrActual = new Usuario();
        static Inmobiliaria inmActual = new Inmobiliaria();
        static Usuario InquilinoActual = new Usuario();


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

        protected void ddlEdificiosxInmobiliaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCelular.Text = "";
            txtContraseña.Text = "";
            txtEmail.Text = "";
            txtNombreApellido.Text = "";
            txtNombreUsuario.Text = "";
            txtDpto.Text = "";
            this.panelCampos.Visible = true;
            this.panelConfirmar.Visible = true;
            this.lblexito.Visible = false;
            this.lblWarnNombreUsuario.Visible = false;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.panelCampos.Visible = false;
            this.panelConfirmar.Visible = false;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            EdificioLogic el = new EdificioLogic();

            if (ul.GetOne(txtNombreUsuario.Text).NombreUsuario == null)
            {
                if (txtCelular.Text == "")
                {
                    InquilinoActual.Celular = null;
                }
                else
                {
                    InquilinoActual.Celular = Int64.Parse(txtCelular.Text);
                }
                InquilinoActual.Contraseña = txtContraseña.Text;
                InquilinoActual.Email = txtEmail.Text;
                InquilinoActual.Estado = ddlEstado.SelectedValue.ToString();
                InquilinoActual.NombreUsuario = txtNombreUsuario.Text;
                InquilinoActual.NombreyApellido = txtNombreApellido.Text;
                InquilinoActual.Tipo = "inquilino";

                ul.Insert(InquilinoActual, usrActual.NombreUsuario, DateTime.Now);
                el.InsertUsuarioEdificio(Int32.Parse(ddlEdificiosxInmobiliaria.SelectedValue), txtNombreUsuario.Text, txtDpto.Text);

                this.lblexito.Visible = true;
                this.panelCampos.Visible = false;
                this.panelConfirmar.Visible = false;
            }
            else
            {
                this.lblWarnNombreUsuario.Visible = true;
                txtCelular.Text = "";
                txtContraseña.Text = "";
                txtEmail.Text = "";
                txtNombreApellido.Text = "";
                txtNombreUsuario.Text = "";
                txtDpto.Text = "";
            }
        }
    }
}