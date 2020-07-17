<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.WebSesamo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
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
        .auto-style9 {
            text-align: center;
            margin-left: 40px;
            height: 48px;
        }
        .auto-style10 {
            color: #009999;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style9">&nbsp; <span class="auto-style10">Inicio de Sesión</span></h1>
        <div class="auto-style4">
            <p class="auto-style7">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
                <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarnNombreUsuario" runat="server" CssClass="auto-style2" Text=" Ingreso mal el nombre de usario" Visible="False" Font-Size="Small"></asp:Label>
            </strong>
           <br>
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario"></asp:Label>
 &nbsp;&nbsp;
 <asp:TextBox ID="txtNombreUsuario" runat="server" BorderColor="#999999" BorderStyle="Solid" Width="150px"></asp:TextBox>
      
            <br /></p>
            <p class="auto-style7">
                &nbsp;<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarningContraseña" runat="server" CssClass="auto-style2" Text=" Ingresó mal la Contraseña" Visible="False" Font-Size="Small"></asp:Label>
            </strong>
        
            <br />
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
&nbsp; <asp:TextBox ID="txtContraseña" runat="server" BorderColor="#999999" BorderStyle="Solid" TextMode="Password" Width="141px"></asp:TextBox>
            </p>
        </div>
        <p class="auto-style6">
            <asp:LinkButton ID="btnLogin" runat="server" BorderStyle="Solid" OnClick="btnLogin_Click" Width="204px">LOGIN</asp:LinkButton>
        </p>
    </form>
</body>
</html>
