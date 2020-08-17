<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.WebSesamo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="/css/bootstrap.css" type="text/css">
    <title></title>

   
</head>
<body  class="row justify-content-center align-items-center ">
   <div class="col-sm-4 ">
    <form id="form1" runat="server" >
        
            <h1><span>Inicio de Sesión</span></h1>
        
           
            <br />
                <strong>
                     <asp:Label ID="lblWarnNombreUsuario" runat="server" Text=" Ingreso mal el nombre de usario" Visible="False" Font-Size="Small"></asp:Label>
                </strong>
               <br>
            <div class="form-group">
                 <asp:Label ID="lblNombreUsuario" runat="server" Text="Usuario" ></asp:Label>
                 <asp:TextBox ID="txtNombreUsuario" runat="server"  class="form-control" type="text"  Width="290px"></asp:TextBox>
            </div>
            <br />
           
                <strong>
            <asp:Label ID="lblWarningContraseña" runat="server" Text=" Ingresó mal la Contraseña" Visible="False" Font-Size="Small"></asp:Label>
            </strong>
        
            <br />
            <div class="form-group">
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="txtContraseña" runat="server" class="form-control"  type="password"  TextMode="Password" Width="290px"></asp:TextBox>
            </div>
                
        
        <br />
        
            <asp:LinkButton ID="btnLogin" runat="server" Class="btn btn-primary" BorderStyle="Solid" OnClick="btnLogin_Click" Width="290px">LOGIN</asp:LinkButton>
     
    </form>
 </div>
</body>
</html>
