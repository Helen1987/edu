$Build=(get-item 'HKLM:/Software/Microsoft/Windows NT/CurrentVersion').getvalue('CurrentBuildNumber')

$Build -eq "6001"