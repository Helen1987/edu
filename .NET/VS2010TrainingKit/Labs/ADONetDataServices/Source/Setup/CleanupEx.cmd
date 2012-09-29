setlocal 
cd %~dp0

@echo off

@REM  -------------------------------------------------------------
@REM  You can change server and database name here.
@REM  -------------------------------------------------------------
SET sqlServer=%1%
if "%1%"=="" set sqlServer=default

SET databaseName=%2%
if "%2%"=="" set databaseName=AdventureWorksLT

SET alias=%3%
if "%3%"=="" set alias=NET40Labs

SET msbuild=%WINDIR%\Microsoft.NET\Framework\v2.0.50727\msbuild.exe
if exist "%msbuild%" goto compileok

SET msbuild=%WINDIR%\Microsoft.NET\Framework\v3.5\msbuild.exe
if exist "%msbuild%" goto compileok
goto error

:compileok

echo.
echo ========================================
echo Building tools
echo ========================================
echo.

%msbuild% /verbosity:quiet .\Util\Tools.sln

echo.
echo ========================================
echo QuickStart Lab Database cleanup started
echo ========================================
echo.

echo IN PROGRESS: Removing database alias if it exists...
.\Util\bin\AliasDatabaseServer %sqlServer% %alias% /delete

echo.

:SUCCESS
echo =============================================
echo Lab uninstalled successfully!
echo =============================================
echo.

GOTO finish

:error
echo.
echo ======================================
echo An error occured. 
echo Please review messages above.
echo ======================================


:FINISH
@PAUSE