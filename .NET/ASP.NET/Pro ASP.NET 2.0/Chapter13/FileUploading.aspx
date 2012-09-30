<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FileUploading.aspx.cs" Inherits="FileUploading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="Uploader" runat="server" Height="24px" />
        <br />
        <br />
        <asp:Button ID="cmdUpload" runat="server" OnClick="cmdUpload_Click" Text="Upload" /><br />
        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
