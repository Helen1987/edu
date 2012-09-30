<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepeatedValueBinding.aspx.cs" Inherits="RepeatedValueBinding" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
				<tr>
					<td>
						<select runat="server" ID="Select1" size="3" DataTextField="Key" DataValueField="Value"
							NAME="Select1" />
					</td>
					<td>
						<select runat="server" ID="Select2" DataTextField="Key" DataValueField="Value" NAME="Select2" />
					</td>
					<td>
						<asp:ListBox runat="server" ID="Listbox1" Size="3" DataTextField="Key" DataValueField="Value" />
					</td>
					<td>
						<asp:DropDownList runat="server" ID="DropdownList1" DataTextField="Key" DataValueField="Value" />
					</td>
					<td>
						<asp:RadioButtonList runat="server" ID="OptionList1" DataTextField="Key" DataValueField="Value" />
					</td>
					<td>
						<asp:CheckBoxList runat="server" ID="CheckList1" DataTextField="Key" DataValueField="Value" />
					</td>
				</tr>
			</table>
			<asp:Button runat="server" Text="Get Selection" ID="cmdGetSelection" OnClick="cmdGetSelection_Click" />
			<br>
			<br>
			<asp:Literal runat="server" ID="Result" EnableViewState="False" />
    </div>
    </form>
</body>
</html>
