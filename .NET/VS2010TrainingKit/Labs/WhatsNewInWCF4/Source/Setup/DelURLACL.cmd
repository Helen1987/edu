@Echo Off
@Echo Deletes permissions for URL reservation
@Echo Parameter 1 "%1" == port
@Echo Parameter 2 "%2" == URL
pause
netsh http delete urlacl url=http://+:%1/%2