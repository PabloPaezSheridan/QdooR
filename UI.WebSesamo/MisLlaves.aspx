<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisLlaves.aspx.cs" Inherits="UI.WebSesamo.MisLlaves" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
	<style type="text/css">
		.auto-style1 {
			color: #009999;
            font-size: xx-large;
        }
		</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<p>
				<asp:LinkButton ID="btnCrearLlave" runat="server" OnClick="btnCrearLlave_Click">Atras</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
				<asp:Label ID="lblMisLlaves" runat="server" CssClass="auto-style1" Text="Mis Llaves"></asp:Label>
			</p>
        </div>
	    
        <div>
            <asp:GridView ID="gvLlavesxUsuario" runat="server" AutoGenerateColumns="False" DataKeyNames="cadenaQr" OnSelectedIndexChanged="gvGetLlavexUsuario_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="cadenaQr" Visible="False" />
                    <asp:BoundField DataField="denominacion" HeaderText="Descripción" />
                    <asp:BoundField DataField="fechorCre" HeaderText="Creacion" />
                    <asp:BoundField DataField="fechorCad" HeaderText="Caducidad" />
                    <asp:CheckBoxField DataField="desechable" HeaderText="Desechable" />
                    <asp:CommandField SelectText="Eliminar" ShowSelectButton="True" ButtonType="Button" />
                </Columns>
                <HeaderStyle BackColor="#009999" />
            </asp:GridView>

             
            </div>
            
        
    </form>
	</body>
</html>
