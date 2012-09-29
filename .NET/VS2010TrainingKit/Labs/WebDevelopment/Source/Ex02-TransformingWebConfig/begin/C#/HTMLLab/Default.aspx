<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HTML_Lab.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="Products" runat="server">
        </asp:GridView>
        <asp:ListView runat="server">
            <ItemTemplate>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="itemPlaceholderContainer">
                    <tr runat="server" id="itemPlaceholder">
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <label for="CustomerType">
            Customer Type:</label>
        <select>
            <option>Federal</option>
            <option>State</option>
            <option>Corporate</option>
            <option>Residtential</option>
        </select>
        <br />
        <label>
            Name:
        </label>
        <input id="name" name="name" /><br />
        <label>
            Address Line 1:
        </label>
        <input id="AddressLine1" name="AddressLine1" /><br />
        <label>
            Address Line 2:
        </label>
        <input id="AddressLine2" name="AddressLine2" /><br />
        <label>
            City
        </label>
        <input id="City" name="City" /><br />
        <label>
            State
        </label>
        <input id="State" name="State" /><br />
        <label>
            Zip Code
        </label>
        <input id="zip" name="zip" /><br />
        <br />
    </div>
    </form>
</body>
</html>
