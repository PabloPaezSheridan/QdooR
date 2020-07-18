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
    public partial class DetalleLlave : System.Web.UI.Page
    {
        static Llave llaveActual = new Llave();
        static Edificio edificioActual = new Edificio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usrActual"] != null && Session["llaveActual"] != null)
            {
                llaveActual = (Llave)Session["llaveActual"];
                edificioActual = (Edificio)Session["edificioActual"];
                LoadGrid();
            }
            else
            {
                Session.Abandon();
                Server.Transfer("Login.aspx");
            }
        }

        public void LoadGrid()
        {
            LlaveLogic llaveLogic = new LlaveLogic();
            LlaveActivadaLogic lal = new LlaveActivadaLogic();

            this.lblCreacion.Text =llaveActual.fechayHoraCreacion.ToString();
            this.lblCaducacion.Text = llaveActual.fechayHoraCaducacion.ToString();
            this.lblDenominacion.Text = llaveActual.Denominacion;
            this.chkDesechable.Checked = llaveActual.desechable;
            this.gvLlavesActivadas.DataSource = lal.GetAllxLlave(llaveActual.CadenaQr);
            this.gvLlavesActivadas.DataBind();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            LlaveLogic llaveLogic = new LlaveLogic();
            llaveLogic.Inhabilitar(edificioActual.IdEdificio, llaveActual.CadenaQr);
            Server.Transfer("MisLlaves.aspx");
        }

        protected void MostrarImagen(Bitmap qrCodeImage)
        {
            Response.ContentType = "image/jpeg";
            Response.AppendHeader("Content-Disposition", "attachment; filename=qr.jpg");

            qrCodeImage.Save(Response.OutputStream, ImageFormat.Jpeg);

        }
        protected void btnDescargarQr_Click(object sender, EventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(llaveActual.CadenaQr, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            MostrarImagen(qrCodeImage);
        }

        protected void btnMisLlaves_Click(object sender, EventArgs e)
        {
            Server.Transfer("MisLlaves.aspx");
        }
    }
}