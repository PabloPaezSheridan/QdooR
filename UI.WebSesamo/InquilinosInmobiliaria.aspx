<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InquilinosInmobiliaria.aspx.cs" Inherits="UI.WebSesamo.InquilinosInmobiliaria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">


		.auto-style2 {
			color: #009999;
		}
		  
* {
  box-sizing: border-box;
}

        * {
    text-shadow: none !important;
    box-shadow: none !important;
  }
        .center{
    width:600px;
    margin-left:auto;
    margin-right:auto;
        }

        .auto-style4 {
            width: 376px;
            margin-left: auto;
            margin-right: auto;
        }

        .auto-style5 {
            margin-top: 0px;
        }

        .auto-style6 {
            width: 145px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style7 {
            width: 167px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style8 {
            width: 208px;
            margin-left: auto;
            margin-right: auto;
        }

        .auto-style9 {
            text-align: center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style6">
				<asp:Label ID="lblTitulo" runat="server" CssClass="auto-style2" Text="Inquilinos"></asp:Label>
			</h1>
        </div>
&nbsp;&nbsp;&nbsp;
        <br />
        <div class="center">
            <asp:Panel ID="Panel1" runat="server" Width="594px">
                <asp:Label runat="server" Text="Seleccion edificio: "></asp:Label>
                <asp:DropDownList ID="ddlEdificiosxInmobiliaria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdificiosxInmobiliaria_SelectedIndexChanged">
             </asp:DropDownList>
                <br />
                <br />
                <div class="auto-style4">
                    <asp:GridView ID="gvInquilinosxEdificio" runat="server" AutoGenerateColumns="False" DataKeyNames="nombreUsuario" CssClass="auto-style5" OnSelectedIndexChanged="gvInquilinosxEdificio_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="nombreUsuario" Visible="False" />
                            <asp:BoundField DataField="nombreyApellido" HeaderText="Nombre y Apellido" />
                            <asp:BoundField DataField="celular" HeaderText="Celular" />
                            <asp:BoundField DataField="email" HeaderText="Email" />
                            <asp:CommandField ButtonType="Button" SelectText="Seleccionar" ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle BackColor="#009999" />
                    </asp:GridView>
                    <br />
                </div>
            </asp:Panel>

             
         </div>
        <br />
        <asp:Panel ID="panelCampos" runat="server" Visible="False">
            <div class="center">
                <asp:Label ID="Label1" runat="server" Text="Nombre Usuario: "></asp:Label>
                <asp:TextBox ID="txtNombreUsuario" runat="server" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Visible="False" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server" Text="Nombre y Apellido: "></asp:Label>
                <asp:TextBox ID="txtNombreApellido" runat="server" Visible="False" Enabled="False"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Celular: "></asp:Label>
                <asp:TextBox ID="txtCelular" runat="server" Visible="False" Enabled="False"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="txtContraseña" runat="server" Enabled="False"></asp:TextBox>
                <br />
            </div>
        </asp:Panel>
        <asp:Panel ID="panelAcciones" runat="server" Visible="False">
            <div class="auto-style7">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnEditar" runat="server" Text="Editar" />
            </div>
        </asp:Panel>
        <div class="auto-style3">
            <asp:Panel ID="panelConfirmar" runat="server" Visible="False">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <div class="auto-style8">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" />
                </div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
