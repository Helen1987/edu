<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FocusAndDefault.aspx.cs" Inherits="FocusAndDefault" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Focus and Default Button</title>
</head>
<body>
    <form id="Form1"
    defaultbutton="cmdSubmit" defaultfocus="TextBox1"
    runat="server">
<div>
    <br />
    <br />
    <br />
    <br />
    
          
    TextBox1:
    <asp:textbox id="TextBox1"
      runat="server" AccessKey="1"></asp:textbox>
  
    <br />

    TextBox2:
    <asp:textbox id="TextBox2"
      runat="server" AccessKey="2"></asp:textbox>

    <br /><br />

    <asp:button id="cmdSetFocus1"
      text="Set Focus #1" 
      runat="server" OnClick="cmdSetFocus1_Click">
    </asp:button>&nbsp;<asp:button id="cmdSetFocus2" 
      text="Set Focus #2"
      runat="server" OnClick="cmdSetFocus2_Click" >
    </asp:button>&nbsp;
    <asp:Button ID="cmdSubmit" runat="server" Text="Submit" OnClick="cmdSubmit_Click" />

      <hr />

      <asp:label id="Label1"
      runat="Server" EnableViewState="False"></asp:label>
    &nbsp;

 </div>
   </form>


</body>
</html>
