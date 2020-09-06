<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="UI.WebSesamo.Alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title></title>
    <style type="text/css">



		.auto-style2 {
			color: #009999;
		}
		  
        * {
    text-shadow: none !important;
    box-shadow: none !important;
  }
        		  
* {
  box-sizing: border-box;
}

        .auto-style3 {
            text-align: center;
        }
                .center{
    width:600px;
    margin-left:auto;
    margin-right:auto;
        }
        .auto-style4 {
            width: 251px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style5 {
            width: 211px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style6 {
            width: 585px;
            margin-left: auto;
            margin-right: auto;
        }
        .auto-style7 {
            color: #009999;
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="auto-style3">
            <h1>
				<asp:Label ID="lblTitulo" runat="server" CssClass="auto-style2" Text="Alta Inquilino"></asp:Label>
			</h1>
        </div>
        <div class="auto-style4">
            <asp:Panel ID="Panel1" runat="server" Width="277px">
                <asp:Label runat="server" Text="Edificio:  " ID="Label1"></asp:Label>
                <asp:DropDownList ID="ddlEdificiosxInmobiliaria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdificiosxInmobiliaria_SelectedIndexChanged" class="btn btn-secondary dropdown-toggle">
                </asp:DropDownList>
                <br />
                <br />
                <strong>
                <asp:Label ID="lblexito" runat="server" CssClass="auto-style2" Text="Usuario añadido exitosamente" Visible="False"></asp:Label>
                </strong>
            </asp:Panel>
        </div>
        <asp:Panel ID="panelCampos" runat="server">
            <div class="auto-style6">
                <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblWarnNombreUsuario" runat="server" CssClass="auto-style7" Font-Size="Small" ForeColor="Red" Text="El nombre no esta disponible" Visible="False"></asp:Label>
                </strong>
                <br />
                <asp:Label ID="Label6" runat="server" Text="Nombre Usuario: "></asp:Label>
                <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Height="22px" TextMode="Email"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server" Text="Nombre y Apellido: "></asp:Label>
                <asp:TextBox ID="txtNombreApellido" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Celular: "></asp:Label>
                <asp:TextBox ID="txtCelular" runat="server" Height="19px" TextMode="Number" Width="92px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Departamento: "></asp:Label>
                <asp:TextBox ID="txtDpto" runat="server" Width="128px"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Estado: "></asp:Label>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem>habilitado</asp:ListItem>
                    <asp:ListItem>deshabilitado</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Contraseña: "></asp:Label>
                <asp:TextBox ID="txtContraseña" runat="server"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                <br />
                <br />
            </div>
        </asp:Panel>
        <div class="auto-style5">
            <asp:Panel ID="panelConfirmar" runat="server">
                <div class="auto-style8">
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                </div>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
