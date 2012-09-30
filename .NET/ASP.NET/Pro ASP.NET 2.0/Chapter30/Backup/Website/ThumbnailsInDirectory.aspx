<%@ Page language="c#" Inherits="ThumbnailsInDirectory" CodeFile="ThumbnailsInDirectory.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ThumbnailsInDirectory</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:Label id="Label1" runat="server">Directory: </asp:Label>&nbsp;
				<asp:TextBox id="txtDir" runat="server" Width="343px">c:\Windows\</asp:TextBox>
				<asp:Button id="cmdShow" runat="server" Text="Show Thumbnails" Width="123px" onclick="cmdShow_Click"></asp:Button></P>
            <asp:GridView ID="gridThumbs" runat="server" AutoGenerateColumns="False" Font-Names="Verdana"
                Font-Size="X-Small" GridLines="None">
                <Columns>
                    <asp:TemplateField>
                    <ItemTemplate>
					<img src='<%# GetImageUrl(Eval("FullName")) %>' />
					<%# Eval("Name") %>
					<hr>
				</ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
		</form>
	</body>
</HTML>
