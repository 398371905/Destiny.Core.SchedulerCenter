#! /bin/bash
## author:zhangjunjie
## This is my first shell script

HOSTNAME="10.1.40.207"
PORT="3306"                  
USERNAME="root"
PASSWORD="P@ssW0rd"
DBNAME="TestShell"  
TBNAME="MyTest"  

echo 'Hello World'
echo "主机IP:${HOSTNAME} 端口:${PORT} Mysql库账号:${USERNAME} 密码:${PASSWORD} 数据库名称:${DBNAME}"