<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleLlave.aspx.cs" Inherits="UI.WebSesamo.DetalleLlave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link rel="stylesheet" href="/css/bootstrap.css" type="text/css"/>
    <title></title>
    
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div class="text-center">
               <h1><asp:Label ID="lblTitulo" runat="server" Text="Detalle" ForeColor="#009999"></asp:Label></h1>
            </div>
            <div class="row justify-content-center">
                <strong>
                   <asp:Label runat="server" Text="Descripción:"></asp:Label>&nbsp
                </strong>
                <asp:Label ID="lblDenominacion" runat="server" Text="Label"></asp:Label>
            </div>
            <br />
            <div class="row justify-content-center">
                <asp:CheckBox ID="chkDesechable" runat="server" Enabled="False" Text="Desechable" />
            </div>
            <div class="row justify-content-center">
                <div class="col-4">
                    <div class="row">
                        <strong>
                            <asp:Label runat="server" Text="Creación:"></asp:Label>
                        </strong>
                        <asp:Label ID="lblCreacion" runat="server" Text="Label"></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                         <asp:Button ID="btnDescargarQr" runat="server" OnClick="btnDescargarQr_Click" Text="Descargar" Width="101px" />
                    </div>
                 </div>
                <div class="col-4">
                    <div class="row">
                        <strong>
                            <asp:Label ID="Label2" runat="server" Text="Caducacion:"></asp:Label>
                        </strong>
                        <asp:Label ID="lblCaducacion" runat="server" Text="Label"></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Width="100px" />
                    </div>
                </div>             
             </div>
            <br />
             <div class="row justify-content-center text-center">
                <asp:GridView ID="gvLlavesActivadas" runat="server" AutoGenerateColumns="False" class="table table-responsive table-striped table-hover" BorderStyle="None">
                    <Columns>
                        <asp:BoundField DataField="fechorAct" HeaderText="Activaciones de la llave" />
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
                          <li class="nav-item">
                            <asp:LinkButton ID="LinkButton" Class="nav-link" OnClick="btnMisLlaves_Click" runat="server">Mis Llaves</asp:LinkButton>
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
