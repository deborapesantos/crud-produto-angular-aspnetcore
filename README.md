# Crud Produto


Crud Produto é uma aplicação de autenticação usuário por uma API externa e um cadastro de Produtos.

Esse projeto foi construído utilizando as ferramentas Asp.Net Core e Angular v8. 

Esse projeto utiliza:

- Sql Server 2014;
- C# .net Core; 
- Entity Framework;
- Html, Css e javascript;
- Angular 8;


## Entendendo algumas classes do projeto (Back-end)


Classe Result:
[➜ link](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Domain/Result.cs)
Essa classe tem um papel importante no controle de exceções e geração de logs em .txt para análises futuras.

Classe Utils:
[➜ link](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Domain/Utils.cs)
Essa classe encapsula métodos que são reutilizaveis dentro do sistema, ou seja, contêm métodos que é utilizado várias vezes no sistema.

BaseDBRepository:
[➜ link](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Data/Repository/BaseDBRepository.cs)
Nessa classe contém todos os métodos padrões de CRUD com as requisições que serão feitas para a tabela Produto utilizando-se o contexto.

API Produto Controller:
[➜ link](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Controllers/ProdutoController.cs)
Nessa classe contém todos os métodos de CRUD da tabela Produto, o front-end faz requisição para esses métodos.

