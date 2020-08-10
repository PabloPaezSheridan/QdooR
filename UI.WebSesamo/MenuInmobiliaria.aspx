<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuInmobiliaria.aspx.cs" Inherits="UI.WebSesamo.MenuInmobiliaria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

		.auto-style2 {
			color: #009999;
		}
		*,
  *::before,
  *::after {
    text-shadow: none !important;
    box-shadow: none !important;
  }
  
*,
*::before,
*::after {
  box-sizing: border-box;
}

        .auto-style3 {
            text-align: center;
        }
                .center{
    width:600px;
    margin-left:auto;
    margin-right:auto;
        }
        .auto-style4 {
            width: 408px;
            margin-left: auto;
            margin-right: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style3">
				<asp:Label ID="lblTitulo" runat="server" CssClass="auto-style2" Text="Sistema de Gestion Inmobiliaria"></asp:Label>
			</h1>
            <h3 class="auto-style3">
                <asp:Label ID="lblInmobiliaria" runat="server" ForeColor="#999999"></asp:Label>
            </h3>
            <h3 class="auto-style3">
                <asp:Label ID="lblusr" runat="server" ForeColor="#999999"></asp:Label>
            </h3>
        </div>
        <div class="auto-style4">
            <asp:Panel ID="Panel1" runat="server">
                <asp:Button ID="btnAlta" runat="server" Text="Alta Inquilino" OnClick="btnAlta_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBaja" runat="server" Text="Baja Inquilino" OnClick="btnBaja_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAccesos" runat="server" OnClick="btnAccesos_Click" Text="Ver Accesos" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
