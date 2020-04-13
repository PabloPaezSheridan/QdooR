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
    public partial class Login : System.Web.UI.Page
    {
        public static Usuario usr;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //public void MsgBox(String ex, Page pg, Object obj)
        //{
        //    string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        //    Type cstype = obj.GetType();
        //    ClientScriptManager cs = pg.ClientScript;
        //    cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        //}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioLogic usrlogic = new UsuarioLogic();
            usr = new Usuario();
            usr=usrlogic.GetOne(Int32.Parse(txtCP.Text), txtCalle.Text,txtNroCalle.Text,txtDpto.Text);
            if (usr.Dpto!= null)
            {
                if(usr.Contraseña==txtContraseña.Text)
                {
                    Session["usrActual"] = usr;
                    Server.Transfer("CrearLlave.aspx");
                }
                else
                {
                    this.lblWarningContraseña.Visible = true;

                    this.lblWarnCalle.Visible = false;
                    this.lblWarnCp.Visible = false;
                    this.lblWarnDpto.Visible = false;
                    this.lblWarnNro.Visible = false;
                    this.lblWarnDireccion.Visible = false;

                    this.txtContraseña.Text = String.Empty;
                }
            }

            else
            {
                this.lblWarningContraseña.Visible = false;

                this.lblWarnCalle.Visible = true;
                this.lblWarnCp.Visible = true;
                this.lblWarnDpto.Visible = true;
                this.lblWarnNro.Visible = true;
                this.lblWarnDireccion.Visible = true;

                this.txtContraseña.Text = String.Empty;

                this.txtCalle.Text = String.Empty;
                this.txtCP.Text = String.Empty;
                this.txtNroCalle.Text = String.Empty;
                this.txtDpto.Text = String.Empty;

            }

        }
    }
}