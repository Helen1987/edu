<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSite._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Adventure Works</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="ProductGateway.js" type="text/javascript" language="javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" Style="display: none" />

    <cc1:toolkitscriptmanager id="ToolkitScriptManager" runat="server">
       <Scripts>
         <asp:ScriptReference Path="~/Scripts/MicrosoftAjaxAdoNet.debug.js" />
       </Scripts>
   </cc1:toolkitscriptmanager>

    <cc1:modalpopupextender runat="server" ID="ModalPopupExtender1" TargetControlID="hiddenTargetControlForModalPopup"
        PopupControlID="pnlProductDetail" BackgroundCssClass="modalBackground" OkControlID="btnSave"
        OnOkScript="doSaveAction()" CancelControlID="btnCancel" DropShadow="true" PopupDragHandleControlID="pnlDrag"
        BehaviorID="programmaticModalPopupBehavior">
    </cc1:modalpopupextender>
    <div id="main">
        <div id="header">
            <h1>Adventure Works</h1>
        </div>
        <div id="content">
            <div id="productSearch">
                <h2>
                    Product Search</h2>
                <p>
                    <label>
                        Product Category<br />
                        <asp:DropDownList ID="cmbProductCategory" runat="server">
                        </asp:DropDownList>
                    </label>
                </p>
                <p>
                    <label>
                        Product Name<br />
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                    </label>
                </p>
                <input name="btnSearch" type="button" value="Search" onclick="getProducts();" id="btnSearch" />
            </div>
            <div id="productsList">
            </div>
                <p>
                    <span>
                        <input type="button" value="New Product" name="btnNew" onclick="showNewProduct();" id="btnNew"/></span>
                    <span>
                        <input type="button" value="Delete Product" name="btnDelete" onclick="deleteProduct();return false;" id="btnDelete" /></span>
                </p>
            
            <asp:Panel runat="server" ID="pnlProductDetail" CssClass="modalPopup" Style="display: none">
                <asp:Panel ID="pnlDrag" runat="server" Style="cursor: move;">
                     <h2><span id="lbl_pd_title" ></span></h2>
                   </asp:Panel>
                    <div id="productDetail">                       
                        <div class="sectionLeft">
                            <p>
                                <label>
                                    Product Number<br />
                                    <asp:TextBox ID="txtProductNumber" runat="server"></asp:TextBox>
                                </label>
                            </p>
                            <p>
                                <label>
                                    Color<br />
                                    <asp:TextBox ID="txtColor" runat="server">
                                    </asp:TextBox></label></p>
                            <p>
                                <label>
                                    Standard Cost<br />
                                    <asp:TextBox ID="txtStandardCost" runat="server">
                                    </asp:TextBox></label></p>
                            <p>
                                <label>
                                    Size<br />
                                    <asp:TextBox ID="txtSize" runat="server">
                                    </asp:TextBox></label></p>
                        </div>
                        <div class="sectionRight">
                            <p>
                                <label>
                                    Name<br />
                                    <asp:TextBox ID="txtName" runat="server">
                                    </asp:TextBox></label></p>
                            <p>
                                <label>
                                    Category<br />
                                    <asp:DropDownList ID="cmbPDCategory" runat="server">
                                    </asp:DropDownList>
                                </label>
                            </p>
                            <p>
                                <label>
                                    List Price<br />
                                    <asp:TextBox ID="txtListPrice" runat="server">
                                    </asp:TextBox></label></p>
                            <p>
                                <label>
                                    Weight<br />
                                    <asp:TextBox ID="txtWeight" runat="server">
                                    </asp:TextBox></label></p>
                        </div>
                        <p>
                            <input name="txtSelectedIndex" type="hidden" id="txtSelectedIndex" /></p>
                        <p>
                            <span>
                                <input type="button" value="Save" name="btnSave" id="btnSave" /></span> <span>
                                    <input type="button" value="Cancel" name="btnCancel" id="btnCancel" /></span>
                        </p>
                    </div>
                
            </asp:Panel>
        </div>
        <div id="footer">Adventure Works</div>
    </div>
    </form>
    <script type="text/javascript" language="javascript">
        getCategories();
    </script>
</body>
</html>
