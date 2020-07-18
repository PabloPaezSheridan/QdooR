using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business.Entities;
using Business.Logic;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;


namespace UI.WebSesamo
{
    public partial class CrearLlave : System.Web.UI.Page
    {
        static int dur;
        static Usuario usrActual = new Usuario();
        static Edificio edificioActual = new Edificio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usrActual"] != null)
            {
                usrActual = (Usuario)Session["usrActual"];
                edificioActual = (Edificio)Session["edificioActual"];
            }
            else
            {
                Server.Transfer("Login.aspx");
            }    
        }

        protected void chkDesechable_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDesechable.Checked == true)
            {
                this.lblDuracion.Enabled = false;
                this.ddlDuracion.Enabled = false;

            }
            else if (this.chkDesechable.Checked == false)
            {
                this.lblDuracion.Enabled = true;
                this.ddlDuracion.Enabled = true;

            }
            else
            {

            }

        }


        protected void ddlDuracion_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (ddlDuracion.SelectedValue)
            {
                case "360":
                    dur = 360;
                    break;
                case "900":
                    dur = 900;
                    break;
                case "86400":
                    dur = 86400;
                    break;
                case "604800":
                    dur = 604800;
                    break;
                default:
                    break;
            }


        }

        protected string GenerarCadenaAleatoria(int longitud)
        {
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");
            return token;

        }

        protected void MostrarImagen(Bitmap qrCodeImage)
        {
            Response.ContentType = "image/jpeg";
            Response.AppendHeader("Content-Disposition", "attachment; filename=qr.jpg");

            qrCodeImage.Save(Response.OutputStream, ImageFormat.Jpeg);

        }

        protected void btnCrearLlave_Click(object sender, EventArgs e)
        {
            Llave llave = new Llave();
            LlaveLogic llaveLogic = new LlaveLogic();

            llave.CadenaQr = GenerarCadenaAleatoria(50);
            llave.IdEdificio = edificioActual.IdEdificio;
            llave.NombreUsuario = usrActual.NombreUsuario;
            llave.fechayHoraCreacion = llaveLogic.FechaFomateada(DateTime.Now);
            llave.Habilitada = true;
            if(this.txtDenomLlave.Text == "")
            {
                llave.Denominacion = "Sin descripcion";
            }
            else
            {
                llave.Denominacion = this.txtDenomLlave.Text;
            }
                                          
            if (this.chkDesechable.Checked)
            {
                llave.fechayHoraCaducacion = llaveLogic.FechaFomateada(DateTime.Now.AddDays(7));
                llave.desechable = this.chkDesechable.Checked;
            }
            else
            {
                llave.fechayHoraCaducacion = llaveLogic.FechaFomateada(DateTime.Now.AddSeconds(dur));
                llave.desechable = this.chkDesechable.Checked;
            }
            llaveLogic.Create(llave);
            
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(llave.CadenaQr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            MostrarImagen(qrCodeImage);

        }

        protected void btnMisLlaves_Click(object sender, EventArgs e)
        {
            Server.Transfer("MisLlaves.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Server.Transfer("Login.aspx");
        }
    }
}