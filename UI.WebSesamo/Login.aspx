<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.WebSesamo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="/css/bootstrap.css" type="text/css">
    <title></title>

   
</head>
<body>
   <div class="container" style="margin-top:10rem">
                <form id="form1" runat="server" >
                    <div class="justify-content-center text-center">
                    <h1><span>Inicio de Sesión</span></h1>
                    <br />
                        <strong>
                                <asp:Label ID="lblWarnNombreUsuario" runat="server" Text=" Ingreso mal el nombre de usario" Visible="False" Font-Size="Small" ForeColor="Red"></asp:Label>
                        </strong>
                        <br>
                    <div class="form-group">
                        <asp:TextBox ID="txtNombreUsuario" runat="server"  class="form-control" type="text" style="margin:auto;" Width="290px" placeholder="Nombre de usuario"></asp:TextBox>
                        <br />
                        <strong>
                            <asp:Label ID="lblWarningContraseña" runat="server" Text=" Ingresó mal la Contraseña" Visible="False" Font-Size="Small" ForeColor="Red"></asp:Label>
                        </strong>
                        <br />
                        <asp:TextBox ID="txtContraseña" runat="server" class="form-control"  type="password" style="margin:auto;" TextMode="Password" Width="290px" placeholder="Contraseña"></asp:TextBox>
                        <br />
                        <asp:LinkButton ID="btnLogin" runat="server" Class="btn btn-primary" BorderStyle="Solid" OnClick="btnLogin_Click" Width="290px">LOGIN</asp:LinkButton>
                    </div>
                    </div>
                </form>
            </div>
</body>
</html>
