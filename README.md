# Contact API 
Seja bem-vindo ao repositório Client API.

Aqui irei demonstrar, de forma simples e prática, uma Web API para gerenciar contatos.

## Tecnologias Implementadas
* AspNet.Core 2.1.4
* Visual Studio Code
* MacOS
* Fluent API
* Microsoft EntityFrameWorkCore
* Swashbuckle.AspNetCore.Swagger
* Git e GitHub

## Sobre o Código Fonte

O código não está completo.

Então, você pode acompanhar a evolução do projeto através dos Commits e do logbook que será criado.


## Logbook

### **#01 - Definição do escopo do projeto / Criação da estrutura inicial** ##

*Clonagem do repositório usando o terminal do Visual Studio Code e linha de comando git clone https://github.com/oneil-marcelo/contact-api.git*

*Criação das pastas Controllers, Data, Models, Repositories. A medida que for avançando, o objetivo de cada pasta será detalhado.*

### **#02 - Criação das entidades (Modelos de dados)** ###

*A pasta Models, criada na estrutura inicial do projeto, será usada para salvar as entidades.*

*As entidades serão utilizadas como objetos de representação do banco de dados. Elas serão utilizadas tanto na criação do banco, como modelo para entrada e saída de dados da API.*

### **#03 - Fluent Map / Criação do contexto para geração do banco de dados** ###
*Na pasta Data, foi criada a classe AppDataContext. Ela é responsável por criar o contexto para geração do banco e manipulação dos dados*

*Também foi criada uma pasta Maps, onde estão as classes responsáveis por mapear as propriedades das entidades e com isso criar as tabelas no banco de dados*

*Para isso foi instalado o pacote do Entity framework Core 2.1.1 => dotnet add package Microsoft.EntityFrameWork --version 2.1.1*

