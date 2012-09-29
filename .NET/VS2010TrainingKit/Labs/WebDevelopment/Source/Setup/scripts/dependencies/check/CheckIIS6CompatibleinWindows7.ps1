$query = Get-WmiObject -Query "SELECT * FROM Win32_OptionalFeature WHERE name = 'IIS-Metabase'"
$query.InstallState -eq 1