<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SuperSimpleRepeater2Test.aspx.cs" Inherits="SuperSimpleRepeater2Test" %>
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
    <apress:SuperSimpleRepeater2 id="sample" runat="server" RepeatCount="10">
  <HeaderTemplate>
    <h2 style="Color:Red">Super Simple Repeater Strikes Again!</h2>
    Now showing <%# Container.Total %> Items for your viewing pleasure.
  </HeaderTemplate>
  <ItemTemplate>
    <div align="center">
    <hr />Item <%# Container.Index %> of <%# Container.Total%><br /><hr />
    </div>
  </ItemTemplate>

  <AlternatingItemTemplate>
   <div align="center" style="border-right: fuchsia double; border-top: fuchsia
double; border-left: fuchsia double; border-bottom: fuchsia double">
   Item <%# Container.Index %> of <%# Container.Total%>
   </div>
  </AlternatingItemTemplate>
  <FooterTemplate>
    <i>This presentation of the Simple Repeater Control brought to you by the
    letter <b>W</b></i>
  </FooterTemplate>
</apress:SuperSimpleRepeater2>

    </div>
    </form>
</body>
</html>
