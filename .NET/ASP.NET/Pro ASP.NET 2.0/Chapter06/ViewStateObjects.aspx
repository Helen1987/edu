<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewStateObjects.aspx.cs" Inherits="ViewStateObjects" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    			<table>
				<tr>
					<th>Description</th>
					<th>Value</th>
				</tr>
				<tr>
					<td>Name:<td>
						<asp:TextBox runat="server" Width="200px" ID="Name" />
					</td>
				</tr>
				<tr>
					<td>ID:</td>
					<td>
						<asp:TextBox runat="server" Width="200px" ID="EmpID" />
					</td>
				</tr>
				<tr>
					<td>Age:</td>
					<td>
						<asp:TextBox runat="server" Width="200px" ID="Age" />
					</td>
				</tr>
				<tr>
					<td>E-mail:</td>
					<td>
						<asp:TextBox runat="server" Width="200px" ID="Email" />
					</td>
				</tr>
				<tr>
					<td>Password:</td>
					<td>
						<asp:TextBox TextMode="Password" runat="server" Width="200px" ID="Password" />
					</td>
				</tr>
			</table><br />
			<asp:Button runat="server" Text="Save" ID="cmdSave" OnClick="cmdSave_Click" />&nbsp;
			<asp:Button id="cmdRestore" runat="server" Text="Restore" OnClick="cmdRestore_Click"></asp:Button><br />
        <BR>
        <asp:Label ID="lblResults" runat="server"></asp:Label>

    </div>
    </form>
</body>
</html>
