function SearchUninstall($SearchFor, $UninstallKey)
{
$uninstallObjects = ls -path $UninstallKey;
$found = $FALSE;

foreach($uninstallEntry in  $uninstallObjects)
{
   $entryProperty = Get-ItemProperty -path registry::$uninstallEntry
   if($entryProperty.DisplayName -like $searchFor)
    {       
       $found = $TRUE;
       break;
    }
}

$found;
}

function SearchAllUninstallKeys($SearchFor)
{
    $os = Get-WMIObject win32_operatingsystem
    [bool] $found = $False;
    $SearchFor64bits = "$SearchFor (64-bit)"    
    
    # Seach in uninstall folder
    $found =  SearchUninstall -SearchFor $SearchFor -UninstallKey 'HKLM:SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\';    
    if($found) {return $found;}
    
    #Search in 64 bit keys folders
    if ($os.OSArchitecture -eq "64-bit") {
        #Wow folder
        $found =  SearchUninstall -SearchFor $SearchFor -UninstallKey 'HKLM:SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\';    
        if($found)  {return $found;}
        
        #Wow folder, 64 bits
        $found =  SearchUninstall -SearchFor  $SearchFor64bits -UninstallKey 'HKLM:SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\';    
        if($found)  {return $found;}
        
        #32bit folder, 64 bits
        $found =  SearchUninstall -SearchFor  $SearchFor64bits -UninstallKey 'HKLM:SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\';    
        if($found)  {return $found;}
    }
	
	return $found;
}

$sqlServer2008 = SearchAllUninstallKeys -SearchFor 'Microsoft SQL Server 2008';
$sqlServer2005 = SearchAllUninstallKeys -SearchFor 'Microsoft SQL Server 2005';

return $sqlServer2008 -or $sqlServer2005
