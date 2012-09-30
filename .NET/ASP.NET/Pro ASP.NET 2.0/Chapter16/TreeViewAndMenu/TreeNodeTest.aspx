<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TreeNodeTest.aspx.cs" Inherits="TreeNodeTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="2">
            <Nodes>
                <asp:TreeNode Text="New Node" Value="New Node">
                    <asp:TreeNode SelectAction="SelectExpand" Text="New Node" Value="New Node">
                        <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="New Node" Value="New Node"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    
    </div>
    </form>
</body>
</html>
