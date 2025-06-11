### **Ambiente de Desenvolvimento com Docker**

Para executar e depurar o projeto localmente, utilizamos o Docker para simplificar a configuração e o gerenciamento de serviços externos, como o banco de dados. Isso garante um ambiente padronizado e evita a necessidade de instalar e configurar manualmente cada dependência.

#### **Pré-requisitos**

- **Docker Desktop:** Certifique-se de que ele esteja [instalado](https://www.docker.com/products/docker-desktop/) e em execução na sua máquina.

#### **Instruções para Iniciar o Ambiente**

1.  **Abra o Terminal:** Navegue até a pasta raiz do projeto onde o arquivo `docker-compose.yml` está localizado.

2.  **Execute o Comando:** Para iniciar todos os serviços definidos (incluindo o banco de dados), execute o seguinte comando:

    ```bash
    docker-compose up -d
    ```

    - **`up`**: Cria e inicia os contêineres.
    - **`-d`**: (detached mode) Executa os contêineres em segundo plano, liberando seu terminal.

Ao final do processo, o banco de dados e outros serviços estarão prontos para receber conexões da aplicação.

---

#### **Qualidade de Código**

- **Formatar o código da solução**

  Aplica as regras de formatação do `.editorconfig` em todos os arquivos do projeto. É recomendado executar este comando antes de cada `commit`.

  ```bash
  dotnet format Ambev.DeveloperEvaluation.sln
  ```

  #### **Entity Framework Core**

Para usar os comandos do EF Core, a ferramenta `dotnet-ef` precisa estar instalada: `dotnet tool install --global dotnet-ef`.

- **Criar uma nova Migration**

  Gera um novo arquivo de migration com base nas alterações feitas nas suas entidades do EF Core.

  ```bash
  dotnet ef migrations add NomeDaSuaMigration --project src/Ambev.DeveloperEvaluation.ORM --startup-project src/Ambev.DeveloperEvaluation.WebApi
  ```

- **Aplicar Migrations ao Banco de Dados**

  Aplica todas as migrations pendentes no banco de dados. Este comando é útil para atualizar o banco de dados local sem precisar rodar a aplicação.

  ```bash
  dotnet ef database update --startup-project src/Ambev.DeveloperEvaluation.WebApi
  ```
