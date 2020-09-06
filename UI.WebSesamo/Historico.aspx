<%@ Page Title="Histórico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="UI.WebSesamo.Historico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="body" runat="server">
       <div class="container">
        <form id="form1" runat="server">
        
                <h1 class="center"><span>Histórico de Accesos</span></h1>
                <br />
                <p class="center">
                <asp:Label runat="server" Text="Edificio:  " ID="Label1" class="h5 label label-primary"></asp:Label>
                <asp:DropDownList ID="ddlEdificiosxInmobiliaria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEdificiosxInmobiliaria_SelectedIndexChanged" class="btn btn-secondary dropdown-toggle" aria-haspopup="true" aria-expanded="false">
                </asp:DropDownList>
                </p>
                <br />
                <h3>Rango de fecha y hora del Historico</h3>
                <div class="container">
                    <div class="row">
                        <div class="col">
                            <asp:Label runat="server" Text="Inicio: " ID="Label2" class="h5 label label-primary"></asp:Label>
                            <asp:Calendar ID="calInicio" runat="server" OnSelectionChanged="calInicio_SelectionChanged"></asp:Calendar>
                        </div>
                        <div class="col">
                            <asp:Label runat="server" Text="Fin: " ID="Label3" class="h5 label label-primary"></asp:Label>
                            <asp:Calendar ID="calFin" runat="server" OnSelectionChanged="calFin_SelectionChanged"></asp:Calendar>
                        </div>
                    </div>    
                </div>
            <br /> 
                <div>

                    <asp:GridView ID="gdvHistorico" runat="server" class="table table-responsive table-striped table-hover"  AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="nombreUsuario" HeaderText="Usuario"/>
                            <asp:BoundField DataField="nombreyapellido" HeaderText="Nombre y Apellido" />
                            <asp:BoundField DataField="mail" HeaderText="Mail" />
                            <asp:BoundField DataField="celular" HeaderText="Celular" />
                            <asp:BoundField DataField="departamento" HeaderText="Depertamento" />
                            <asp:BoundField DataField="fechayHoraAcceso" HeaderText="Fecha y Hora Acceso" />
                        </Columns>
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>

                </div>
        </form>
   </div>
</asp:Content>

