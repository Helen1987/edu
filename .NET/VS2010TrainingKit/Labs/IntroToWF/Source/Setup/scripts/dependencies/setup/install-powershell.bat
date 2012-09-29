@ECHO OFF

ECHO Installing Microsoft Windows PowerShell, please wait...

start /w pkgmgr /iu:MicrosoftWindowsPowerShell

REM If pkgmgr could not enable Powershell
IF ERRORLEVEL 0 GOTO EndSuccessfully

REM If the after installing powershell the Ps folder doesn't exist
IF EXIST %WINDIR%\SysWow64 (
 IF EXIST %WINDIR%\SysWow64\windowspowershell\v1.0 GOTO EndSuccessfully
) ELSE (
 IF EXIST %WINDIR%\system32\windowspowershell\v1.0 GOTO EndSuccessfully
)

ECHO.
ECHO ****************************************************************
ECHO * Windows PowerShell could not be installed automatically!     *
ECHO *                                                              *
ECHO * Press any key to download and install Windows Powershell.    *
ECHO *                                                              *
ECHO * You will need to rescan the dependencies with the            *
ECHO * with the configuration wizard after PowerShell is installed. *
ECHO ****************************************************************
ECHO.
pause

start http://www.microsoft.com/technet/scriptcenter/topics/msh/download.mspx

:EndSuccessfully