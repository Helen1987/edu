Write-Host 
# define variables for script
$SiteTitle = "SharePoint Tools Lab - The VS 2010 SharePoint Developers Tools"
$SiteUrl = "http://localhost/sites/SharePointToolsLab"
$SiteTemplate = "STS#1"
# check to ensure Microsoft.SharePoint.PowerShell is loaded
$snapin = Get-PSSnapin | Where-Object {$_.Name -eq 'Microsoft.SharePoint.Powershell'}
if ($snapin -eq $null) {
Write-Host "Loading SharePoint Powershell Snapin"
Add-PSSnapin "Microsoft.SharePoint.Powershell"
}

# delete any existing site found at target URL
$targetUrl = Get-SPSite | Where-Object {$_.Url -eq $SiteUrl}
if ($targetUrl -ne $null) {
  Write-Host "Deleting existing site at" $SiteUrl
  Remove-SPSite -Identity $SiteUrl -Confirm:$false
}

# create new site at target URL
Write-Host "Creating new site at" $SiteUrl 
$NewSite = New-SPSite -URL $SiteUrl -OwnerAlias Administrator -Template $SiteTemplate -Name $SiteTitle
$RootWeb = $NewSite.RootWeb

# display site info
Write-Host 
Write-Host "Site created successfully" -foregroundcolor Green
Write-Host "-------------------------------------" -foregroundcolor Green
Write-Host "URL:" $RootWeb.Url -foregroundcolor Yellow
Write-Host "ID:" $RootWeb.Id.ToString() -foregroundcolor Yellow
Write-Host "Title:" $RootWeb.Title -foregroundcolor Yellow
Write-Host "-------------------------------------" -foregroundcolor Green