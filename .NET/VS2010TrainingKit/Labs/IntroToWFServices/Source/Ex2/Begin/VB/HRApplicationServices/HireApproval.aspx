<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="HireApproval.aspx.vb" Inherits="HRApplicationServices.HireApproval" %>

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
        .style2
        {
            width: 100%;
        }
        .style3
        {
            width: 151px;
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="Contoso" class="style1" src= "Images/logo.png" /><br />
        <h1>HR Job Application Approval</h1></div>
    <table class="style2">
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Application ID"></asp:Label>
                :
            </td>
            <td>
                <asp:Label ID="LabelAppID" runat="server" Text="(ID)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Name: 
            </td>
            <td>
                <asp:Label ID="LabelName" runat="server" Text="(Name)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
               Education:
            </td>
            <td>
                <asp:Label ID="LabelEducation" runat="server" Text="(Qualifications)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                References:
            </td>
            <td>
                <asp:Label ID="LabelReferences" runat="server" Text="(References)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Request ID:
            </td>
            <td>
                <asp:Label ID="LabelRequestID" runat="server" Text="(RequestID)"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Button ID="ButtonHire" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="Hire" />
            </td>
            <td>
                <asp:Button ID="ButtonNoHire" runat="server" Font-Bold="True" Font-Size="Large" 
                    Text="No Hire" />
            </td>
        </tr>
    </table>
</form>
</body>
</html>
