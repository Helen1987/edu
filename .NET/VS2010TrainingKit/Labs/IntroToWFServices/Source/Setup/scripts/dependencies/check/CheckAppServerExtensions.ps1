function CheckServerExtensions($ApplicationServerExtensions)
{
    $found = $FALSE;
 
    if (test-path $ApplicationServerExtensions )
    {
        $entryProperties = Get-ItemProperty -path $ApplicationServerExtensions
 
        if(($entryProperties.Worker -eq 1) -and ($entryProperties.WorkerAdmin -eq 1) -and ($entryProperties.DCC -eq 1))
        { 
            $found = $TRUE;
        }
    }
 
   $found;
}
 
function SearchAllServerExtensions()
{
    #32 bits
    $found =  CheckServerExtensions -ApplicationServerExtensions 'HKLM:SOFTWARE\Microsoft\AppFabric\v1.0\Features\';   
    if($found) {return $found;}
   
    #Wow folder, 64 bits
    $found =  CheckServerExtensions -ApplicationServerExtensions 'HKLM:SOFTWARE\Wow6432Node\Microsoft\AppFabric\v1.0\Features\';   
     
    return $found;
}
 
SearchAllServerExtensions