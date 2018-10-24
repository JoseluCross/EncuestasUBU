<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="www.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BA" runat="server" Height="97px" Text="Añadir Encuesta" Width="156px" OnClick="BA_Click" />
            <asp:Button ID="BE" runat="server" Height="97px" Text="Encuesta" Width="156px" OnClick="BE_Click" />
            <asp:Button ID="BCS" runat="server" Height="30px" Text="Cerrar Sesión" Width="150px" OnClick="BCS_Click" />
        </div>
    </form>
</body>
</html>
