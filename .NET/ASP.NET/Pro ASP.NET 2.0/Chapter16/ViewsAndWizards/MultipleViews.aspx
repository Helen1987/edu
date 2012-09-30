<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MultipleViews.aspx.cs" Inherits="MultipleViews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="Styles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
               <asp:DropDownList ID="DropDownList1" runat="server" Width="235px"></asp:DropDownList>


            <hr />
        <br />
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0" OnActiveViewChanged="MultiView1_ActiveViewChanged">
                <asp:View ID="View1" runat="server">
                    <b>Showing View #1</b><br />
                        <br />
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/cookies.jpg" />
                        <br />
                        <br />
                        
                        <asp:Button ID="cmdNext" runat="server" Text="Next >" CommandName="NextView" />
                        </asp:View>
                    
                <asp:View ID="View2" runat="server">
                    <b>Showing View #2</b><br />
                    <br />
                    Text content.
                    <asp:Button ID="cmdPrev" runat="server" Text="< Prev" CommandName="PrevView" />
                    <asp:Button ID="cmdNext2" runat="server" Text="Next >" CommandName="NextView" />
                    </asp:View>
                <asp:View ID="View3" runat="server">
                    <b>Showing View #3</b><br />
                    <br />
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                    <asp:Button ID="Button1" runat="server" Text="< Prev" CommandName="PrevView" />
                </asp:View>
            </asp:MultiView>
            </div>
    </form>
</body>
</html>
