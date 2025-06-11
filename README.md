### **Ambiente de Desenvolvimento com Docker**

Para executar e depurar o projeto localmente, utilizamos o Docker para simplificar a configuração e o gerenciamento de serviços externos, como o banco de dados. Isso garante um ambiente padronizado e evita a necessidade de instalar e configurar manualmente cada dependência.

#### **Pré-requisitos**

* **Docker Desktop:** Certifique-se de que ele esteja [instalado](https://www.docker.com/products/docker-desktop/) e em execução na sua máquina.

#### **Instruções para Iniciar o Ambiente**

1.  **Abra o Terminal:** Navegue até a pasta raiz do projeto onde o arquivo `docker-compose.yml` está localizado.

2.  **Execute o Comando:** Para iniciar todos os serviços definidos (incluindo o banco de dados), execute o seguinte comando:

    ```bash
    docker-compose up -d
    ```

    * **`up`**: Cria e inicia os contêineres.
    * **`-d`**: (detached mode) Executa os contêineres em segundo plano, liberando seu terminal.

Ao final do processo, o banco de dados e outros serviços estarão prontos para receber conexões da aplicação.