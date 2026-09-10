# GYM — Sistema de Gestão de Clientes
Sistema web desenvolvido em ASP.NET Web Forms e C# para gestão de clientes e colaboradores de uma aplicação de saúde e fitness, com integração a uma base de dados SQL Server.

## Funcionalidades
- Registo de colaboradores
- Sistema de login para colaboradores
- Recuperação e alteração de palavra-passe
- Registo de clientes
- Recolha de dados pessoais e físicos
- Definição do objetivo do cliente
- Listagem de clientes
- Validação dos dados introduzidos
- Verificação de clientes duplicados
- Registo de dados através de comando SQL `INSERT`
- Registo de dados através de Stored Procedure
- Consulta de dados através de `GridView`

## Tecnologias
- C#
- ASP.NET Web Forms
- SQL Server
- ADO.NET
- HTML5
- CSS3
- JavaScript
- SCSS

## Principais conceitos aplicados
- ASP.NET Web Forms
- Code-behind em C#
- Programação orientada a eventos
- Formulários web
- Manipulação de dados
- SQL Server
- SqlConnection
- SqlCommand
- Stored Procedures
- Parâmetros SQL
- GridView
- SqlDataSource
- Session
- Validação de formulários
- Manipulação do DOM
- Gestão de sessões
- Criptografia de dados

## Configuração
Antes de executar o projeto, configure a connection string no arquivo `Web.config` com os dados do seu ambiente SQL Server.

## Estrutura do projeto

```text
Gym/
├── Properties/
├── css/
├── img/
├── js/
├── scss/
│
├── Forgot.aspx
├── Forgot.aspx.cs
├── Forgot.aspx.designer.cs
│
├── Login.aspx
├── Login.aspx.cs
├── Login.aspx.designer.cs
│
├── Registo.aspx
├── Registo.aspx.cs
├── Registo.aspx.designer.cs
│
├── Registo_form.aspx
├── Registo_form.aspx.cs
├── Registo_form.aspx.designer.cs
│
├── Gym.csproj
├── Web.Debug.config
├── Web.Release.config
├── Web.config
└── packages.config
