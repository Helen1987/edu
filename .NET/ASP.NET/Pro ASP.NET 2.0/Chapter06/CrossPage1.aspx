<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CrossPage1.aspx.cs" Inherits="CrossPage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CrossPage1</title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
        Type something here:
  <asp:TextBox runat="server" ID="txt1"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt1"
            EnableClientScript="False" ErrorMessage="This is a required field."></asp:RequiredFieldValidator><br />
        <br />
        <asp:Button runat="server" ID="cmdPost" 

                PostBackUrl="CrossPage2.aspx" Text="Cross-Page Postback" />
        <asp:Button runat="server" ID="cmdTransfer" Text="Manual Transfer" OnClick="cmdTransfer_Click" />
    </div>
    </form>
</body>
</html>
