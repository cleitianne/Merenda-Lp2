# Rodar o sistema no Debian 9

## Instalar o .NET Core

[.NET Core SDK on Linux Debian 9 - x64](https://dotnet.microsoft.com/download/linux-package-manager/debian9/sdk-current)

## Instalar o Docker

[Get Docker CE for Debian](https://docs.docker.com/install/linux/docker-ce/debian/)

## Instalar o SQL Server com Docker

[Sql Server 2017](https://docs.microsoft.com/pt-br/sql/linux/quickstart-install-connect-docker?view=sql-server-2017&pivots=cs1-bash)

```bash
Criar Contêiner
$ sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=sqlServer1' -p 1433:1433 --name sql1 -d mcr.microsoft.com/mssql/server:2017-latest

Trocar Password Contêiner
$ sudo docker exec -it sql1 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P '<Sqlserver1>' -Q 'ALTER LOGIN SA WITH PASSWORD="sqlServer1"'

Exibir Contêiner Docker
$ sudo docker ps -a

Entrar no Contêiner sql
$ sudo docker exec -it sql1 "bash"

Entrar no sqlcmd
$ /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'sqlServer1'

Parar Contêiner
$ sudo docker stop sql1

Iniciar Contêiner
$ sudo docker start sql1

Excluir Contêiner
$ sudo docker stop sql1
$ sudo docker rm sql1
```

## Rodar em sistema em background

```bash
Rodar projeto
$ dotnet run &

Parar projeto
$ killall dotnet
```
