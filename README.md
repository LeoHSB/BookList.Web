# Guia de Início Rápido: Clonar e Executar o Projeto com Git e Visual Studio

Este guia irá ajudá-lo a configurar e executar o projeto **BookList.Web** na sua máquina local, utilizando o Visual Studio.

### Pré-requisitos
Certifique-se de que você tem o seguinte software instalado:

- **Git**: A ferramenta de controle de versão.
- **Visual Studio**: Recomenda-se a versão Visual Studio 2022 ou superior, com a carga de trabalho de **"Desenvolvimento ASP.NET e web"**.

### 1. Clonar o Repositório

1.  Abra o seu terminal (como Git Bash, Prompt de Comando ou PowerShell).
2.  Navegue até a pasta onde você deseja armazenar o projeto localmente. Por exemplo:
 
    ```bash
    cd C:\Users\SeuUsuario\source\repos
    ```
3.  Execute o comando `git clone` seguido da URL do repositório:
   
    ```bash
    git clone https://github.com/LeoHSB/BookList.Web.git
    ```

### 2. Abrir o Projeto no Visual Studio

1.  Abra o **Visual Studio**.
2.  Vá em **`File` (Arquivo) > `Open` (Abrir) > `Project/Solution` (Projeto/Solução)**.
3.  Navegue até a pasta que você clonou e selecione o arquivo de solução `Projeto.Web.sln`.

### 3. Restaurar Dependências (Pacotes NuGet)

O Visual Studio geralmente restaura os pacotes NuGet automaticamente ao abrir a solução. Caso não aconteça, você pode forçar a restauração:

1.  No **Gerenciador de Soluções**, clique com o botão direito na sua solução (o item no topo da árvore de arquivos).
2.  Selecione **`Restore NuGet Packages` (Restaurar Pacotes NuGet)**.

### 4. Criar arquivo de banco

É preciso criar um arquivo de banco para que o projeto funcione plenamente, para isso siga os seguintes passos:

1. Vá em Exibir > Server Explorar
2. No Gerenciador de servidores, em Conexões de Dados, clique em Adicionar conexão...
3. Escolha a fonte de dados Arquivo de Banco de Dados do Microsoft SQL Server (SqlClient)
4. Para o nome do arquivo, vá em procurar e escolha o diretorio até a pasta App_Data do Projeto.Web
5. Escolha o nome banco e clique em abrir
6. O Visual Studio provavelmente vai dizer que você não tem esse arquivo existente e vai pedir pra criar, você deve aceitar
7. Agora no Gereciador de servidores, clique com o botão direito no banco que você criou e escolha a opção Nova Consulta
8. Insira a seguinte formulação de banco:

    ```bash
    CREATE TABLE [dbo].[Usuario] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Nome] NVARCHAR (50) NOT NULL,
    [Email] NVARCHAR (254) NOT NULL,
    [Senha] NVARCHAR (40) NOT NULL,
    [DataCadastro] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
    );
    CREATE TABLE [dbo].[Biblioteca] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Nome] NVARCHAR (60) NOT NULL,
    [IdUsuario] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdUsuario]) REFERENCES [dbo].[Usuario] ([Id])
    );
    CREATE TABLE [dbo].[Livro] (
    [Id] INT IDENTITY (1, 1) NOT NULL,
    [Titulo] NVARCHAR (200) NOT NULL,
    [Autor] NVARCHAR (200) NOT NULL,
    [NumeroPaginas] INT NOT NULL,
    [DataPublicacao] DATETIME NOT NULL,
    [IdBiblioteca] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdBiblioteca]) REFERENCES [dbo].[Biblioteca] ([Id]),
    );
    ```
    
9. Rode a consulta
   
### 5. Limpar e recompilar

1. No gerenciador de Soluções clique com o botão direito no projeto e escolha a opção Limpar Solução
2. No gerenciador de Soluções clique com o botão direito no projeto e escolha a opção Recompilar solução



# Guia de Commit

### 1. Criar nova branch

Você deve criar uma branch de teste para fazer as alterações

1. No canto inferior direito do visual studio aparece a branch que você está utilizando, caso não tiver criado uma ainda, será a main.... clique nela
2. Clique em Nova Branch
3. Escolha o nome TesteSeuNome
4. Escolha Baseado em main
5. Deixe o checkbox de ramificação com check-out marcado e clique em criar

Com a nova Branch criada, você pode alterar entre branchs no canto inferior mencionado anteriormente e deve usar a teste para fazer quaisquer alterações anted de dar merge na main

### 2. Procedimento de Commit

Para fazer o procedimento de commit você deve seguir os seguintes passos:

```bash
Na branch utilizada (teste), vá em alterações do Git: “Insira uma mensagem” descrevendo mudanças  -> confirmar tudo;
Ainda no Teste, enviar por push;
Entrar na main, buscar alterações e efetuar pull, para atualizar branch main;
Na branch teste, mesclar branch main na teste;
Evetuar push na Teste com as alterações herdadas da main;
Na  branch main , mesclar a branch teste na main;
Na branch Main, enviar por push;
Testar na branch main;
```
