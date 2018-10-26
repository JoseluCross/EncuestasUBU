<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AñadirModificar.aspx.cs" Inherits="www.AñadirModificar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <h1>Título:</h1>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="TT" runat="server" Width="207px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <h1>Foto:</h1>
                        <asp:TextBox ID="TF" runat="server"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h1>Descripción:</h1>
                    </td>
                    <td>
                        <h1>Visibilidad:</h1>
                        <asp:CheckBox ID="CBV" runat="server" />
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:TextBox ID="TD" runat="server" Height="41px" TextMode="MultiLine" Width="322px" ></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Button ID="ACC" runat="server" Height="57px" Text="Añadir/Confirmar cambios" Width="164px" OnClick="ACC_Click" />
        <asp:Button ID="BC" runat="server" Text="Cancelar" OnClick="BC_Click" />
        <asp:Button ID="BCS" runat="server" Text="Cerrar Sesión" OnClick="BCS_Click" />
        <asp:Label ID="CE" runat="server" Text="Ya existe una encuesta con ese Título" Visible="false"></asp:Label>
    </form>
</body>
</html>
