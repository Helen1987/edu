@Echo Off
@Echo Grant permissions for URL reservation
@Echo Parameter 1 "%1" == port
@Echo Parameter 2 "%2" == URL
pause
netsh http add urlacl url=http://+:%1/%2 user=%USERDOMAIN%\%USERNAME%