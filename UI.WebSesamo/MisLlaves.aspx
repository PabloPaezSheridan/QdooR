<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisLlaves.aspx.cs" Inherits="UI.WebSesamo.MisLlaves" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="/css/bootstrap.css" type="text/css">
    <title></title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="text-center">
                <h1><asp:Label ID="lblTitulo" runat="server" Text="Mis Llaves" ForeColor="#009999"></asp:Label></h1>
            </div>	        
            <div class="row justify-content-center text-center">
                <asp:GridView ID="gvLlavesxUsuario" runat="server" AutoGenerateColumns="False" DataKeyNames="cadenaQr" class="table table-responsive table-striped table-hover" OnSelectedIndexChanged="gvGetLlavexUsuario_SelectedIndexChanged" BorderStyle="None">
                    <Columns>
                        <asp:BoundField DataField="cadenaQr" Visible="False" />
                        <asp:BoundField DataField="denominacion" HeaderText="Descripción" />
                        <asp:BoundField DataField="fechorCre" HeaderText="Creacion" />
                        <asp:BoundField DataField="fechorCad" HeaderText="Caducidad" />
                        <asp:CheckBoxField DataField="desechable" HeaderText="Desechable" />
                        <asp:CommandField SelectText="Detalle" ShowSelectButton="True" ButtonType="Button" />
                    </Columns>
                    <HeaderStyle BackColor="#009999" />
                </asp:GridView>   
             </div>
             <nav class="navbar navbar-expand-lg fixed-bottom navbar-dark bg-dark">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                      </button>
                      <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                        <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                           <li class="nav-item">
                            <asp:LinkButton ID="LinkButton2" Class="nav-link" OnClick="btnCrearLlave_Click" runat="server">
                                Crear Llave
                            </asp:LinkButton>
                          </li>
                          <li class="nav-item active">
                            <asp:LinkButton ID="LinkButton" Class="nav-link active" runat="server">Mis Llaves</asp:LinkButton>
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
        </div>
        <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
	</body>
</html>
