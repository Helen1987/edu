The server-driven paging feature revolves around a new method
that was added to the DataServiceConfiguration class. In order to
"configure" server-driven paging on a specific entity set, you 
simply call the SetEntitySetPageSize of the DataServiceConfiguration 
class, within the InitializeService method. 
You can see this in use in the ServerDrivenPagingService.svc.cs file.

There are no distinctions between how you configure server-driven
paging for a CLR or EF provider. From a server perspective, once
you've called SetEntitySetPageSize for every entity set you wish
to page, you are done.

If you open a browser and request an entity set that has been page-restricted,
(i.e http://localhost:50000/02%20-%20Server-Driven%20Paging/ServerDrivenPagingService.svc/Products)
you will only be able to get back at most the number of records specified in
the server-side page (i.e. 20). If more pages of data exist then a <link> element (named "next")
will be included in the AtomPub that provides a link to the next page. It will
look something like the following:

<link rel="next" href="http://localhost:50000/02%20-%20Server-Driven%20Paging/ServerDrivenPagingService.svc/Products?$skiptoken=744" /> 

The $skiptoken parameter is simply specifying the key values used to skip ahead
to the requested page. In the above example, it is requesting all products whose
id is higher than 744. The generation of the next links is done automatically
for us by the data service. Unfortunately, in v1.5, there won't be an automatic
generation of "previous links", so the server-driven paging is only forward-only.

There aren't currently any client APIs that make it easier to take advantage
of the server-driven paging feature (i.e. appending the $skiptoken parameter to the request).