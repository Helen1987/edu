<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TemplatesAndConcurrency.aspx.cs" Inherits="TemplatesAndConcurrency" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style>
    body {
    font-family:Verdana;
    font-size:small;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DetailsView ID="detailsEditing" runat="server" Height="50px" Width="365px" AllowPaging="True" AutoGenerateRows="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ShipperID" DataSourceID="sourceShippers" Font-Names="Verdana" Font-Size="Small" OnItemUpdated="DetailsView1_ItemUpdated">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <Fields>
                <asp:BoundField DataField="ShipperID" HeaderText="ShipperID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ShipperID" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <EditRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        </asp:DetailsView>
    <asp:SqlDataSource ID="sourceShippers" 
         ConnectionString="<%$ ConnectionStrings:Northwind %>"
          SelectCommand="SELECT * FROM Shippers"
        runat="server" UpdateCommand="UPDATE Shippers SET CompanyName=@CompanyName, Phone=@Phone WHERE ShipperID=@original_ShipperID AND CompanyName=@original_CompanyName AND Phone=@original_Phone" ConflictDetection="CompareAllValues">
        <UpdateParameters>
            <asp:Parameter Name="CompanyName" />
            <asp:Parameter Name="Phone" />
            <asp:Parameter Name="original_ShipperID" />
            <asp:Parameter Name="original_CompanyName" />
            <asp:Parameter Name="original_Phone" />
        </UpdateParameters>
    </asp:SqlDataSource>
        <br />
        <asp:Label ID="lblStatus" runat="server" EnableViewState="False"></asp:Label>
        <asp:Panel ID="ErrorPanel" runat="server" Visible="False" Width="582px" EnableViewState="False">
        <span></span><span style="color: #ff0000">There is a newer version of this record in
            the database.<br />
            The current record has the values shown below.<br />
            <br />
        </span><asp:DetailsView ID="detailsConflicting" runat="server" Height="50px" Width="365px" AutoGenerateRows="False" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ShipperID" DataSourceID="sourceUpdateValues" Font-Names="Verdana" Font-Size="Small">
                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
                <RowStyle BackColor="White" ForeColor="#330099" />
                <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                <Fields>
                    <asp:BoundField DataField="ShipperID" HeaderText="ShipperID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ShipperID" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                </Fields>
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
                <EditRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            </asp:DetailsView>
            <br />
            <span style="color: #ff0000">*
            Click <b>Update</b></span><span style="color: #ff0000">
                to override these values with your changes.<br />
            </span><span style="color: #ff0000">*
            Click <b>Cancel</b></span><span style="color: #ff0000">
                to abandon your edit.</span>&nbsp;
        <asp:SqlDataSource ConnectionString="<%$ ConnectionStrings:Northwind %>" ID="sourceUpdateValues"
          runat="server" SelectCommand="SELECT * FROM Shippers WHERE (ShipperID = @ShipperID)" OnSelecting="SqlDataSource2_Selecting">
          <SelectParameters>
            <asp:ControlParameter ControlID="detailsEditing" Name="ShipperID" PropertyName="SelectedValue"
              Type="Int32" />
          </SelectParameters>
        </asp:SqlDataSource>
      </asp:Panel>

    </div>
    </form>
</body>
</html>
