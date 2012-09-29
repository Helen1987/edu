$query = Get-WmiObject -Query "SELECT * FROM Win32_OptionalFeature WHERE name = 'IIS-ASPNET'"
$query.InstallState -eq 1