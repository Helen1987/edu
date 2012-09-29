var Records;
var ChangeAction;

function getService() {
    return new Sys.Data.AdoNetServiceProxy("/AdventureWorks.svc");
}

function showNewProduct() {
    ChangeAction = "insert";
    $get("txtName").value = "";
    $get("txtProductNumber").value = "";
    $get("txtColor").value = "";
    $get("txtStandardCost").value = "";
    $get("txtListPrice").value = "";
    $get("txtSize").value = "";
    $get("txtWeight").value = "";
    $get("cmbPDCategory").value = $get("cmbProductCategory").value;
    $get("cmbPDCategory").disabled = false;
    $get("lbl_pd_title").innerHTML = "Add a New Product";

    showModalPopup();
}

function showUpdateProduct(index) {
    ChangeAction = "update";
    var product = Records[index];

    $get("txtName").value = product.Name;
    $get("txtProductNumber").value = product.ProductNumber;
    $get("txtColor").value = product.Color;
    $get("txtStandardCost").value = product.StandardCost;
    $get("txtListPrice").value = product.ListPrice;
    $get("txtSize").value = product.Size;
    $get("txtWeight").value = product.Weight;
    $get("cmbPDCategory").value = $get("cmbProductCategory").value;
    $get("cmbPDCategory").disabled = true;

    $get("txtSelectedIndex").value = index;
    $get("lbl_pd_title").innerHTML = "Edit " + product.Name;

    showModalPopup();
}

function insertProduct() {
    var ServiceGateway = getService();

    var newProduct =
    {
        Name: $get("txtName").value,
        ProductNumber: $get("txtProductNumber").value,
        Color: $get("txtColor").value,
        StandardCost: $get("txtStandardCost").value,
        ListPrice: $get("txtListPrice").value,
        Size: $get("txtSize").value,
        Weight: $get("txtWeight").value,
        ProductCategory: { __metadata: { uri: "ProductCategory(" +
                         $get("cmbPDCategory").value + ")"
        } 
        },
        SellStartDate: new Date(),
        SellEndDate: new Date(),
        ModifiedDate: new Date()
    };

    ServiceGateway.insert(newProduct, "/Product", insertProductSuccess, genericFailure);
}


function insertProductSuccess(result, context, operation) {
    getProducts();
}


function updateProduct() {
    var ServiceGateway = getService();

    updatedProduct = Records[$get("txtSelectedIndex").value];
    updatedProduct.Name = $get("txtName").value;
    updatedProduct.ProductNumber = $get("txtProductNumber").value;
    updatedProduct.Color = $get("txtColor").value;
    updatedProduct.StandardCost = $get("txtStandardCost").value;
    updatedProduct.ListPrice = $get("txtListPrice").value;
    updatedProduct.Size = $get("txtSize").value;
    updatedProduct.Weight = $get("txtWeight").value;
    updatedProduct.ModifiedDate = new Date();


    ServiceGateway.update(updatedProduct, updateProductSuccess, genericFailure);
}

function updateProductSuccess(result, context, operation) {
    getProducts();
}

function deleteProduct() {
    var ServiceGateway = getService();

    for (i = 0; i < Records.length; i++) {
        var chk = $get("chk_product_" + i);
        if (chk.checked) {
            var product = Records[i];
            ServiceGateway.remove(product, deleteProductSuccess, genericFailure);
        }
    }
}

function deleteProductSuccess(result, context, operation) {
    getProducts();
}

function getCategories() {
    var ServiceGateway = getService();

    ServiceGateway.query("/ProductCategory?$orderby=Name", getCategoriesSuccess, genericFailure);
}

function getCategoriesSuccess(result, context, operation) {
    var cmbCategory = $get("cmbProductCategory");
    var cmbPDCategory = $get("cmbPDCategory");

    var i = 0;
    for (idx in result) {
        var category = result[idx];
        cmbCategory.options[i] = new Option(category.Name, category.ProductCategoryID);
        cmbPDCategory.options[i] = new Option(category.Name, category.ProductCategoryID);
        i++;
    }
}

function getProducts() {
    var ServiceGateway = getService();
    var sb = new Sys.StringBuilder();
    sb.append("GetProducts?");
    sb.append("productName='");
    sb.append($get("txtProductName").value);
    sb.append("'&");
    sb.append("productCategoryId=");
    sb.append($get("cmbProductCategory").value);

    ServiceGateway.query(sb.toString(), getProductsSuccess, genericFailure);
}

var grid_columns = ',ProductID,ProductNumber,Name,ListPrice,Color,Size,Weight,ModifiedDate,';

function getProductsSuccess(result, context, operation) {
    var sb = new Sys.StringBuilder();
    sb.append("<table id='productsGrid' cellspacing='0'>");

    var firstRowOutput = false;
    for (idx in result) {
        var products = result[idx];
        if (!firstRowOutput) {
            sb.append("<tr>");
            sb.append("<th> Select </th>");
            for (key in products) {
                if (key != "__metadata" && grid_columns.indexOf(',' + key + ',', 0) > 0) {
                    sb.append("<th>");
                    sb.append(key);
                    sb.append("</th>");
                }
            }
            sb.append("</tr>");
            firstRowOutput = true;
        }

        // output the data
        sb.append("<tr onclick='showUpdateProduct( " + idx + " );'>");
        sb.append("<td> <input type='checkbox' id='chk_product_" + idx + "' onClick='chkClicked();'/></td>");

        for (key in products) {
            if (key != "__metadata" && grid_columns.indexOf(',' + key + ',', 0) > 0) {
                sb.append("<td>");
                if (key == "ModifiedDate") {
                    sb.append(products[key].format("yyyy-MM-dd"));
                }
                else {
                    sb.append(products[key]);
                }
                sb.append("</td>");
            }
        }
        sb.append("</tr>");
    }

    sb.append("</table>");

    $get("productsList").innerHTML = sb.toString();
    Records = result;
}

function genericFailure(error, context, operation) {
    alert(error.get_message());
}

function doSaveAction() {
    if (ChangeAction == "insert") {
        insertProduct();
    }
    else if (ChangeAction == "update") {
        updateProduct();
    }
}

function chkClicked(e) {
    if (!e) {
        var e = window.event;
    }
    e.cancelBubble = true;

    if (e.stopPropagation) {
        e.stopPropagation();
    }
}

function showModalPopup() {
    var modalPopupBehavior = $find('programmaticModalPopupBehavior');
    modalPopupBehavior.show();
}