<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WizardTemplates.aspx.cs" Inherits="WizardTemplates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Wizard ID="Wizard1" runat="server" Width="467px" 
              BackColor="#EFF3FB" BorderColor="#B5C7DE" BorderWidth="1px" Font-Names="Verdana"
              CellPadding="5" ActiveStepIndex="0" Font-Size="Small" OnFinishButtonClick="Wizard1_FinishButtonClick">
              <WizardSteps>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Personal">
                  <h3>Personal Profile</h3>
                  Preferred Programming Language:
                  <asp:DropDownList ID="lstLanguage" runat="server">
                    <asp:ListItem>C#</asp:ListItem>
                    <asp:ListItem>VB .NET</asp:ListItem>
                    <asp:ListItem>J#</asp:ListItem>
                    <asp:ListItem>Java</asp:ListItem>
                    <asp:ListItem>C++</asp:ListItem>
                    <asp:ListItem>C</asp:ListItem>         
                  </asp:DropDownList>
                  <br />
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep2" runat="server" Title="Company">
                  <h3>Comany Profile</h3>
                  Number of Employees: <asp:TextBox ID="txtEmpCount" runat="server"></asp:TextBox><br />
                  Number of Locations: &nbsp;<asp:TextBox ID="txtLocCount" runat="server"></asp:TextBox>
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep3" runat="server" Title="Software">
                  <h3>Software Profile</h3>
                  Licenses Required:
                  <asp:CheckBoxList ID="lstTools" runat="server">
                    <asp:ListItem>Visual Studio</asp:ListItem>
                    <asp:ListItem>Office</asp:ListItem>
                    <asp:ListItem>Windows 2003 Server</asp:ListItem>
                    <asp:ListItem>SQL Server 2005</asp:ListItem>
                    <asp:ListItem>BizTalk 2004</asp:ListItem>
                  </asp:CheckBoxList>
                </asp:WizardStep>
                <asp:WizardStep ID="Complete" runat="server" Title="Complete " StepType="Complete">
                  <br />
                    <asp:Label ID="lblSummary" runat="server" Text="Label"></asp:Label>
                  <br /><br />
                  Thank you for completing this survey.<br />
                  Your products will be delivered shortly.<br /><br />
                </asp:WizardStep>
              </WizardSteps>
           <SideBarStyle VerticalAlign="Top" />
           
             <HeaderTemplate>
    <i>Header Template</i> -
    <b><%= Wizard1.ActiveStep.Title %></b>
    <br /><br />
  </HeaderTemplate>

           <StepNavigationTemplate>
           <i>StepNavigationTemplate</i><br />
               <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                   Text="Previous" />
               <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Next" />
           </StepNavigationTemplate>
           <StartNavigationTemplate>
           <i>StartNavigationTemplate</i><br />
               <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Next" />
           </StartNavigationTemplate>
           <FinishNavigationTemplate>
           <i>FinishNavigationTemplate</i><br />
               <asp:Button ID="FinishPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious"
                   Text="Previous" />
               <asp:Button ID="FinishButton" runat="server" CommandName="MoveComplete" Text="Finish" />
           </FinishNavigationTemplate>
             
            </asp:Wizard>
        &nbsp;
<!-- <StepStyle Font-Size="0.8em" ForeColor="#333333" />
              <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
              <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
              <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
              <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
                Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />-->
    
    </div>
    </form>
</body>
</html>
