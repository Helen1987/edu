$dbSQLExpress = sqlcmd -Q "select count(*) from [master].sys.databases where name = 'AdventureWorksLT'" -S ".\SQLEXPRESS"
$dbSQLServer = sqlcmd -Q "select count(*) from [master].sys.databases where name = 'AdventureWorksLT'" -S ".\"

$found = $TRUE;

if ($dbSQLExpress -match "0" -AND $dbSQLServer -match "0")
{  	
   $found = $FALSE;
}

$found
