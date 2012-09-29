$netfwk = "HKLM:SOFTWARE\Microsoft\NET Framework Setup\NDP\"
$versions = ls -path $netfwk;
$found = $FALSE;

foreach($version in  $versions)
{
   if ($version.toString().EndsWith("v4.0"))
   {
       $found = $TRUE;
       break;
   }       
}

Return $found;


