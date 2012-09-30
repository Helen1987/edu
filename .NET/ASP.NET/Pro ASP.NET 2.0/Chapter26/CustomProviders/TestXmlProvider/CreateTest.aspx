<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="CreateTest.aspx.cs" Inherits="_CreateTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" LoginCreatedUser="False" OnContinueButtonClick="CreateUserWizard1_ContinueButtonClick">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
        <hr />
        Create New Role: <asp:TextBox runat="server" ID="RoleNameText" />&nbsp;
        <asp:Button ID="AddRoleCommand" runat="server" Text="Add Role" OnClick="AddRoleCommand_Click" />
    </div>
    </form>
</body>
</html>
