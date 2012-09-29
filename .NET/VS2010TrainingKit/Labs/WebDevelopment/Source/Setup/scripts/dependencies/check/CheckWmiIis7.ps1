$query = Get-WmiObject Win32_Service | where {$_.Name -eq "w3svc" }
$query -ne $null