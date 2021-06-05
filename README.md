# Crud Produto


Crud Produto é uma aplicação de autenticação usuário por uma API externa e um cadastro de Produtos.

Esse projeto foi construído utilizando as ferramentas:

- Sql Server 2014;
- C# .net Core; 
- Entity Framework;
- Html, Css e javascript;
- Angular 8;
- Visual Studio 2019

## Observações

- O Script do Banco de Dados pode ser encontrado na pasta Documentos, ou no [link](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Documentation/DeboraSantos_CreateScript_CrudProdutoDB.sql).


## Entendendo algumas classes do projeto (Back-end)


- [➜](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Domain/Result.cs)
Classe Result:

Essa classe tem um papel importante no controle de exceções e geração de logs em .txt para análises futuras.


- [➜](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Domain/Utils.cs)
Classe Utils:

Essa classe encapsula métodos que são reutilizaveis dentro do sistema, ou seja, contêm métodos que é utilizado várias vezes no sistema.


- [➜](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Data/Repository/BaseDBRepository.cs)
BaseDBRepository:

Nessa classe contém todos os métodos padrões de CRUD com as requisições que serão feitas para a tabela Produto utilizando-se o contexto.


- [➜](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Controllers/ProdutoController.cs)
API Produto Controller:

Nessa classe contém todos os métodos de CRUD da tabela Produto, o front-end faz requisição para esses métodos.


## Entendendo alguns componentes e serviços do projeto (Front-end)


- [➜](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/ClientApp/src/app/shared/file-image-upload/file-image-upload.component.ts)
FileImageUploadComponent:

Esse componente cria um campo de carregamento de imagem em um formulário, nesse componente já válida o arquivo e se caso for válido, carrega o arquivo para o sistema utilizando uma API.


- [➜](https://github.com/deborapesantos/crud-produto-angular-aspnetcore/blob/main/Solution_CrudProduto/Domain/Utils.cs)
BaseRequestService:

Esse Service encapsula métodos de requisição de API, por conter métodos genéricos, é possivel ser reutilizado em vários componentes.





