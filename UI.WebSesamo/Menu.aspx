<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="UI.WebSesamo.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title></title>
    <style type="text/css">

		.auto-style2 {
			color: #009999;
		}
		*,
  *::before,
  *::after {
    text-shadow: none !important;
    box-shadow: none !important;
  }
  
*,
*::before,
*::after {
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style3">
				<asp:Label ID="lblTitulo" runat="server" CssClass="auto-style2" Text="Sistema de Gestion Inmobiliaria"></asp:Label>
			</h1>
            <h3 class="auto-style3">
                <asp:Label ID="lblInmobiliaria" runat="server" ForeColor="#999999"></asp:Label>
            </h3>
            <h3 class="auto-style3">
                <asp:Label ID="lblusr" runat="server" ForeColor="#999999"></asp:Label>
            </h3>
        </div>
    </form>
</asp:Content>
