<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoEdificios.aspx.cs" Inherits="UI.WebSesamo.ListadoEdificios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="/css/bootstrap.css" type="text/css">
    <title></title>
    
</head>
<body>
    <div class="container" style = "margin-top:10rem">
        <form id="form1" runat="server" style="margin: auto;">
            <div class="text-center"><h1>Edificios</h1></div>  
            <br />
            <div class="row justify-content-center text-center">
                    <asp:GridView ID="gvEdificiosxUsuario" runat="server" AutoGenerateColumns="False" DataKeyNames="idEdificio" class="table table-responsive table-striped table-hover" OnSelectedIndexChanged="gvEdificiosxUsuario_SelectedIndexChanged" BorderStyle="None">
                        <Columns>
                            <asp:BoundField DataField="idEdificio" Visible="False" />
                            <asp:BoundField DataField="denominacion" HeaderText="Nombre" />
                            <asp:BoundField DataField="calle" HeaderText="Calle" />
                            <asp:BoundField DataField="nroCalle" HeaderText="Número" />
                            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Button" />
                        </Columns>
                        <HeaderStyle BackColor="#009999" />
                    </asp:GridView>
            </div>
        </form>
    </div>
</body>
</html>
