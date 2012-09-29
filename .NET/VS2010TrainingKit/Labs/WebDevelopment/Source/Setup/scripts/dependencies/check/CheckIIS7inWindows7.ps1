$query = Get-WmiObject -Query "SELECT * FROM Win32_OptionalFeature WHERE name = 'IIS-WebServerRole'"
$query.InstallState -eq 1