<%@ Page Title="Edicion y Baja" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inquilinos.aspx.cs" Inherits="UI.WebSesamo.Inquilinos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <br />
        <div class="container">
                <div class ="row justify-content-center text-center">
                    <h1><asp:Label ID="lblTitulo" runat="server" Text="Inquilinos" ForeColor="#009999"></asp:Label>	</h1>
                </div>
                    <br />
                <div class="row justify-content-center text-center">
                    <asp:Panel ID="Panel1" runat="server" BorderStyle="None">
                        <h4><asp:Label runat="server" Text="Seleccion edificio: "></asp:Label></h4>
                        <asp:DropDownList ID="ddlEdificiosxInmobiliaria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdificiosxInmobiliaria_SelectedIndexChanged" class="btn btn-secondary btn-sm dropdown-toggle">
                        </asp:DropDownList>
                        <br />
                        <br />
                        <asp:GridView ID="gvInquilinosxEdificio" runat="server" AutoGenerateColumns="False" DataKeyNames="nombreUsuario" class="table table-responsive table-striped table-hover" OnSelectedIndexChanged="gvInquilinosxEdificio_SelectedIndexChanged" BorderStyle="None">
                                <Columns>
                                    <asp:BoundField DataField="nombreUsuario" Visible="False" />
                                    <asp:BoundField DataField="nombreyApellido" HeaderText="Nombre y Apellido" />
                                    <asp:BoundField DataField="celular" HeaderText="Celular" />
                                    <asp:BoundField DataField="email" HeaderText="Email" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:CommandField ButtonType="Button" SelectText="Seleccionar" ShowSelectButton="True" />
                                </Columns>
                               <HeaderStyle CssClass="thead-dark" />
                            </asp:GridView>
                            <br />
                    </asp:Panel>
                </div>
       
               <asp:Panel ID="panelCampos" runat="server" Visible="False">
                    <div class="row justify-content-center">
                        <div class="col-5">
                            <div class="container">
                               <div class="row">
                                <h5><asp:Label ID="Label1" runat="server" Text="Nombre Usuario: "></asp:Label></h5>
                                <asp:TextBox ID="txtNombreUsuario" runat="server" type="text" CssClass="form-control-plaintext" Enabled="False"></asp:TextBox>
                               </div> 
                                <br />
                               <div class="row"> 
                                <h5><asp:Label ID="Label2" runat="server" Text="Email: "></asp:Label></h5>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="False" TextMode="Email"></asp:TextBox>
                               </div>  
                                <br />
                               <div class="row"> 
                                 <h5><asp:Label runat="server" Text="Nombre y Apellido: "></asp:Label></h5>
                                 <asp:TextBox ID="txtNombreApellido" runat="server" CssClass="form-control" type="text" Enabled="False"></asp:TextBox>
                               </div> 
                            </div>
                        </div>
                        <div class="col-5">
                            <div class="container">
                                <div class="row">
                                    <h5><asp:Label ID="Label3" runat="server" Text="Celular: "></asp:Label></h5>
                                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control" Enabled="False" TextMode="Number"></asp:TextBox>
                                </div>
                                <br />
                                <div class="row">
                                    <h5><asp:Label ID="Label4" runat="server" Text="Contraseña: "></asp:Label></h5>
                                    <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" type="text" Enabled="False"></asp:TextBox>                     
                                </div>
                                <br />
                                <div class="row">
                                    <h5><asp:Label ID="Label5" runat="server" Text="Estado: "></asp:Label></h5>
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control form-control-sm" Enabled="False">
                                        <asp:ListItem>habilitado</asp:ListItem>
                                        <asp:ListItem>deshabilitado</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <br />
                                <br />
                            </div>
                        </div>
                 </div>
              </asp:Panel>
                     <br />
             
             <div class="row justify-content-center">       
                    <asp:Panel ID="panelAcciones" runat="server" Visible="False">              
                            <asp:Button ID="btnEliminar" runat="server" class="btn btn-outline-secondary" Text="Eliminar" OnClick="btnEliminar_Click" />             
                            <asp:Button ID="btnEditar" runat="server" class="btn btn-outline-primary" Text="Editar" OnClick="btnEditar_Click" />                  
                    </asp:Panel>
             </div>
             <div class="row justify-content-center"> 
                    <asp:Panel ID="panelConfirmar" runat="server" Visible="False">
                        <asp:Button ID="btnCancelar" runat="server" class="btn btn-outline-secondary" Text="Cancelar" OnClick="btnCancelar_Click" /> 
                        <asp:Button ID="btnConfirmar" runat="server" class="btn btn-outline-primary" Text="Confirmar" OnClick="btnConfirmar_Click" />
                     </asp:Panel>
            </div>                      
     
        </div>
    </form>
</asp:Content>
