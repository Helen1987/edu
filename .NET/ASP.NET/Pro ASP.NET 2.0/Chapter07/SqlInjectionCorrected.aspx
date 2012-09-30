<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SqlInjectionCorrected.aspx.cs" Inherits="SqlInjectionCorrected" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:TextBox id="txtID" style="Z-INDEX: 101; LEFT: 18px; POSITION: absolute; TOP: 40px" runat="server">ALFKI' OR '1'='1</asp:TextBox>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 19px; POSITION: absolute; TOP: 17px" runat="server"
				Font-Names="Verdana" Font-Size="X-Small" Font-Bold="True">Enter Customer ID:</asp:Label>
			<asp:Button id="cmdGetRecords" style="Z-INDEX: 103; LEFT: 178px; POSITION: absolute; TOP: 39px"
				runat="server" Text="Get Records" OnClick="cmdGetRecords_Click"></asp:Button>
			<asp:GridView id="GridView1" style="Z-INDEX: 104; LEFT: 19px; POSITION: absolute; TOP: 100px"
				runat="server" Width="392px" Height="123px" Font-Names="Verdana" Font-Size="X-Small"></asp:GridView>

    </div>
    </form>
</body>
</html>
