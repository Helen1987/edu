@ECHO OFF
ECHO Installing IIS 6.0 Metabase Compatibility...

REM ServerManagerCmd -install Web-Mgmt-Compat -allsubfeatures

start /w pkgmgr /iu:IIS-IIS6ManagementCompatibility;IIS-Metabase