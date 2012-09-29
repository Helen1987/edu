This demo shows many of NETFX4 new features, including:
	MEF - Which is used to export the car queries for each brand.
	    - Integration with other .NET Language, exported through MEF
	Parallel Extensions - Execute the brand queries in paralel
			    - Task to execute all functionality asynchronously to avoid locking the view.

When you hit the search button, the border of the brands being queried turns yellow, this is done using the StatusToColorConverter.
	P search button, executes the queries in Parallel 
	S search button, executes the queries secuentially
