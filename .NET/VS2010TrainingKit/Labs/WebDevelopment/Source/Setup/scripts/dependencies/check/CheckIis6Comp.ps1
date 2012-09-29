$query = Get-WmiObject -Query "SELECT * FROM Win32_ServerFeature WHERE ID = 179"
$query -ne $null