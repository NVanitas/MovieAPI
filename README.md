# MovieApi

**MovieApi** é uma API RESTful desenvolvida com **.NET 8** e **Entity Framework Core**. Esta API permite realizar operações CRUD (Create, Read, Update, Delete) em um banco de dados SQL Server para gerenciar um catálogo de filmes.

## Descrição

A MovieApi fornece os seguintes endpoints:

- **GET /api/Movies**: Recupera a lista de todos os filmes.
- **GET /api/Movies/{id}**: Recupera um filme específico por ID.
- **POST /api/Movies**: Cria um novo filme no banco de dados.
- **PUT /api/Movies/{id}**: Atualiza um filme existente.
- **DELETE /api/Movies/{id}**: Exclui um filme do banco de dados.

## Tecnologias

- **.NET 8**
- **Entity Framework Core**
- **SQL Server** para persistência de dados

## Funcionalidades

- Permite realizar operações CRUD em filmes.
- Utiliza o **Entity Framework Core** para se conectar ao banco de dados e executar operações.
- Oferece segurança de dados com **SQL Server**.

## Como Rodar o Projeto

### Requisitos

- **.NET 8 SDK**: [Download .NET 8 SDK](https://dotnet.microsoft.com/download/dotnet)
- **SQL Server**: Pode ser instalado localmente ou utilizar o **SQL Server Express**.

### Passo a Passo

1. **Clone o repositório**:
    ```bash
    git clone https://github.com/seu-usuario/MovieApi.git
    cd MovieApi
    ```

2. **Configure a string de conexão**:
    No arquivo `appsettings.json`, configure a string de conexão com o seu banco de dados SQL Server:
    ```json
    "ConnectionStrings": {
      "MovieContext": "Server=seu-servidor;Database=MovieContext;Trusted_Connection=True;TrustServerCertificate=True"
    }
    ```

3. **Crie o banco de dados**:
    Execute o comando de migração para criar o banco de dados:
    ```bash
    dotnet ef database update
    ```

4. **Rode o projeto**:
    Após as configurações, rode a API localmente com o comando:
    ```bash
    dotnet run
    ```

    A API estará disponível em `https://localhost:5001`.

## Endpoints

- **GET /api/Movies**: Recupera todos os filmes.
    - Resposta: Lista de filmes em formato JSON.
  
- **GET /api/Movies/{id}**: Recupera um filme específico.
    - Parâmetros: `id` - ID do filme.
    - Resposta: Detalhes do filme em formato JSON.

- **POST /api/Movies**: Cria um novo filme.
    - Corpo: Objeto JSON com os dados do filme (Título, Gênero, Data de lançamento).
    - Resposta: O filme recém-criado com o ID gerado.

- **PUT /api/Movies/{id}**: Atualiza um filme existente.
    - Parâmetros: `id` - ID do filme.
    - Corpo: Objeto JSON com os dados atualizados do filme.
    - Resposta: Status 204 (Sem conteúdo) se bem-sucedido.

- **DELETE /api/Movies/{id}**: Exclui um filme.
    - Parâmetros: `id` - ID do filme.
    - Resposta: Status 204 (Sem conteúdo) se bem-sucedido.

## Contribuição

Se você deseja contribuir para o projeto:

1. Fork o repositório.
2. Crie uma branch com sua feature: `git checkout -b minha-feature`.
3. Commit suas alterações: `git commit -am 'Adiciona nova feature'`.
4. Push para a branch: `git push origin minha-feature`.
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a **MIT License**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Contato

Caso tenha dúvidas ou queira entrar em contato, sinta-se à vontade para abrir um **Issue** ou mandar uma mensagem diretamente!

---

Esse README está agora atualizado para refletir que o projeto foi feito com **.NET 8**.
