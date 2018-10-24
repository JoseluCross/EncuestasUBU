<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Estadisticas.aspx.cs" Inherits="www.Estadisticas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Titulo" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="IME" runat="server" />
            <asp:Label ID="PME" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="IE" runat="server" />
            <asp:Label ID="PE" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="IC" runat="server" />
            <asp:Label ID="PC" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="IMC" runat="server" />
            <asp:Label ID="PC" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Comentario" runat="server" Text="Comentarios:"></asp:Label>
            <asp:Table ID="TC" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
