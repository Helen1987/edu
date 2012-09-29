$found =  test-path "HKLM:\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\10.0\InstalledProducts\Microsoft Visual Studio 2010 SharePoint Developer Tools";    
if($found)  {return $found;}

$found = test-path "HKLM:\SOFTWARE\Microsoft\VisualStudio\10.0\InstalledProducts\Microsoft Visual Studio 2010 SharePoint Developer Tools";
return  $found;
