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
            <asp:Image ID="IME" runat="server" src ="images/voto/ENFADADO.png" Width="10%"/>
            <asp:Label ID="PME" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="IE" runat="server" src ="images/voto/NEUTRAL.png" Width="10%" />
            <asp:Label ID="PE" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="IC" runat="server" src ="images/voto/SATISFECHO.png" Width="10%" />
            <asp:Label ID="PC" runat="server" Text="Label"></asp:Label>
            <asp:Image ID="IMC" runat="server" src ="images/voto/CONTENTO.png" Width="10%"/>
            <asp:Label ID="PMC" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="Comentario" runat="server" Text="Comentarios:"></asp:Label>
            <asp:Table ID="TC" runat="server">
            </asp:Table>
            <asp:Button ID="BA" runat="server" Text="Atras" OnClick="BA_Click" />
            <asp:Button ID="BCS" runat="server" Text="Cerrar Sesión" OnClick="BCS_Click" />
        </div>
    </form>
</body>
</html>
