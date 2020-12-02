<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearLlave.aspx.cs" Inherits="UI.WebSesamo.CrearLlave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="/css/bootstrap.css" type="text/css">
    <title></title>
	
</head>
<body d-flex flex-column min-vh-100>
    <form id="form1" runat="server">
        <div class="container" style="display: flex;">
                <div class="text-center p-3 w-100" style="margin: auto">
                     <h4><asp:Label ID="lblEdificio" runat="server"></asp:Label></h4>
                     <br />
        	         <h1 class="text-center">
				        <asp:Label ID="lblTitulo" runat="server" Text="QdooR" ForeColor="#009999"></asp:Label>
			        </h1>
                
                    <h4 class="text-center mt-5">
				        <asp:Label ID="lblDesechable" runat="server" Text="Desechable"></asp:Label>
				        <asp:CheckBox ID="chkDesechable" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="chkDesechable_CheckedChanged" />
			        </h4>
                    <h4 class="mt-5">
				        <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                        <asp:TextBox ID="txtDenomLlave" runat="server" Width="162px"></asp:TextBox>
                    </h4>
			        <h4 class="text-center mt-5">
				        <asp:Label ID="lblDuracion" runat="server" Enabled="False" Text="Duración"></asp:Label>
				        <asp:DropDownList ID="ddlDuracion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDuracion_SelectedIndexChanged" Enabled="False">
					        <asp:ListItem Selected="True" Value="360">5 Minutos</asp:ListItem>
					        <asp:ListItem Value="900">15 Minutos</asp:ListItem>
					        <asp:ListItem Value="86400">1 Dia</asp:ListItem>
					        <asp:ListItem Value="604800">1 semana</asp:ListItem>
				        </asp:DropDownList>
			        </h4>
                    <div class="text-center mt-5">
				        <asp:LinkButton ID="btnCrearLlave" Class="btn btn-primary btn-block" runat="server" BorderStyle="Solid" OnClick="btnCrearLlave_Click" Width="167px">Crear Llave</asp:LinkButton>
                    </div>
		        </div>
        </div>
        <nav class="navbar navbar-expand-lg fixed-bottom navbar-dark bg-dark">
          <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
          </button>
          <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
            <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
              <li class="nav-item active">
                <asp:LinkButton ID="LinkButton2" Class="nav-link active" runat="server">
                    Crear Llave
                </asp:LinkButton>
              </li>
              <li class="nav-item">
                <asp:LinkButton ID="LinkButton" Class="nav-link" runat="server" OnClick="btnMisLlaves_Click">Mis Llaves</asp:LinkButton>
              </li>
              <li class="nav-item">
                <asp:LinkButton ID="LinkButton1" Class="nav-link" runat="server" OnClick="btnLogin_Click">Cerrar Sesion</asp:LinkButton>
              </li>
              <li class="nav-item">
                  <asp:Label ID="lblNombre" Class="nav-link disabled" runat="server"></asp:Label>
              </li>
            </ul>
          </div>
        </nav>
    </form>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    </body>
</html>
