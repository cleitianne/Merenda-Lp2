# Rodar o sistema no Debian 9

## Rodar o sistema usando Serve

```bash
Baixar os pacotes
$ npm install

Criar projeto para produção
$ npm run build

Instalar Serve
$ npm install -g serve

Rodar projeto em background
$ serve -l 8080 -s dist &

Parar projeto
$ killall node
```

## Rodar o sistema usando Docker

[Get Docker CE for Debian](https://docs.docker.com/install/linux/docker-ce/debian/)

```bash
Compilar a Imagem Docker Aplicação Vue(Execute o comando dentro da pasta 'Merenda-Lp2/Merenda-Front/CoreUI-Vue')
$ docker build -t vuejs-cookbook/dockerize-vuejs-app .

Executar a Aplicação Vue em um Contêiner Docker
$ docker run -it -p 8080:80 --rm --name dockerize-vuejs-app-1 vuejs-cookbook/dockerize-vuejs-app
```
