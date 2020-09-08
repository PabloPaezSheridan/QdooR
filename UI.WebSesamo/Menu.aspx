<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="UI.WebSesamo.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Menu</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col text-center">
                    <h2>
                        <asp:Label ID="lblInmobiliaria" runat="server" ForeColor="#009999"></asp:Label>
                    </h2>
                    <br />
                    <h3>
                        <asp:Label ID="lblusr" runat="server"></asp:Label>
                    </h3>
                </div>
           </div>
        </div>
    </form>
</asp:Content>




