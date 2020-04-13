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
            margin-left: 40px;
        }
    </style>
   
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="auto-style1">&nbsp;&nbsp;&nbsp;&nbsp; Inicio de Sesion</h1>
        <div class="auto-style4">
            <p class="auto-style7">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarnCp" runat="server" Font-Bold="True" ForeColor="Red" Text="*" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarnDpto" runat="server" Font-Bold="True" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="CP:"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:TextBox ID="txtCP" runat="server" TextMode="Number" Width="63px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" Text="Dpto"></asp:Label>
            :&nbsp;&nbsp;
            <asp:TextBox ID="txtDpto" runat="server" Width="50px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarnCalle" runat="server" Font-Bold="True" ForeColor="Red" Text="*" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarnNro" runat="server" Font-Bold="True" ForeColor="Red" Text="*" Visible="False"></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text="Calle"></asp:Label>
            :&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCalle" runat="server" Width="105px"></asp:TextBox>
            &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Nro Calle"></asp:Label>
            : &nbsp;<asp:TextBox ID="txtNroCalle" runat="server" Width="50px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><strong>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblWarnDireccion" runat="server" CssClass="auto-style2" Text=" Ingreso mal algun elemento de la dirección o del Dpto" Visible="False" Font-Size="Small"></asp:Label>
            </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
            <br />&nbsp;&nbsp;&nbsp; <strong>
            <asp:Label ID="lblWarningContraseña" runat="server" CssClass="auto-style2" Text=" Ingresó mal la Contraseña" Visible="False"></asp:Label>
            </strong>
            </p>
        </div>
        <p class="auto-style4">
            &nbsp;&nbsp;
            <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
&nbsp;<asp:TextBox ID="txtContraseña" runat="server" BorderColor="#999999" BorderStyle="Solid" TextMode="Password"></asp:TextBox>
        </p>
        <p class="auto-style4">
            &nbsp;</p>
        <p class="auto-style6">
            <asp:LinkButton ID="btnLogin" runat="server" BorderStyle="Solid" OnClick="btnLogin_Click" Width="204px">LOGIN</asp:LinkButton>
        </p>
    </form>
</body>
</html>
