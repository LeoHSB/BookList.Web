Guia para Clonar e Executar o Projeto com Git usando o Visual Studio

----------Pré-requisitos----------
Certifique-se de que você tem o seguinte instalado na sua máquina:

Git: A ferramenta de controle de versão.
Visual Studio: Recomenda-se a versão Visual Studio 2022 ou superior, com a carga de trabalho de "Desenvolvimento ASP.NET e web".

1. Clonar o Repositório
Abra o seu terminal (como Git Bash, Prompt de Comando ou PowerShell).
Navegue até a pasta onde você deseja armazenar o projeto localmente. Por exemplo: cd C:\Users\SeuUsuario\source\repos
Execute o comando git clone seguido da URL do repositório: git clone [https://github.com/SeuUsuario/NomeDoSeuRepositorio.git](https://github.com/LeoHSB/BookList.Web.git)

2. Abrir o Projeto no Visual Studio
Abra o Visual Studio.
Vá em File (Arquivo) > Open (Abrir) > Project/Solution (Projeto/Solução).
Navegue até a pasta que você clonou e selecione o arquivo de solução Projeto.Web.sln

4. Restaurar Dependências (Pacotes NuGet)
O Visual Studio geralmente faz isso automaticamente ao abrir a solução, mas caso não aconteça, você pode forçar a restauração.
No Gerenciador de Soluções, clique com o botão direito na solução (o item no topo).
Selecione Restore NuGet Packages (Restaurar Pacotes NuGet)
