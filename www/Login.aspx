<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="www.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Login</h1>
        <table>
            <tr>
                <td>Cuenta de usuario</td>
                <td>
                    <asp:TextBox ID="TB_Cuenta" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Contraseña</td>
                <td>
                    <asp:TextBox ID="TB_Pass" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
