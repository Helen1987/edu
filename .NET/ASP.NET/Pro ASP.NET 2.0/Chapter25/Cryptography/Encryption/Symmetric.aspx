<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Symmetric.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:Panel ID="MainPanel" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="185px"
            Width="596px">
            <table border="0" width="100%">
                <tr>
                    <td style="width: 252px; height: 45px; text-align: left">
                        Step 1:<br />
                        Generate Encryption Key</td>
                    <td style="height: 45px">
                        <asp:LinkButton ID="GenerateKeyCommand" runat="server" OnClick="GenerateKeyCommand_Click">Generate Key</asp:LinkButton><br />
                        <asp:CheckBox ID="EncryptKeyCheck" runat="server" Text="Key Encryption" /></td>
                </tr>
                <tr>
                    <td style="width: 252px; height: 24px; text-align: left">
                        Step 2:<br />
                        Clear-text data</td>
                    <td style="height: 24px">
                        <asp:TextBox ID="ClearDataText" runat="server" Rows="5" TextMode="MultiLine" Width="98%" Columns="40"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 252px; text-align: left">
                        Step 3:<br />
                        Encrypted data</td>
                    <td>
                        <asp:TextBox ID="EncryptedDataText" runat="server" Rows="5" TextMode="MultiLine"
                            Width="98%" Columns="40"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 252px">
                    </td>
                    <td>
                        <asp:LinkButton ID="EncryptCommand" runat="server" OnClick="EncryptCommand_Click">Encrypt</asp:LinkButton>&nbsp;<asp:LinkButton
                            ID="DecryptCommand" runat="server" OnClick="DecryptCommand_Click">Decrypt</asp:LinkButton>&nbsp;<asp:LinkButton
                                ID="ClearCommand" runat="server" OnClick="ClearCommand_Click">Clear</asp:LinkButton></td>
                </tr>
            </table>
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>
