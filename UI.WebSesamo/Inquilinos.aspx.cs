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
    public partial class Inquilinos : System.Web.UI.Page
    {
        static Usuario usrActual = new Usuario();
        static Inmobiliaria inmActual = new Inmobiliaria();
        static Usuario InquilinoActual = new Usuario();
        static string accion;

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
            InquilinoActual = ul.GetOne(nombreUsuario);
            this.txtNombreUsuario.Text = InquilinoActual.NombreUsuario;
            this.txtNombreApellido.Text = InquilinoActual.NombreyApellido;
            this.txtEmail.Text = InquilinoActual.Email;
            this.txtContraseña.Text = InquilinoActual.Contraseña;
            this.ddlEstado.SelectedValue = InquilinoActual.Estado;
            if (InquilinoActual.Celular.ToString() != "")
            {
                this.txtCelular.Text = InquilinoActual.Celular.ToString();
            }
            else
            {
                this.txtCelular.Text = "Sin numero";
            }
            this.txtCelular.Text = InquilinoActual.Celular.ToString();
            this.panelCampos.Visible = true;
            this.panelAcciones.Visible = true;

            txtCelular.Enabled = false;
            txtContraseña.Enabled = false;
            txtEmail.Enabled = false;
            txtNombreApellido.Enabled = false;
            ddlEstado.Enabled = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            accion = "eliminar";
            panelAcciones.Visible = false;
            panelConfirmar.Visible = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            accion = "editar";
            txtCelular.Enabled = true;
            txtContraseña.Enabled = true;
            txtEmail.Enabled = true;
            txtNombreApellido.Enabled = true;
            ddlEstado.Enabled = true;
            panelAcciones.Visible = false;
            panelConfirmar.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            accion = null;
            panelAcciones.Visible = true;
            panelConfirmar.Visible = false;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            if (accion == "eliminar")
            {
                ul.bajaUsuarioxInmobiliaria(this.txtNombreUsuario.Text, Int32.Parse(ddlEdificiosxInmobiliaria.SelectedValue));

            }
            else if (accion == "editar")
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

                ul.Update(InquilinoActual, usrActual.NombreUsuario, DateTime.Now);
            }


            panelAcciones.Visible = false;
            panelCampos.Visible = false;
            panelConfirmar.Visible = false;
            LoadGrid();
        }
    }
}
