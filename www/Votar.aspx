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
                            <asp:ImageButton ID="IB_ENFADADO" runat="server" ImageUrl="images/voto/ENFADADO.png" Width="20%" OnClick="IB_ENFADADO_Click" />
                        </td>
                        <td>
                            <asp:ImageButton ID="IB_NEUTRAL" runat="server" ImageUrl="images/voto/NEUTRAL.png" Width="20%" OnClick="IB_NEUTRAL_Click"/>
                        </td>
                        <td>
                            <asp:ImageButton ID="IB_SATISFECHO" runat="server" ImageUrl="images/voto/SATISFECHO.png" Width="20%" OnClick="IB_SATISFECHO_Click" />
                        </td>
                        <td>
                            <asp:ImageButton ID="IB_CONTENTO" runat="server" ImageUrl="images/voto/CONTENTO.png" Width="20%" OnClick="IB_CONTENTO_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="B_Atras" runat="server" Text="Atrás" OnClick="B_Atras_Click"  />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
