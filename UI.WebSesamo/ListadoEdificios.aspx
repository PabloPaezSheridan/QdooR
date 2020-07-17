<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoEdificios.aspx.cs" Inherits="UI.WebSesamo.ListadoEdificios" %>

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
            text-align: left;
        }

table {
  border-collapse: collapse;
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

th {
  text-align: inherit;
}

button,
[type="button"],
[type="reset"],
[type="submit"] {
  -webkit-appearance: button;
}

button,
input {
  overflow: visible;
}

input,
button,
select,
optgroup,
textarea {
  margin: 0;
  font-family: inherit;
  font-size: inherit;
  line-height: inherit;
}

        .auto-style3 {
            text-align: center;
            font-weight: normal;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="auto-style2">
                <asp:Label ID="Label1" runat="server" CssClass="auto-style3" ForeColor="#009999" Text="Edificios"></asp:Label>
            </h1>
        </div>
        <div class="auto-style1">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="gvEdificiosxUsuario" runat="server" AutoGenerateColumns="False" DataKeyNames="idEdificio" OnSelectedIndexChanged="gvEdificiosxUsuario_SelectedIndexChanged" Width="319px">
                <Columns>
                    <asp:BoundField DataField="idEdificio" Visible="False" />
                    <asp:BoundField DataField="denominacion" HeaderText="Nombre" />
                    <asp:BoundField DataField="calle" HeaderText="Calle" />
                    <asp:BoundField DataField="nroCalle" HeaderText="Número" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" ButtonType="Button" />
                </Columns>
                <HeaderStyle BackColor="#009999" />
            </asp:GridView>

             
            </div>
    </form>
</body>
</html>
