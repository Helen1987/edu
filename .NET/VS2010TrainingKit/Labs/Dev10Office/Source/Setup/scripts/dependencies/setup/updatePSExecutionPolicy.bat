IF EXIST %WINDIR%\SysWow64 (
call %WINDIR%\SysWow64\windowspowershell\v1.0\powershell.exe -Command Set-ExecutionPolicy unrestricted
)

IF EXIST %WINDIR%\system32\windowspowershell\v1.0 (
call %WINDIR%\system32\windowspowershell\v1.0\powershell.exe -Command Set-ExecutionPolicy unrestricted
)