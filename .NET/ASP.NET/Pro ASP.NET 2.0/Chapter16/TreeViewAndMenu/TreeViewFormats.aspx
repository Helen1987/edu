<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeViewFormats.aspx.cs" Inherits="TreeViewFormats" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
    <style>
    body {
    font-size:x-small;
    
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <table style="width: 631px">
            <tr>
                <td style="height: 106px">
                    <asp:TreeView ID="TreeView1" runat="server">
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                    </asp:TreeView>
                    &nbsp;&nbsp; &nbsp;Normal</td>
                <td style="height: 106px">
                    <asp:TreeView ID="TreeView2" runat="server" ImageSet="WindowsHelp">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="1px" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    </asp:TreeView>
                    &nbsp; Windows Help</td>
                <td style="height: 106px">
                    <asp:TreeView ID="TreeView3" runat="server" ImageSet="XPFileExplorer" NodeIndent="15">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                            NodeSpacing="0px" VerticalPadding="2px" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    </asp:TreeView>
                    &nbsp; XP File Explorer</td>
            </tr>
            <tr>
                <td style="height: 105px">
                    <asp:TreeView ID="TreeView4" runat="server" ImageSet="News" NodeIndent="10">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="True" />
                    </asp:TreeView>
                    &nbsp; News</td>
                <td style="height: 105px">
                    <asp:TreeView ID="TreeView5" runat="server" ImageSet="Msdn" NodeIndent="10">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle BackColor="White" BorderColor="#888888" BorderStyle="Solid" BorderWidth="1px"
                            Font-Underline="False" HorizontalPadding="3px" VerticalPadding="1px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="1px" VerticalPadding="2px" />
                        <HoverNodeStyle BackColor="#CCCCCC" BorderColor="#888888" BorderStyle="Solid" Font-Underline="True" />
                    </asp:TreeView>
                    &nbsp; MSDN</td>
                <td style="height: 105px">
                    <asp:TreeView ID="TreeView6" runat="server" ImageSet="Inbox">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="True" />
                    </asp:TreeView>
                    &nbsp; Inbox</td>
            </tr>
            <tr>
                <td style="height: 108px">
                    <asp:TreeView ID="TreeView7" runat="server" ImageSet="Faq">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="DarkBlue" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="Purple" />
                    </asp:TreeView>
                    &nbsp; FAQ</td>
                <td style="height: 108px">
                    <asp:TreeView ID="TreeView9" runat="server" ImageSet="Arrows">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    </asp:TreeView>
                    &nbsp; Arrows</td>
                <td style="height: 108px">
                    <asp:TreeView ID="TreeView8" runat="server" ImageSet="Events">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="False" ForeColor="Red" />
                    </asp:TreeView>
                    &nbsp; Events</td>
            </tr>
            <tr>
                <td>
                    <asp:TreeView ID="TreeView10" runat="server" ImageSet="BulletedList" ShowExpandCollapse="False">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    </asp:TreeView>
                    &nbsp; Bulleted List</td>
                <td>
                    <asp:TreeView ID="TreeView12" runat="server" ImageSet="Contacts" NodeIndent="10">
                        <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="False" />
                    </asp:TreeView>
                    &nbsp; Contacts</td>
                <td>
                    <asp:TreeView ID="TreeView11" runat="server" ImageSet="Simple" NodeIndent="10">
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#DD5555" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                            <asp:TreeNode Text="Root" Value="Root">
                                <asp:TreeNode Text="First Child" Value="First Child"></asp:TreeNode>
                                <asp:TreeNode Text="Second Child" Value="Second Child"></asp:TreeNode>
                            </asp:TreeNode>
                        </Nodes>
                        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#DD5555" />
                    </asp:TreeView>
                    &nbsp; Simple</td>
            </tr>
        </table>
    </form>
</body>
</html>
