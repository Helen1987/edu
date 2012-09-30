<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageFlow.aspx.cs" Inherits="PageFlow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Page Flow</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <p>
        <asp:Label id="lblInfo" runat="server" EnableViewState="False">
         </asp:Label>
       </p>
       <p>
            <asp:Button id="Button1" runat="server"
              Text="Button" OnClick="Button1_Click"></asp:Button>
       </p>
    </div>
    </form>
</body>
</html>
