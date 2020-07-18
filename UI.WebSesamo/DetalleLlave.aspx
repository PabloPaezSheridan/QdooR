<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleLlave.aspx.cs" Inherits="UI.WebSesamo.DetalleLlave" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1"/>
<link href="Content/bootstrap.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">


        .auto-style3 {
            text-align: center;
            font-weight: normal;
        }
      
* {
  box-sizing: border-box;
}

  * {
    text-shadow: none !important;
    box-shadow: none !important;
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

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
				<asp:LinkButton ID="btnMisLlaves" runat="server" OnClick="btnMisLlaves_Click" Font-Size="Large">Atras</asp:LinkButton>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" CssClass="auto-style3" ForeColor="#009999" Text="Detalle de la Llave"></asp:Label>
            </h1>
        </div>
        <strong>&nbsp;<br />
        <asp:Label runat="server" Text="Descripción:"></asp:Label>
        </strong>&nbsp;
        <asp:Label ID="lblDenominacion" runat="server" Text="Label"></asp:Label>
        <strong>&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="chkDesechable" runat="server" Enabled="False" Text="Desechable" />
        <br />
        <br />
&nbsp;
        <asp:Label runat="server" Text="Creación:"></asp:Label>
        </strong>&nbsp;<asp:Label ID="lblCreacion" runat="server" Text="Label"></asp:Label>
        <strong>&nbsp;
        <asp:Label ID="Label2" runat="server" Text="Caducacion:"></asp:Label>
        </strong>&nbsp;<asp:Label ID="lblCaducacion" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;
        <br />
        <br />
&nbsp;
        <asp:Button ID="btnDescargarQr" runat="server" OnClick="btnDescargarQr_Click" Text="Descargar QR" Width="101px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" Width="100px" />
        <br />
        <br />
            <asp:GridView ID="gvLlavesActivadas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="fechorAct" HeaderText="Activaciones de la llave" />
                </Columns>
                <HeaderStyle BackColor="#009999" />
            </asp:GridView>

             
    </form>
</body>
</html>
