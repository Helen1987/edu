<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HRMessage.aspx.cs" Inherits="HRApplicationServices.HRMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 200px;
            height: 68px;
        }
        body
        {
            font-family: Verdana;
            font-size: large;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Contoso" class="style1" src= "Images/logo.png" /><br />
        <h1>HR Job Application Approval</h1></div>
    <asp:Label ID="LabelError" runat="server" 
        Text="We're sorry, an error has occured and has been logged, please try again or contact support"></asp:Label>
</form>
</body>
</html>
