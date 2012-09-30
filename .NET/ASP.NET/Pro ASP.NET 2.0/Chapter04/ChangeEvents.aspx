<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeEvents.aspx.cs" Inherits="ChangeEvents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Change Events</title>
</head>
<body>
    <form id="form1" runat="server" >
    <div>
        &nbsp;<select runat="server" id="List1" size="5" multiple Name="List1" onserverchange="List1_ServerChange">
        <option>Option 1</option>
        <option>Option 2</option>
    </select>
    <br/>
    <input type="text" runat="server" ID="Textbox1" Size="10"
     Name="Textbox1" OnServerChange="Ctrl_ServerChange"><br/>
    <input type="checkbox" runat="server" ID="Checkbox1"
     Name="Checkbox1" OnServerChange="Ctrl_ServerChange">Option 
     text<br/>
        &nbsp;<input type="submit" runat="server" ID="Submit1" Name="cmdSubmit"
     value="Submit Query" onserverclick="Submit1_ServerClick">
       </div>
    </form>
</body>
</html>
