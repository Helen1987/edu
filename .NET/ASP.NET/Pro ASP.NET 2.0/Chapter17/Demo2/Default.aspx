<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default_aspx" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html runat="server" dir='<%$ Resources:ValidationResources, TextDirection %>' xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body text="#00a000">
    <form id="form1" runat="server">
    <div>
      <table width="100%" style="height: 47px">
        <tr>
          <td style="width: 3px; height: 21px">
            <asp:Label ID="LegendFirstname" runat="server" Text="BlaControl:" meta:resourcekey="LabelResource1"></asp:Label>
          </td>
          <td style="width: 3px; height: 21px">
            <asp:TextBox ID="FirstnameText" runat="server" meta:resourcekey="TextBoxResource1"></asp:TextBox></td>
        </tr>
        <tr>
          <td style="width: 3px; height: 19px;">
            <asp:Label ID="LegendLastname" runat="server" Text="Lastname:" meta:resourcekey="LabelResource2"></asp:Label>
          </td>
          <td style="width: 3px; height: 19px;">
            <asp:TextBox ID="LastnameText" runat="server" meta:resourcekey="TextBoxResource2"></asp:TextBox></td>
        </tr>
        <tr>
          <td style="width: 3px">
            <asp:Label ID="LegendBirthdate" runat="server" Text="Birthdate:" meta:resourcekey="LabelResource3"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="BirthdateText" runat="server" meta:resourcekey="TextBoxResource3"></asp:TextBox>&nbsp;
<asp:RegularExpressionValidator
    ControlToValidate="BirthdateText" ErrorMessage="Invalid date!!" ID="RegularExpressionValidator1"
    runat="server" ValidationExpression='<%$ Resources:ValidationResources, DateFormat %>' meta:resourcekey="RegularExpressionValidatorResource1"></asp:RegularExpressionValidator>
          </td>
        </tr>
        <tr>
          <td style="width: 3px">
            <asp:Label ID="LegendAnnualSalary" runat="server" Text="Annual Salary:" meta:resourcekey="LabelResource4"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="SalaryText" runat="server" meta:resourcekey="TextBoxResource4"></asp:TextBox>&nbsp;
            <asp:RegularExpressionValidator
              ControlToValidate="SalaryText" ErrorMessage="Invalid salary!!" ID="RegularExpressionValidator2"
              runat="server" ValidationExpression='<%$ Resources:ValidationResources, SalaryFormat %>' meta:resourcekey="RegularExpressionValidatorResource2"></asp:RegularExpressionValidator>
          </td>
        </tr>
      </table>
    
    </div>
      <asp:Button ID="OkayAction" runat="server" Text="Okay" meta:resourcekey="ButtonResource1" OnClick="OkayAction_Click" />
      <asp:Button ID="CancelAction" runat="server" Text="Cancel" meta:resourcekey="ButtonResource2" />
      <br />
      <br />
      <asp:Label ID="ExplicitLabel" meta:resourcekey="LabelResource5" runat="server" Text="<%$ Resources:MyTestExpression %>"></asp:Label>
      <br />
      <asp:Label ID="ExplicitGlobalTest" meta:resourcekey="LabelResource6" runat="server"
        Text="<%$ Resources:ValidationResources, DateFormat %>"></asp:Label>
      <br />
      <br />
      <asp:Localize runat=server meta:resourcekey="LiteralResource1">This is some static text!</asp:Localize>
    </form>
</body>
</html>
