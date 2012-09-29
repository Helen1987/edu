/// <reference path="MicrosoftAjax.js" />
/// <reference path="MicrosoftAjaxAdoNet.js" />
/// <reference path="MicrosoftAjaxTemplates.js" />

Sys.Application.add_init(function() {
    var dataContext = Sys.create.adoNetDataContext({
            serviceUri: "AdventureWorks.svc"
    });


    var customersTemplate = $create(Sys.UI.DataView,
                            {
                                autoFetch: true,
                                dataProvider: dataContext,
                                fetchOperation: "Customers",
                                fetchParameters: { $top: 20, $orderby: "FirstName", $expand: "Orders" },
                                initialSelectedIndex: 0,
                                selectedItemClass: "selected"
                            },
                            null,
                            null,
                            $get("customers-template"));

    var customerTemplate = $create(Sys.UI.DataView,
                           null,
                           null,
                           null,
                           $get("customer-template"));

    $create(Sys.Binding,
    {
        defaultValue: null,
        source: customersTemplate,
        path: "selectedData",
        target: customerTemplate,
        targetProperty: "data"
    });
});