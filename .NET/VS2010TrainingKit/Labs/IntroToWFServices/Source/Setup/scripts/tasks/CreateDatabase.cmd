@Echo Off
Echo This script will create the HRApplicationData Database
sqlcmd -S .\SQLExpress -i %~dp0HRApplicationData.sql
