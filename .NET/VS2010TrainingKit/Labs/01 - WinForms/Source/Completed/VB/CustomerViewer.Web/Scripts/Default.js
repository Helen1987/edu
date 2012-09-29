var serviceUrl = 'http://localhost.:37989/CustomerService.svc/REST';
var customerSelect;

$(document).ready(function ()
{
    customerSelect = $('#' + customerSelectID);
    customerSelect.change(GetCustomer);
    GetCustomer();
});

function GetCustomer()
{
    var custID = customerSelect.val();
    $.getJSON(serviceUrl + '/GetCustomer/' + custID + '?callback=?', null, function (data)
    {
        $('#CustomerID').text(data.CustomerID);
        $('#FirstName').val(data.FirstName);
        $('#LastName').val(data.LastName);
        $('#CompanyName').val(data.CompanyName);
        $('#EmailAddress').val(data.EmailAddress);
        $('#Phone').val(data.Phone);
    });
}

function UpdateCustomer()
{
    var cust = BuildCustomer()

    $.getJSON(serviceUrl + '/UpdateCustomer?&callback=?&' + $.param(cust),
              null, function (data)
              {
                  if (data.Status)
                  {
                      customerSelect.find('option[value=' + cust.CustomerID + ']')
                                    .text(cust.FirstName + ' ' + cust.LastName);
                      alert("Customer updated!");
                  }
                  else
                  {
                      alert("Unable to update customer: " + data.Message);
                  }
              });
}

function DeleteCustomer()
{
    if (confirm("Delete Customer?"))
    {
        var custID = customerSelect.val();
        $.getJSON(serviceUrl + '/DeleteCustomer/' + custID + '?callback=?', null, function (data)
        {
            if (data.Status)
            {
                customerSelect.find('option[value=' + custID + ']').remove();
                //Show the next customer's data
                GetCustomer();
                alert("Customer deleted!");
            }
            else
            {
                alert("Unable to delete customer: " + data.Message);
            }
        });
    }
}

function BuildCustomer()
{
    var cust =
            {
                CustomerID: $('#CustomerID').text(),
                FirstName: $('#FirstName').val(),
                LastName: $('#LastName').val(),
                CompanyName: $('#CompanyName').val(),
                EmailAddress: $('#EmailAddress').val(),
                Phone: $('#Phone').val()
            };
    return cust;
}