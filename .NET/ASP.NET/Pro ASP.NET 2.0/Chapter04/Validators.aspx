<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Validators.aspx.cs" Inherits="Validators" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
<script language="JavaScript">
  function EmpIDClientValidate(ctl, args)
  {

    // the value is a multiple of 5 if the module by 5 is 0
    args.IsValid=(args.Value%5 == 0);
  }
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
                <tr>
                    <td>Description</td>
                    <td/>
                </tr>
                <tr>
                    <td>Name:</td> 
                    <td>
                        <asp:TextBox runat="server" Width="200px" ID="Name" />
                        <asp:RequiredFieldValidator runat="server" ID="ValidateName" ControlToValidate="Name" ErrorMessage="Name is required"
                            Display="dynamic">*
                </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="ValidateName2" ControlToValidate="Name" validationExpression="[a-z A-Z]*"
                            ErrorMessage="Name cannot contain digits" Display="dynamic">*
                </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>ID (multiple of 5):</td>
                    <td>
                        <asp:TextBox runat="server" Width="200px" ID="EmpID" />
                        <asp:RequiredFieldValidator runat="server" ID="ValidateEmpID" ControlToValidate="EmpID" ErrorMessage="ID is required"
                            Display="dynamic">*
                </asp:RequiredFieldValidator>
                        <asp:CustomValidator runat="server" ID="ValidateEmpID2" ControlToValidate="EmpID" ClientValidationFunction="EmpIDClientValidate"
                            ErrorMessage="ID must be a multiple of 5" Display="dynamic" OnServerValidate="ValidateEmpID2_ServerValidate">*
                </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>Day off:<br/><small>08/05/05-08/20/05</small></td>
                    <td>
                        <asp:TextBox runat="server" Width="200px" ID="DayOff" />
                        <asp:RequiredFieldValidator runat="server" ID="ValidateDayOff" ControlToValidate="DayOff" ErrorMessage="Day Off is required"
                            Display="dynamic">*
                </asp:RequiredFieldValidator>
                        <asp:RangeValidator runat="server" ID="ValidateDayOff2" ControlToValidate="DayOff" MinimumValue="05/08/2005"
                            MaximumValue="20/08/2005" Type="Date" ErrorMessage="Day Off is not within the valid interval" Display="dynamic" SetFocusOnError="True">*
                </asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>Age&nbsp<small>( >= 18 )</small>:</td>
                    <td>
                        <asp:TextBox runat="server" Width="200px" ID="Age" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Age" ErrorMessage="Age is required" Display="dynamic"
                            ID="Requiredfieldvalidator1" Name="Requiredfieldvalidator1">*
                </asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" ID="ValidateAge" ControlToValidate="Age" ValueToCompare="18" Type="Integer"
                            Operator="GreaterThanEqual" ErrorMessage="You must be at least 18-year-old" Display="dynamic">*
                </asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>E-mail:</td>
                    <td>
                        <asp:TextBox runat="server" Width="200px" ID="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required" Display="dynamic"
                            ID="Requiredfieldvalidator2" Name="Requiredfieldvalidator2">*
                </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator runat="server" ID="ValidateEmail" ControlToValidate="Email" validationExpression=".*@.{2,}\..{2,}"
                            ErrorMessage="E-mail is not in a valid format" Display="dynamic">*
                    </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox TextMode="Password" runat="server" Width="200px" ID="Password" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required"
                            Display="dynamic" ID="Requiredfieldvalidator3" Name="Requiredfieldvalidator3">
                            <img src="imgError.gif" border="0">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Re-enter Password:</td>
                    <td>
                        <asp:TextBox runat="server" TextMode="Password" Width="200px" ID="Password2" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password2" ErrorMessage="Password2 is required"
                            Display="dynamic" ID="Requiredfieldvalidator4" Name="Requiredfieldvalidator4">
                            <img src="imgError.gif" border="0">
                        </asp:RequiredFieldValidator>
                        <asp:CompareValidator runat="server" ControlToValidate="Password2" ControlToCompare="Password" Type="String"
                            ErrorMessage="The passwords don't match" Display="dynamic" ID="Comparevalidator1" Name="Comparevalidator1">
                            <img src="imgError.gif" border="0">
                        </asp:CompareValidator>
                    </td>
                </tr>
            </table><br />
            <asp:Button runat="server" Text="Submit" ID="Submit" OnClick="Submit_Click" /><BR>
            <br>
            <asp:CheckBox runat="server" ID="EnableValidators" Checked="True" AutoPostBack="True" Text="Validators enabled" OnCheckedChanged="OptionsChanged" />
            <br>
            <asp:CheckBox runat="server" ID="EnableClientSide" Checked="True" AutoPostBack="True" Text="Client-side validation enabled" OnCheckedChanged="OptionsChanged" />
            <br>
            <asp:CheckBox runat="server" ID="ShowSummary" Checked="True" AutoPostBack="True" Text="Show summary" OnCheckedChanged="OptionsChanged" />
            <br>
            <asp:CheckBox runat="server" ID="ShowMsgBox" Checked="False" AutoPostBack="True" Text="Show message box" OnCheckedChanged="OptionsChanged" />
            <br>
            <br>
            <asp:ValidationSummary runat="server" ID="ValidationSum" DisplayMode="BulletList" HeaderText="<b>Please review the following errors:</b>"
                ShowSummary="true" />
                <asp:Label runat="server" ID="Result" ForeColor="magenta" Font-Bold="true" EnableViewState="False" />
            
    </div>
    </form>
</body>
</html>
