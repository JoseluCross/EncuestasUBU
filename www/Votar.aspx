<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Votar.aspx.cs" Inherits="www.Votar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="text-align:center">
                <thead>
                    <tr>
                        <th colspan="4">
                            
                            <asp:Label ID="L_Titulo" runat="server" Text=""></asp:Label>
                            
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="L_Descripcion" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="IB_ENFADADO" runat="server" />
                        </td>
                        <td>
                            <asp:ImageButton ID="IB_NEUTRAL" runat="server" />
                        </td>
                        <td>
                            <asp:ImageButton ID="IB_SATISFECHO" runat="server" />
                        </td>
                        <td>
                            <asp:ImageButton ID="IB_CONTENTO" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="B_Atras" runat="server" Text="Atrás" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
