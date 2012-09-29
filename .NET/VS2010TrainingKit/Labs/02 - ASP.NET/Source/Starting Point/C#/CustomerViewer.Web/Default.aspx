<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="CustomerViewer.Web._Default" EnableViewState="false" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link rel="Stylesheet" href="Styles/Default.css" />
    <script type="text/javascript" src="Scripts/Default.js"></script>
    <script type="text/javascript">
        var customerSelectID = '<%=CustomersDropDownList.ClientID %>';
    </script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="HeaderText">
        Customers
    </div>
    <br />

    <span style="margin-right:10px;">Select a Customer:</span>

    <asp:DropDownList 
        ID="CustomersDropDownList" runat="server" 
        DataTextField="FullName" 
        DataValueField="CustomerID"  />    
    <br />
    <br />
    <fieldset title="Customer Details" style="width:500px;">
        <legend>Customer Details</legend>
        <div id="CustomerDetailsContainer">
            <div class="LeftDiv">
                Customer ID
            </div>
            <div class="RightDiv">
                <span id="CustomerID"></span>
            </div>
            <div class="ClearDiv"></div>
            <div class="LeftDiv">
                First Name
            </div>
            <div class="RightDiv">
                <input type="text" id="FirstName" class="textbox" />
            </div>
            <div class="ClearDiv"></div>
            <div class="LeftDiv">
                Last Name
            </div>
            <div class="RightDiv">
                <input type="text" id="LastName" class="textbox" />
            </div>
            <div class="ClearDiv"></div>
            <div class="LeftDiv">
                Company Name
            </div>
            <div class="RightDiv">
                <input type="text" id="CompanyName" class="textbox" />
            </div>
            <div class="ClearDiv"></div>
            <div class="LeftDiv">
                Email
            </div>
            <div class="RightDiv">
                <input type="text" id="EmailAddress" class="textbox" />
            </div>
            <div class="ClearDiv"></div>
            <div class="LeftDiv">
                Phone
            </div>
            <div class="RightDiv">
                <input type="text" id="Phone" class="textbox" />
            </div>
            <div class="ClearDiv"></div>
            <div style="margin:0px 0px 40px 0px;padding-top:30px;">
                <input type="button" id="UpdateButton" onclick="UpdateCustomer()" value="Update" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <input type="button" id="DeleteButton" onclick="DeleteCustomer()" value="Delete" />
            </div>
        </div>
    </fieldset>
    
</asp:Content>
