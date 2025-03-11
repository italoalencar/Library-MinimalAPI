# Biblioteca API - Simulação de Empréstimos

Este projeto é uma aplicação de simulação de biblioteca, desenvolvida com .NET 8 utilizando Minimal API. A aplicação permite gerenciar livros, autores, clientes e empréstimos. Além disso, implementa autenticação e autorização usando JWT e controle de acesso baseado em papéis (role-based access control).

**Minimal API:** É um estilo de desenvolvimento de APIs que simplifica a criação de endpoints HTTP ao eliminar a necessidade de controllers. Ele reduz a quantidade de código e configurações exigidas, tornando a implementação mais leve, direta e eficiente.
[Leia mais na documentação oficial da Microsoft.](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/overview?view=aspnetcore-8.0)

## Tecnologias Utilizadas

- **.NET 8**: Framework principal utilizado para o desenvolvimento da API.
- **ASP.NET Core**: Plataforma para criação de aplicações web modernas e APIs de alto desempenho.
- **Entity Framework Core (EF Core)**: ORM (Object-Relational Mapper) que facilita a comunicação da aplicação com o banco de dados SQL Server.
- **Identity**: Sistema de autenticação e autorização utilizado para gerenciar usuários, senhas e permissões.
- **JWT (JSON Web Tokens)**: Usado para autenticação e autorização de usuários, permitindo o acesso seguro a endpoints protegidos.
- **AutoMapper**: Biblioteca para mapeamento automático de objetos, reduzindo a necessidade de conversões manuais entre entidades e DTOs.
- **SQL Server**: Banco de dados relacional.
- **Swagger**: Ferramenta para documentação e teste interativo da API.

## Funcionalidades

Alguns dos recursos que a aplicação oferece:

### Endpoints Públicos:

- **GET /books**: Lista todos os livros disponíveis na biblioteca.
- **GET /authors**: Lista todos os autores registrados.
- **POST /users/create**: Registra um cliente.
- **POST /users/login**: Realiza o login do cliente.

### Endpoints Requerendo Autenticação:

- **POST /loans**: Realiza o empréstimo de um livro.
- **GET /loans**: Lista todos os empréstimos realizados pelo cliente autenticado.

### Endpoints Requerendo Role de Admin:

- **POST /books**: Cria um novo livro.
- **POST /authors**: Cria um novo autor.
- **GET /loans/users**: Lista todos os empréstimos realizados.

> Após rodar a aplicação, você pode acessar a documentação Swagger completa e interativa no seguinte endereço:

- `https://localhost:7105/swagger/index.html`
