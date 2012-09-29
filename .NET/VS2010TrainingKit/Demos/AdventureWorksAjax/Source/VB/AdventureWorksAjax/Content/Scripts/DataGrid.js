/// <reference path="MicrosoftAjax.debug.js" />
/// <reference path="MicrosoftAjaxAdoNet.debug.js" />
/// <reference path="MicrosoftAjaxTemplates.debug.js" />

Sys.UI.DataGrid = function Sys$UI$DataGrid(element)
{
    Sys.UI.DataGrid.initializeBase(this, [element]);

    this.set_selectedItemClass("selected");
    this.set_initialSelectedIndex(0);
}

function Sys$UI$DataGrid$get_alternateRowClass()
{
    /// <value type="String" mayBeNull="true" />
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._alternateRowClass;
}

function Sys$UI$DataGrid$set_alternateRowClass(value)
{
    var e = Function._validateParams(arguments, [{ name: "value", type: String, mayBeNull: true }]);
    if (e) throw e;
    this._alternateRowClass = value;
}

function Sys$UI$DataGrid$get_columnExpressions()
{
    /// <value type="Object" mayBeNull="true" />
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._columnExpressions;
}

function Sys$UI$DataGrid$set_columnExpressions(value)
{
    var e = Function._validateParams(arguments, [{ name: "value", type: Object}]);
    if (e) throw e;
    this._columnExpressions = value;
}

function Sys$UI$DataGrid$get_columnHeaders()
{
    /// <value type="Object" mayBeNull="true" />
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._columnHeaders;
}

function Sys$UI$DataGrid$set_columnHeaders(value)
{
    var e = Function._validateParams(arguments, [{ name: "value", type: Object, mayBeNull: true}]);
    if (e) throw e;
    this._columnHeaders = value;
}

function Sys$UI$DataGrid$get_enableSelect()
{
    /// <value type="Boolean" />
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._enableSelect;
}

function Sys$UI$DataGrid$set_enableSelect(value)
{
    this._enableSelect = value;
}

function Sys$UI$DataGrid$get_loadingMessage()
{
    /// <value type="String" />
    if (arguments.length !== 0) throw Error.parameterCount();
    return this._loadingMessage;
}

function Sys$UI$DataGrid$set_loadingMessage(value)
{
    this._loadingMessage = value;
}

function Sys$UI$DataGrid$initialize()
{
    if (this._columnHeaders)
    {
        var tableHeader = document.createElement("thead");
        var tableRow = document.createElement("tr");

        for (var i = 0; i < this._columnHeaders.length; i++)
        {
            var tableCell = document.createElement("th");
            tableCell.appendChild(document.createTextNode(this._columnHeaders[i]));
            tableRow.appendChild(tableCell);
        }
        
        tableHeader.appendChild(tableRow);
        this.get_element().appendChild(tableHeader);
        
        var tableBody = document.createElement("tbody");
        var tableRow = document.createElement("tr");
        
        var tableCell = document.createElement("td");
        tableCell.setAttribute("colspan", this._columnHeaders.length + 1);
        tableCell.appendChild(document.createTextNode(this._loadingMessage));
        tableRow.appendChild(tableCell);
        tableBody.appendChild(tableRow);
        
        this.get_element().appendChild(tableBody);
        this.set_itemPlaceholder(tableRow);
    }
    
    var tableBody = document.createElement("tbody");
    var tableRow = document.createElement("tr");
    
    if (this._enableSelect)
        tableRow.setAttribute("sys:command", "select");
        
    if (this._alternateRowClass)
        tableRow.setAttribute("class:" + this._alternateRowClass, "{{ $index % 2 != 0 }}");
    
    for (var i = 0; i < this._columnExpressions.length; i++)
    {
        var columnExpression = this._columnExpressions[i];

        if (columnExpression.indexOf("{") == -1)
            columnExpression = "{binding " + columnExpression + ", defaultValue=}";
            
        var tableCell = document.createElement("td");
        tableCell.appendChild(document.createTextNode(columnExpression));
        tableRow.appendChild(tableCell);
    }

    tableBody.appendChild(tableRow);
    this.set_itemTemplate(tableBody);

    Sys.UI.DataGrid.callBaseMethod(this, "initialize");
}

Sys.UI.DataGrid.prototype =
{
    _alternateRowClass: "alternate",
    _columnExpressions: null,
    _columnHeaders: null,
    _enableSelect: true,
    _loadingMessage: "Loading...",
    get_alternateRowClass: Sys$UI$DataGrid$get_alternateRowClass,
    set_alternateRowClass: Sys$UI$DataGrid$set_alternateRowClass,
    get_columnExpressions: Sys$UI$DataGrid$get_columnExpressions,
    set_columnExpressions: Sys$UI$DataGrid$set_columnExpressions,
    get_columnHeaders: Sys$UI$DataGrid$get_columnHeaders,
    set_columnHeaders: Sys$UI$DataGrid$set_columnHeaders,
    get_enableSelect: Sys$UI$DataGrid$get_enableSelect,
    set_enableSelect: Sys$UI$DataGrid$set_enableSelect,
    get_loadingMessage: Sys$UI$DataGrid$get_loadingMessage,
    set_loadingMessage: Sys$UI$DataGrid$set_loadingMessage,
    initialize: Sys$UI$DataGrid$initialize
};

Sys.UI.DataGrid.registerClass("Sys.UI.DataGrid", Sys.UI.DataView);