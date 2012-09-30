<%@ Control Language="C#" AutoEventWireup="true" CodeFile="VaryByControl.ascx.cs" Inherits="VaryByControl" %>
<%@ OutputCache Duration="30" VaryByControl="lstMode"  %>


<asp:DropDownList id="lstMode" runat="server" Width="187px">
            <asp:ListItem>Large</asp:ListItem>
            <asp:ListItem>Small</asp:ListItem>
            <asp:ListItem>Medium</asp:ListItem>
            </asp:DropDownList>&nbsp;<br />
<asp:button ID="Button1" text="Submit" OnClick="SubmitBtn_Click" runat=server/>
<br /><br />

Control generated at:<br /> <asp:label id="TimeMsg" runat="server" />
