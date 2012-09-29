Q. Why do demos 4-6 fail the second time recomposition happens?

A. This is a bug in Beta 2 that has been addressed in future builds of MEF. 
You can have automatic recomposition work when switching from online->offline, but
going back from offline->online fails (or vice versa). To get around this (as 
a presenter), you can simply do the single recomposition to get the point
across.