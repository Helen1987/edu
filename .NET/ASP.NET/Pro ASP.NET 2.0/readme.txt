---------------------------
Notes for specific chapters
---------------------------

The following notes describe database setup details. You can change
the connection string and other configuration details to use these
examples on any computer, but the details here will help you get up
to speed more quickly.


--------------------
Chapter 8, 9, 10, 33
--------------------

These chapters use the Northwind database with added stored procedures.
A local instance of SQL Server 7, 2000, or 2005 is assumed.
* Use InstNwnd.sql if you don't already have the Northwind database.
* Use EmployeesProcedures.sql to install the stored procedures for seleting,
insert, updating, deleting, and paging Employees records.


----------
Chapter 16
----------

The custom navigation provider assumes certain navigation tables and
a GetSiteMap stored procedure.
* Use SiteMap.sql to install the table and stored procedure


------------------------------
Chapter 17, 20, 21, 23, 25, 31
------------------------------

Various examples in these chapters use SQL Server 2005 in Express mode.
If you are using SQL Server 2005 Express, ASP.NET will automatically
create the database file you need. Otherwise, you will need to modify the
connection strings.


----------
Chapter 24
----------

The custom profile provider assumes certain site map tables in the 
aspnet database.
* Use ProfileProvider.sql to install the Users table and stored procedures.


