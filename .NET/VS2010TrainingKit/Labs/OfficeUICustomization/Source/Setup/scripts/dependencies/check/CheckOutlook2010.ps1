$info = New-PSDrive -Name HKCR -PSProvider Registry -Root HKEY_CLASSES_ROOT -Scope "Script"

Test-Path "HKCR:Outlook.Application.14\"