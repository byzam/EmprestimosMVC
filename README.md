# Sobre o projeto

EmprestimosMVC é uma Aplicação Web desenvolvida em ASP.NET MVC, focada em realizar o cadastro de livros pelo usuário em uma CRUD, além do consumo de uma API aberta do Google, e a exportação dos dados cadastrados para o Excel.

## Tecnologias utilizadas
- C#
- HTML / CSS / JavaScript
- Bootstrap
- **Framework:** ASP.NET MVC
- **IDE:** Visual Studio
- **Banco de Dados:** SQL Server

# Integração de Serviços
## API Books
Foi feita uma integração com a API Books do Google (https://developers.google.com/books/docs/overview?hl=pt-br), utilizando a solicitação GET, onde o usuário envia um termo, que seria o nome de um livro ou de um autor, e é retornado um arquivo JSON, em que é manipulado os dados para uma lista com todos resultados da busca pelo termo, listando o nome do livro e do autor, em que o usuário pode selecionar o livro, para realizar o cadastro do mesmo com mais facilidade.

## Exportação para o Excel
Ao fazer o cadastro dos livros, o usuário pode fazer o download da tabela em XLS, para poder ser visualizada no Excel.

# Projeto
O projeto é feito na arquitetura MVC, que é a sigla para Models Views e Controllers, que são as pastas principais que se comunicam entre si, para o funcionamento da aplicação.
## Controllers
Pasta onde ficam os controladores, que gerenciam o fluxo e o manupulação dos dados, tanto dos dados da tabela dos Emprestimos, quanto os serviços da API e da Exportação.
## Models
Models é a pasta onde é definido os objetos que carregam os dados necessários para o projeto, a EmprestimosModel.cs define os tipos e os dados dos emprestimos, e a APIBooksModel.cs define o tipo dos dados recebidos pela API que serão manupulados.
## Views
Onde ficam os arquivos .cshtml que serão as telas na aplicação, como a Home, telas para a Visualização, Cadastro, Edição e Exclusão dos dados. Também é aqui onde foi criado os formulários, que são resgatados da Models e enviados para as controllers, alék também dos scripts em JS.
## Outros
- **Data:** Onde é feita a conexão com o servidor do Banco de Dados do SQL Server.
- **Migrations:** Criada automaticamente pelo Visual Studio, onde foi feita a criação automática do Banco de Dados e das tabelas a partir da Model EmprestimosModel.cs.
- **Properties:** Configurações de inicalização, criada automaticamente.
- **wwwroot:** Onde fica os arquivos css pro projeto, os scripts, imagens, e as bibliotecas. Foi adicionada uma predefinição de estilização do Bootstrap.
- **Program.cs** Classe main em que inicia o projeto, em que contém as confugurações básicas nessárias para a aplicação web, além da configuração do banco, e dos serviços.
- **EmprestimosMVC.csproj e appsettings.Development.json** Dados de configuração do ambiente, criado automaticamente pelo Visual Studio.

## Layout
![Layout 1](https://raw.githubusercontent.com/vitorluisz/EmprestimosMVC/source/EmprestimosMVC/wwwroot/img/Screenshot_64.png)
![Layout 2](https://raw.githubusercontent.com/vitorluisz/EmprestimosMVC/source/EmprestimosMVC/wwwroot/img/Screenshot_65.png)
![Layout 3](https://raw.githubusercontent.com/vitorluisz/EmprestimosMVC/source/EmprestimosMVC/wwwroot/img/Screenshot_66.png)
![Layout 4](https://raw.githubusercontent.com/vitorluisz/EmprestimosMVC/source/EmprestimosMVC/wwwroot/img/Screenshot_67.png)
![Layout 5](https://raw.githubusercontent.com/vitorluisz/EmprestimosMVC/source/EmprestimosMVC/wwwroot/img/Screenshot_68.png)

# Como executar o projeto
```bash
# No terminal ou prompt de comando, clone o repositório
git clone https://https://github.com/vitorluisz/EmprestimosMVC
```
Obs: não contém o arquivo appsettings.json, será necessário copiar ele de outro projeto ASP.NET MVC, e apontar para o seu servidor local.

# Autor

Vitor Luis Zampronha

https://www.linkedin.com/in/vitor-zampronha
