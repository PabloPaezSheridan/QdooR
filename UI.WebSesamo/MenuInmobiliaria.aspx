﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuInmobiliaria.aspx.cs" Inherits="UI.WebSesamo.MenuInmobiliaria" %>

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
            width: 567px;
            margin-left: auto;
            margin-right: auto;
            height: 42px;
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
            <asp:Panel ID="Panel1" runat="server" Height="46px" Width="562px">
                <asp:Button ID="btnAlta" runat="server" Text="Alta Inquilino" OnClick="btnAlta_Click" Height="36px" Width="165px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBaja" runat="server" Text="Baja/Modificacion Inquilino" OnClick="btnBaja_Click" Height="36px" Width="164px" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnAccesos" runat="server" OnClick="btnAccesos_Click" Text="Ver Accesos" Height="36px" Width="164px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
