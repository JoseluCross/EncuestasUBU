<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Encuestas.aspx.cs" Inherits="www.Encuestas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Lista de Encuestas
            </h1>
            <asp:Label ID="LBL_Error" runat="server" Text=""></asp:Label>
            <asp:Table ID="T_Encuestas" runat="server">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Nº</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Titulo</asp:TableHeaderCell>
                    <asp:TableHeaderCell>&#x1f441;</asp:TableHeaderCell>
                    <asp:TableHeaderCell>&#x1F589;</asp:TableHeaderCell>
                    <asp:TableHeaderCell>&#x1F4C8;</asp:TableHeaderCell>
                    <asp:TableHeaderCell>&#x1f5d1;</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <table>
                <tr>
                    <td><asp:Label ID="LBL_BORRAR" runat="server" Visible="false"></asp:Label></td>
                    <td><asp:Button ID="BTN_CONFIRMAR" runat="server" Text="Si" Visible="false" OnClick="Confirmar_Click"/></td>
                    <td><asp:Button ID="BTN_CANCELAR" runat="server" Text="No" Visible="false" OnClick="Cancelar_Click"/></td>
                </tr>
            </table>
            
            <asp:Button ID="BA" runat="server" Text="Atras" OnClick="BA_Click" />
            <asp:Button ID="BCS" runat="server" Text="Cerrar Sesión" OnClick="BCS_Click" />
        </div>
    </form>
</body>
</html>
