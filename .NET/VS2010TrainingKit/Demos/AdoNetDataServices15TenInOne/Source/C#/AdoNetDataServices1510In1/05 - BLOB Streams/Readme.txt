BLOBSupport let the developer of the ADO.NET Data Service to defer the loading of BLOB data 
until it is request by the client.
By implementing the IDataServiceStreamProvider the developer can control how binary data 
is stored and when to read it from its datasource.

Browse the BLOBStreamService Products entity set and check that no binary data is serialized 
in the response xml file.

Check the content tag type and src attributes which points to the thumbnail picture 
stored in the database.
Browser http://localhost:50000/05%20-%20BLOB%20Streams/EF/BLOBStreamService.svc/Products(714)/$value
to see the thumbnail picture retrieved by the GetReadStream method in the ProductStreamProvider class.