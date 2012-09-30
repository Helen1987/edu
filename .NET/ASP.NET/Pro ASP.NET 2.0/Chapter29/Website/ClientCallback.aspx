<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientCallback.aspx.cs" Inherits="ClientCallback" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script language="javascript">
   function ClientCallback(result, context){
      
      var lstTerritories = document.forms[0].elements['lstTerritories'];
      
      lstTerritories.innerHTML= "";
      var rows = result.split('||'); 
      for (var i = 0; i < rows.length - 1; ++i){
         var fields = rows[i].split('|'); 
         var territoryDesc = fields[0];
         var territoryID = fields[1];
         var option = document.createElement("option");
         
         option.value = territoryID;
         option.innerHTML = territoryDesc;
         lstTerritories.appendChild(option);
      }
   }


</script>

</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:Verdana;font-size:small ">
        Choose a Region, and then a Territory:<br />
        <br />
      <asp:DropDownList ID="lstRegions" Runat="server" Width="210px" DataSourceID="sourceRegions" DataTextField="RegionDescription" DataValueField="RegionID">
        </asp:DropDownList>
        <asp:DropDownList ID="lstTerritories" Runat="server" Width="275px">
        </asp:DropDownList><br />
        <br />
        <br />
        <asp:Button ID="cmdOK" Runat="server" Text="OK" Width="50px" OnClick="cmdOK_Click"  /><br />
        <br />
        <asp:Label ID="lblInfo" runat="server"></asp:Label>
         <asp:SqlDataSource ID="sourceRegions" runat="server" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:Northwind %>" SelectCommand="SELECT 0 As RegionID, '' AS RegionDescription UNION SELECT RegionID, RegionDescription FROM Region" ></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>

