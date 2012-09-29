In this demo, you will see how to add an Publishing button to the Backstage, and to the Ribbon. 

Both elements will have the same functionality (export to an specific document format, like XPS and PDF.) In Backstage, you will be able to configure the behavior of the export button.
This configuration will impact the functionality of both, the Backstage and Ribbon export buttons.

Before exporting the document to XPS or PDF using this Add-In, make sure to save it first (for instance, in your Documents' folder). This way, the exported document will be placed in the same folder as the original Word document.

The code that implements the Backstage and Ribbon buttons functionality can be found in the Ribbon.cs or Ribbon.vb class file sorrounded by a "Ribbon Callbacks" region.