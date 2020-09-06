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
            EdificioLogic edfLogic = new EdificioLogic();
            usr = new Usuario();
            usr=usrlogic.GetOne(txtNombreUsuario.Text);

            if (usr.NombreUsuario!= null)
            {
                if(usr.Contraseña==txtContraseña.Text) 
                {
                    Session["usrActual"] = usr;
                    if (usr.Tipo == "inquilino" && usr.Estado == "habilitado")
                    {                        
                        if (edfLogic.ContarEdificios(usr.NombreUsuario) < 2)
                        {
                            Session["edificioActual"] = edfLogic.GetOnexUsuario(usr.NombreUsuario);
                            Server.Transfer("CrearLlave.aspx");
                        }
                        else
                        {
                            Server.Transfer("ListadoEdificios.aspx");
                        }
                        
                    }
                    else if (usr.Tipo == "inmobiliaria")
                    {
                        Server.Transfer("Menu.aspx");
                    }
                    
                }
                else
                {
                    this.lblWarningContraseña.Visible = true;
                    this.lblWarnNombreUsuario.Visible = false;
                    this.txtContraseña.Text = String.Empty;
                }
            }

            else
            {
                this.lblWarningContraseña.Visible = false;
                this.lblWarnNombreUsuario.Visible = true;
                this.txtContraseña.Text = String.Empty;
                this.txtNombreUsuario.Text = String.Empty;
            }

        }
    }
}