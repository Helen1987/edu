<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ValidationGroups.aspx.cs" Inherits="ValidationGroups" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel Height="112px" ID="Panel1" runat="server" Width="151px" BorderWidth="2px">
            <asp:TextBox ID="TextBox1" runat="server" ValidationGroup="Group1"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="*Required" ID="RequiredFieldValidator1"
            runat="server" ValidationGroup="Group1" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
            <asp:Button ID="Button1" runat="server" Text="Validate Group1" ValidationGroup="Group1"/></asp:Panel>
        
        &nbsp;<br />
        <asp:Panel Height="94px" ID="Panel2" runat="server" Width="125px" BorderWidth="2px">
            <asp:TextBox ID="TextBox2" runat="server" ValidationGroup="Group2"></asp:TextBox>
            <asp:RequiredFieldValidator ErrorMessage="*Required" ID="RequiredFieldValidator2"
            runat="server" ValidationGroup="Group2" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
            <asp:Button ID="Button2" runat="server" Text="Validate Group2" ValidationGroup="Group2"/></asp:Panel>
        <br />
        <br />
        <asp:Button ID="cmdValidateAll" OnClick="cmdValidateAll_Click" runat="server" Text="Validate Default" /><br />
        <br />
        <asp:Label EnableViewState="False" ID="Label1" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
