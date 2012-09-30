<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="Customers.ascx" TagName="Customers" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:WebPartManager runat="server" ID="MyPartManager" />
            <table width="100%">
                <tr valign="middle" bgcolor="#00ccff">
                    <td colspan="2">
                        <span style="font-size: 16pt; font-family: Verdana"><strong>Welcome to web part pages!</strong>
                        </span>
                    </td>
                    <td style="height: 22px">
                        <asp:Menu ID="PartsMenu" runat="server" OnMenuItemClick="PartsMenu_MenuItemClick" BackColor="#B5C7DE" DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" StaticSubMenuIndent="10px">
                            <StaticSelectedStyle BackColor="#507CD1" />
                            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                            <DynamicHoverStyle BackColor="#284E98" Font-Bold="False" ForeColor="White" />
                            <DynamicMenuStyle BackColor="#B5C7DE" />
                            <DynamicSelectedStyle BackColor="#507CD1" />
                            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                            <StaticHoverStyle BackColor="#284E98" Font-Bold="False" ForeColor="White" />
                        </asp:Menu>
                    </td>
                </tr>
                <tr valign="top">
                    <td width="20%">
                        <asp:CatalogZone runat="server" ID="SimpleCatalog" BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana" Padding="6">
                            <ZoneTemplate>
                                <asp:PageCatalogPart runat="server" ID="MyCatalog" />
                            </ZoneTemplate>
                            <HeaderVerbStyle Font-Bold="False" Font-Size="0.8em" Font-Underline="False" ForeColor="#333333" />
                            <PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
                            <FooterStyle BackColor="#E2DED6" HorizontalAlign="Right" />
                            <PartChromeStyle BorderColor="#E2DED6" BorderStyle="Solid" BorderWidth="1px" />
                            <InstructionTextStyle Font-Size="0.8em" ForeColor="#333333" />
                            <LabelStyle Font-Size="0.8em" ForeColor="#333333" />
                            <PartLinkStyle Font-Size="0.8em" />
                            <SelectedPartLinkStyle Font-Size="0.8em" />
                            <VerbStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" />
                            <HeaderStyle BackColor="#E2DED6" Font-Bold="True" Font-Size="0.8em" ForeColor="#333333" />
                            <EmptyZoneTextStyle Font-Size="0.8em" ForeColor="#333333" />
                            <EditUIStyle Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" />
                            <PartStyle BorderColor="#F7F6F3" BorderWidth="5px" />
                        </asp:CatalogZone>
                    </td>
                    <td style="width: 60%">
                        <asp:WebPartZone runat="server" ID="MainZone" BorderColor="#CCCCCC" Font-Names="Verdana"
                            Padding="6">
                            <ZoneTemplate>
                                <uc1:Customers ID="MyCustomers" runat="server" />
                            </ZoneTemplate>
                            <PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
                            <MenuLabelHoverStyle ForeColor="#E2DED6" />
                            <EmptyZoneTextStyle Font-Size="0.8em" />
                            <MenuLabelStyle ForeColor="White" />
                            <MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid"
                                BorderWidth="1px" ForeColor="#333333" />
                            <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
                            <MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
                            <PartStyle Font-Size="0.8em" ForeColor="#333333" />
                            <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
                            <MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana"
                                Font-Size="0.6em" />
                            <PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
                        </asp:WebPartZone>
                    </td>
                    <td width="20%">
                        <asp:WebPartZone runat="server" ID="HelpZone" BorderColor="#CCCCCC" Font-Names="Verdana"
                            Padding="6">
                            <ZoneTemplate>
                                <asp:Calendar runat="server" ID="MyCalendar" OnSelectionChanged="MyCalendar_SelectionChanged" />
                                <asp:FileUpload ID="MyUpload" runat="server" />
                            </ZoneTemplate>
                            <PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" ForeColor="White" />
                            <MenuLabelHoverStyle ForeColor="#E2DED6" />
                            <EmptyZoneTextStyle Font-Size="0.8em" />
                            <MenuLabelStyle ForeColor="White" />
                            <MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" BorderStyle="Solid"
                                BorderWidth="1px" ForeColor="#333333" />
                            <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
                            <MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px" ForeColor="White" />
                            <PartStyle Font-Size="0.8em" ForeColor="#333333" />
                            <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
                            <MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" Font-Names="Verdana"
                                Font-Size="0.6em" />
                            <PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" ForeColor="White" />
                        </asp:WebPartZone>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
