<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BulletedList.aspx.cs" Inherits="BulletedList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Bullet styles:<br />
        <br />
        <asp:BulletedList BulletStyle="Numbered" DisplayMode="LinkButton" ID="BulletedList1"
            OnClick="BulletedList1_Click" runat="server">
        </asp:BulletedList>
        &nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
