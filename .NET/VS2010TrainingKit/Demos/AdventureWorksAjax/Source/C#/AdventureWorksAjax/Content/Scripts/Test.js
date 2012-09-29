/// <reference path="MicrosoftAjax.debug.js" />
/// <reference path="MicrosoftAjaxAdoNet.debug.js" />
/// <reference path="MicrosoftAjaxTemplates.debug.js" />

Sys.Application.add_init(function() {
    var dataContext = Sys.create.adoNetDataContext({
            serviceUri: "AdventureWorks.svc"
    });
    
    $create(Sys.UI.DataGrid,
    {
        autoFetch: true,
        dataProvider: dataContext,
        fetchOperation: "Customers",
        fetchParameters: { $top: 20, $orderby: "FirstName" },
        alternateRowClass: "odd",
        columnExpressions: ["Title", "FirstName", "MiddleName", "LastName", "Suffix"],
        columnHeaders: ["Title", "FirstName", "MiddleName", "LastName", "Suffix"],
        itemPlaceholder: $get("customer-placeholder")
    },
    null,
    null,
    $get("customer-list"));
});