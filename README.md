# Projeto EstagioJá

Bem-vindo ao repositório do projeto EstagioJá! </br>
Este é um projeto web desenvolvido utilizando diversas tecnologias modernas. </br>
Professor orientador: **Jaime Wojciechowski**</br>
Abaixo seguem as instruções de instalação, assim como o nome dos autores.

## Tecnologias Utilizadas

### Front-end:
<img src="https://angular.io/assets/images/logos/angular/angular.svg" alt="angular" width="40" height="40"/><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/materialui/materialui-plain.svg" alt="material" width="40" height="40"/> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/html5/html5-original-wordmark.svg" alt="html5" width="40" height="40"/><img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/css3/css3-original-wordmark.svg" alt="css3" width="40" height="40"/><img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/typescript/typescript-original.svg" alt="typescript" width="40" height="40"/><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/nodejs/nodejs-original.svg" alt="nodejs" width="40" height="40"/>

### Back-end:
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> 

### Mobile:
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dart/dart-original.svg" alt="dart" width="40" height="40"/> <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/flutter/flutter-original.svg" alt="flutter" width="40" height="40"/>
          

### Database:
<img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/postgresql/postgresql-original.svg" alt="postgresql" width="40" height="40"/>

### Virtualization and Deploy:
<img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/docker/docker-original-wordmark.svg" alt="docker" width="40" height="40"/><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/heroku/heroku-original.svg" alt="heroku" width="40" height="40"/><img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/git/git-original.svg" alt="git" width="40" height="40"/>

## Desenvolvedores
- [James Rovel Barbosa](https://github.com/Diagnoster)
- [Lucas Frison Gonçalves](https://github.com/lucasfrison)

## Acesso ao ambiente cloud (não recomendado)
- É possível acessar o website em ambiente de nuvem, porém não é recomendado devido a possíveis
  problemas de disponibilidade ou atraso no banco de dados, que é hospedado em uma instânica ec2
  da AWS localizada em um servidor nos EUA.
- Website: [EstágioJá](https://estagioja-070ef3605940.herokuapp.com/)
  Para acessar o site, é necessário criar uma conta ([Criar conta](https://estagioja-070ef3605940.herokuapp.com/cadastrar))
  de estudante ou empresa.

## Acesso via Docker (recomendado)
**IMPORTANTE: NÃO CLONAR O REPOSITÓRIO EM DIRETÓRIOS DO ONE DRIVE, DROPBOX OU SEMELHANTES**
- Essa é a melhor forma de rodar as aplicações localmente, seguem instruções abaixo:

1. **Instalar o Docker**
- Instale o Docker Desktop (recomendado): https://www.docker.com/products/docker-desktop/
- Ou o docker engine: https://docs.docker.com/engine/install/
- Se optar pelo Engine, é necessário instalar o docker-compose: https://docs.docker.com/compose/install/linux/#install-using-the-repository
- Após consluída a instalação, inicie o docker desktop ou, se não estiver utilizando a versão desktop, utilize um dos comandos abaixo:
  ```bash
  sudo service docker start
  sudo systemctl start docker

2. **Instalar NPM e Node.js**
- Siga os passos em https://docs.npmjs.com/downloading-and-installing-node-js-and-npm de acordo com seu sistema operacional
  para instalar o Runtime do nodejs (versão mínima v18.17.1) e o npm (versão mínima 9.6.7)

3. **Instalar o Angular via terminal**
    ```bash
    npm install -g @angular/cli

- Após concluído, fechar o terminal e reabrir para recarregar as variáveis de ambiente.

4. **Executar script de inicialização**
**(Os scripts de inicialização estão na raíz do projeto)**

- Linux/Mac: Executar o script:
  ```bash
  ./start-unix.sh
  
- Se necessário, atribuir permissão de execução:
  ```bash
  chmod +x start-unix.sh
  ```
- Windows: Executar o script: 
   ```bash
  .\start-windows.bat

5. **Testar os conteineres**
- WebSite estará disponível e pronto para cadastros em: http://localhost:4200/
- API estará disponível em: http://localhost:8080/ (ou http://localhost:8080/index.html para exibir o status "up")

  
6. **Banco de dados** 
- O banco de dados estará disponível em: http://localhost:5433/ (pode ser visualizado via [dbeaver](https://dbeaver.io/download/), [pgadmin](https://www.pgadmin.org/download/) ou similares. usuario: estagioja; senha: estagioja; banco: estagioja; schema: public)
- Por padrão não haverá dados no banco, quando todos os conteineres estiverem rodando, execute o script contido no arquivo [db/start-db.sql](db/start-db.sql) em uma ferramenta como as citadas acima.

7. **Rodando o app mobile**
- O APK pode ser baixado da release [1.0](https://github.com/lucasfrison/EstagioJaDocker/releases/tag/1.0) desse repositório, através de seu smartphone Android.
- O app utiliza os serviços do postgres em nuvem, sendo necessário criar uma conta de estudante no [Website EstágioJá](https://estagioja-070ef3605940.herokuapp.com/cadastrar)
- Após a criação o login pode ser feito no app utilizando as credênciais cadastradas.
