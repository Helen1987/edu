<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuperSimpleRepeaterTest.aspx.cs" Inherits="SuperSimpleRepeaterTest" %>
<%@ Register TagPrefix="apress" Namespace="CustomServerControlsLibrary"
  Assembly="CustomServerControls" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <apress:SuperSimpleRepeater id="sample" runat="server" RepeatCount="10">
  <ItemTemplate>
    <div align="center">
      <hr />Creating templated controls is <b>easy</b> and <i>fun</i>.<br /><hr />
   </div>
  </ItemTemplate>
</apress:SuperSimpleRepeater>

        </div>
    </form>
</body>
</html>
