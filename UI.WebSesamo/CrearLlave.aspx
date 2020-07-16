<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearLlave.aspx.cs" Inherits="UI.WebSesamo.CrearLlave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
	<style type="text/css">
		.auto-style1 {
			text-align: center;
		}
		.auto-style2 {
			color: #009999;
		}
		</style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="text-center">
        <div class="auto-style1">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click">Login</asp:LinkButton>
        	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        	&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnMisLlaves" runat="server" OnClick="btnMisLlaves_Click">Mis Llaves</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;
        	<br />
        	<br />
        	<h1 class="text-center">
				<asp:Label ID="lblTitulo" runat="server" CssClass="auto-style2" Text="QdooR"></asp:Label>
			</h1>
        </div>
            <p class="text-center">
				&nbsp;</p>
            <p class="text-center">
				&nbsp;</p>
            <h4 class="text-center">
				<asp:Label ID="lblDesechable" runat="server" Text="Desechable"></asp:Label>
				<asp:CheckBox ID="chkDesechable" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="chkDesechable_CheckedChanged" />
			</h4>
            <p class="text-center">
				&nbsp;</p>
            <h4>
				<asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
&nbsp;&nbsp;
                <asp:TextBox ID="txtDenomLlave" runat="server" Width="162px"></asp:TextBox>
            </h4>
            <p class="text-center">
				</p>
			<h4 class="text-center">
				<asp:Label ID="lblDuracion" runat="server" Enabled="False" Text="Duración"></asp:Label>
&nbsp;&nbsp;
				<asp:DropDownList ID="ddlDuracion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDuracion_SelectedIndexChanged" Enabled="False">
					<asp:ListItem Selected="True" Value="360">5 Minutos</asp:ListItem>
					<asp:ListItem Value="900">15 Minutos</asp:ListItem>
					<asp:ListItem Value="86400">1 Dia</asp:ListItem>
					<asp:ListItem Value="604800">1 semana</asp:ListItem>
				</asp:DropDownList>
			</h4>
            <p class="text-center">
				&nbsp;</p>
            <p class="text-center">
				<asp:LinkButton ID="btnCrearLlave" runat="server" BorderStyle="Solid" OnClick="btnCrearLlave_Click" Width="167px">Crear Llave</asp:LinkButton>
            </p>

			

		</div>
    	<p>
			&nbsp;</p>
    </form>
</body>
</html>
