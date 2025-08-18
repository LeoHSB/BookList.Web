# Guia de Início Rápido: Clonar e Executar o Projeto com Git e Visual Studio

Este guia irá ajudá-lo a configurar e executar o projeto **BookList.Web** na sua máquina local, utilizando o Visual Studio.

### Pré-requisitos
Certifique-se de que você tem o seguinte software instalado:

- **Git**: A ferramenta de controle de versão.
- **Visual Studio**: Recomenda-se a versão Visual Studio 2022 ou superior, com a carga de trabalho de **"Desenvolvimento ASP.NET e web"**.
- **SQL Server**: Para o banco de dados (pode ser o SQL Server Express ou o LocalDB).

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
