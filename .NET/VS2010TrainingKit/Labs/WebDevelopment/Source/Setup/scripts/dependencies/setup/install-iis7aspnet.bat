@ECHO OFF
ECHO Installing ASP.NET role...

REM ServerManagerCmd -install Web-Asp-Net

start /w pkgmgr /iu:IIS-ApplicationDevelopment;IIS-ASPNET;IIS-NetFxExtensibility;IIS-ISAPIExtensions;IIS-ISAPIFilter;