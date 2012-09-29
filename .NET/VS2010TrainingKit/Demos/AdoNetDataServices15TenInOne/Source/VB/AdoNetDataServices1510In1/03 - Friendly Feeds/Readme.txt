WCF Data Services exposes an instance of an entity type,
it serializes the data using the Atom Publishing Protocol (AtomPub/APP) format. 
Every public property on the entity type gets mapped to an element within 
the content of the respective entry element.

While this default behavior works just fine for many situations, there are 
some oddities when using APP [Advance Animation]. For instance, 
the APP format requires that every entry includes a title and an author.
ADO.NET Data Services will render these elements, but never actually 
fill them with content. This could confuse consumers of the service that are 
APP aware and would expect to be provided with a title and/or author.

In 1.5, ADO.NET Data Services introduces a feature called “friendly feeds” 
that allows you to map an entity property to an element within the APP entry. 
This can either be a pre-defined element such a title or author, or a custom element. 
The ability to map properties to custom elements allows you to add additional 
information to your data feeds, such as microformats (i.e. GeoRSS), 
that can be interpreted by understanding clients.

If you open and request the list of Product entities you ill notice that the author 
element is mapped to the Name property of the Product class.
Navigate to http://localhost:50000/03%20-%20Friendly%20Feeds/CLR/FriendlyFeeds.svc/Products 
and check the author element.

<author>
  <name>XBOX 360</name> 
</author>

This is achieved by decorating the custom entity class with the EntityPropertyMapping 
attribute.