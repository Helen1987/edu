function CheckVisualStudion2010SP1($RegistryKey)
{
    $found = $FALSE;
 
    if (test-path $RegistryKey)
    {
        $entryProperties = Get-ItemProperty -path $RegistryKey
 
        if($entryProperties.SP -eq 1)
        { 
            $found = $TRUE;
        }
    }
 
   $found;
}
 
function SearchVisualStudion2010SP1()
{
    #32 bits
    $found =  CheckVisualStudion2010SP1 -RegistryKey 'HKLM:SOFTWARE\Microsoft\DevDiv\VS\Servicing\10.0\';   
    if($found) {return $found;}
   
    #Wow folder, 64 bits
    $found =  CheckVisualStudion2010SP1 -RegistryKey 'HKLM:SOFTWARE\Wow6432Node\Microsoft\DevDiv\VS\Servicing\10.0\';   
     
    return $found;
}
 
SearchVisualStudion2010SP1