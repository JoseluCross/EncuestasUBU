<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Comentario.aspx.cs" Inherits="www.Comentario" %>

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
            <asp:Label ID="Voto" runat="server" Text="Su voto: "></asp:Label>
            <asp:Image ID="IV" runat="server" />
            <asp:Button ID="BCS" runat="server" Text="Cambiar Voto" OnClick="BCS_Click"/>
            <asp:TextBox ID="TAC" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Label ID="Com" runat="server" Text="Comentario"></asp:Label>
            <asp:Button ID="BC" runat="server" Text="Cancelar" OnClick="BC_Click" />
            <asp:Button ID="BE" runat="server" Text="Enviar" OnClick="BE_Click" />
            <asp:Label ID="LE" runat="server" Text="Debes poner un comentario" Visible ="false"></asp:Label>
        </div>
    </form>
</body>
</html>
