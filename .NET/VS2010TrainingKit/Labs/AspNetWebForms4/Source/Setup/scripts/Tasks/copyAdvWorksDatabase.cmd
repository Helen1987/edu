echo off
setlocal 
%~d0
cd "%~dp0"

for /R "%~dp0..\..\..\" %%I in (App_Data) do if exist "%%I" del "%%I\*.ldf"
for /R "%~dp0..\..\..\" %%I in (App_Data) do if exist "%%I" copy /Y "%~dp0..\..\Assets\*.mdf" "%%I"
