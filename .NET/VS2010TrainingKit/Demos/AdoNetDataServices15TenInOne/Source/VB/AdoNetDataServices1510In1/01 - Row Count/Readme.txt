The row count feature is enabled automatically, so from a server perspecitive,
there isn't anything you have to do to your data service to begin using it. There also
isn't a distinction between using row count with either a CLR or EF provider. There
are however two new query parameters that you'll need to take advantage of this feature: 
$count, and $inlinecount.

$count is actually a psuedo-member (like $value) that allows you to request the record
count of a specific entity set. You use it by appending it after an entity set in your
request URI. This could look like the following:

/RowCountService.svc/Products/$count.

The above example would return the number of products that exist in your data model.
This option works great if all you want is the record count, but chances are you'll likely
want both the count and the actual data. This is where the $inlinecount parameter comes in.

You can add the $inlinecount query parameter to a query and it will include the count of
the targetted entity set along with the response. This could look like the following:

/RowCountService.svc/Products?$inlinecount=allpages

The above example would return both product data as well as the total count of products.
This becomes useful when used in conjunction with server-driven paging (as is used in the
RowCountService.svc.cs file) because you might only get back 20 products but you want to
know how many products exist on the server.

There are client APIs for the row count feature that abstract the need to manually
use either $count or $inlinecount when requesting data from a data service. The DataServiceQuery
class has three new methods: Count, InlineTotalCount, and LongCount. Count and LongCount are
the client API equivalent to $count, and allow you to immediately execute a query that
is requesting the record count of an entity set. The InlineCount method adds the $inlinecount
parameter to the query.

In addition, the QueryOperationResponse class has a new TotalCount method that allows you to retreive
the count that was returned from a request with an $inlinecount appended. You can see examples
of the client APIs in the Client.aspx.cs file.