<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.WebSesamo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #009999;
            text-align: center;
        }
        .auto-style2 {
            color: #FF0000;
        }
        .auto-style4 {
            text-align: center;
        }
        .auto-style6 {
            text-align: center;
            margin-left: 40px;
        }
        .auto-style7 {
            text-align: center;
            margin-left: 40px;
            height: 82px;
        }
        .auto-style8 {
            text-align: center;
            margin-left: 40px;
            height: 89px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Inicio de Sesion</h1>
        <div class="auto-style4">
            <p class="auto-style8">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
                <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarnNombreUsuario" runat="server" CssClass="auto-style2" Text=" Ingreso mal el nombre de usario" Visible="False" Font-Size="Small"></asp:Label>
            </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNombreUsuario" runat="server" BorderColor="#999999" BorderStyle="Solid"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><strong>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
            <p class="auto-style7">
                &nbsp;<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarningContraseña" runat="server" CssClass="auto-style2" Text=" Ingresó mal la Contraseña" Visible="False" Font-Size="Small"></asp:Label>
            </strong>&nbsp;
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
            <br />
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
&nbsp; <asp:TextBox ID="txtContraseña" runat="server" BorderColor="#999999" BorderStyle="Solid" TextMode="Password"></asp:TextBox>
            </p>
        </div>
        <p class="auto-style6">
            <asp:LinkButton ID="btnLogin" runat="server" BorderStyle="Solid" OnClick="btnLogin_Click" Width="204px">LOGIN</asp:LinkButton>
        </p>
    </form>
</body>
</html>
