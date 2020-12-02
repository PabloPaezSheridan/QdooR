<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alta.aspx.cs" Inherits="UI.WebSesamo.Alta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Alta Inquilino</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
            <div class ="row justify-content-center text-center">
                 <h1><asp:Label ID="lblTitulo" runat="server" Text="Alta Inquilino" ForeColor="#009999"></asp:Label></h1>
            </div>
            <br />
            <asp:Panel ID="Panel1" runat="server">
                <div class="row justify-content-center">
                    <h4><asp:Label runat="server" Text="Edificio:" ID="Label1"></asp:Label>&nbsp;</h4>
                    <asp:DropDownList ID="ddlEdificiosxInmobiliaria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdificiosxInmobiliaria_SelectedIndexChanged" class="btn btn-secondary btn-sm dropdown-toggle">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <strong><asp:Label ID="lblexito" runat="server" Text="Usuario añadido exitosamente" Visible="False"></asp:Label></strong>
                </div>
                <br />
                <br />
          </asp:Panel>
                <asp:Panel ID="panelCampos" runat="server" Visible="False">
                    <div class="row justify-content-center">
                        <div class="col-5">
                            <div class="container">
                               <div class="row">
                                <strong><asp:Label ID="lblWarnNombreUsuario" runat="server" Font-Size="Small" ForeColor="Red" Text="El nombre no esta disponible" Visible="False"></asp:Label></strong>
                                <h5><asp:Label ID="Label2" runat="server" Text="Nombre Usuario: "></asp:Label></h5>
                                <asp:TextBox ID="txtNombreUsuario" runat="server" type="text" CssClass="form-control"></asp:TextBox>
                               </div> 
                                <br />
                               <div class="row"> 
                                <h5><asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label></h5>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                               </div>  
                                <br />
                               <div class="row"> 
                                 <h5><asp:Label runat="server" Text="Nombre y Apellido: "></asp:Label></h5>
                                 <asp:TextBox ID="txtNombreApellido" runat="server" CssClass="form-control" type="text" ></asp:TextBox>
                               </div> 
                            </div>
                        </div>
                        <div class="col-5">
                            <div class="container">
                                <div class="row">
                                    <h5><asp:Label ID="Label4" runat="server" Text="Celular: "></asp:Label></h5>
                                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </div>
                                <br />
                                <div class="row">
                                    <h5><asp:Label ID="Label5" runat="server" Text="Contraseña: "></asp:Label></h5>
                                    <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" type="text"></asp:TextBox>                     
                                </div>
                                <br />
                                <div class="row">
                                    <h5><asp:Label ID="Label6" runat="server" Text="Estado: "></asp:Label></h5>
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control form-control-sm">
                                        <asp:ListItem>habilitado</asp:ListItem>
                                        <asp:ListItem>deshabilitado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <br />
                            </div>
                        </div>
                        <div class="row justify-content-center"> 
                           <h5><asp:Label ID="Label7" runat="server" Text="Departamento: "></asp:Label></h5>
                            <asp:TextBox ID="txtDpto" runat="server" CssClass="form-control" type="text" ></asp:TextBox>
                        </div>
                 </div>
              </asp:Panel>
                 <div class="row justify-content-center"> 
                        <asp:Panel ID="panelConfirmar" runat="server" Visible="False">
                            <br />
                            <asp:Button ID="btnCancelar" runat="server" class="btn btn-outline-secondary" Text="Cancelar" OnClick="btnCancelar_Click" /> 
                            <asp:Button ID="btnConfirmar" runat="server" class="btn btn-outline-primary" Text="Confirmar" OnClick="btnConfirmar_Click" />
                         </asp:Panel>
                </div> 
    </form>
</asp:Content>
