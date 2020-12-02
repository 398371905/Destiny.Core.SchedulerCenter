@echo off
dir
set HOSTNAME=% 10.1.40.207
set PORT=% 3306                 
set USERNAME=% root
set PASSWORD=% P@ssW0rd
set DBNAME=% TestShell
set TBNAME=% MyTest

echo Hello World!!
echo IP:%HOSTNAME% Port:%PORT% MysqlUser:%USERNAME% Password:%PASSWORD% MysqlName:%DBNAME%