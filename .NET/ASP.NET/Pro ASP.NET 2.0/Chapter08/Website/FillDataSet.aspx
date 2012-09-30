<%@ Page language="c#" Inherits="FillDataSet" CodeFile="FillDataSet.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FillDataSet</title>
		</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="100%">
				<TR>
					<TD>
						<asp:Repeater id="Repeater1" runat="server">
							<HeaderTemplate>
								<h2>Repeater</h2>
							</HeaderTemplate>
							<ItemTemplate>
								<li>
									<%# DataBinder.Eval(Container.DataItem, "TitleOfCourtesy") %>
									<b>
										<%# DataBinder.Eval(Container.DataItem, "LastName") %>
									</b>,
									<%# DataBinder.Eval(Container.DataItem, "FirstName") %>
								</li>
							</ItemTemplate>
						</asp:Repeater></TD>
					<TD>
						<H2>foreach approach</H2>
						<asp:Literal id="HtmlContent" runat="server"></asp:Literal></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
