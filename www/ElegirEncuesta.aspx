<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ElegirEncuesta.aspx.cs" Inherits="www.ElegirEncuesta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Encuestas que puede votar:
            </h1>
        </div>
        <asp:Table ID="TEV" runat="server">
        </asp:Table>
        <asp:Button ID="BA" runat="server" Text="Administrar" OnClick="BA_Click" />
    </form>
</body>
</html>
