<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RestrictedCalendarTest.aspx.cs" Inherits="RestrictedCalendarTest" %>
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
        <apress:RestrictedCalendar ID="RestrictedCalendar1" runat="server" NonSelectableDates-Capacity="4"><DateTime Value="7/30/2005 12:00:00 AM" />
<DateTime Value="7/29/2005 12:00:00 AM" />
</apress:RestrictedCalendar>
    </div>
    </form>
</body>
</html>
