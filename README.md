# Organizador de Arquivos com C#

Um projeto simples em C# para explorar operações com arquivos e pastas no sistema (listar, obter tamanho, buscar, deletar e renomear arquivos). É uma aplicação de console educativa destinada a demonstrar o uso das APIs de System.IO.

## Funcionalidades

- Editar o caminho da pasta a ser manipulada
- Listar arquivos de uma pasta
- Mostrar o tamanho (bytes) de cada arquivo
- Buscar arquivos por nome (inclui subpastas)
- Criar arquivos
- Deletar arquivos encontrados
- Renomear arquivos encontrados
- Converter dormato de arquivos

> Aviso: As operações de deletar e renomear são definitivas no sistema de ficheiros. Use com cuidado e execute testes em pastas de exemplo antes de rodar em diretórios importantes.

## Requisitos

- .NET SDK (versão compatível com C# 10 / .NET 6 ou superior) instalado

Você pode verificar a versão do SDK com:

```bash
dotnet --version
```

## Como executar

1. Clone este repositório:

```bash
git clone https://github.com/jurachgb/Organizador-de-Arquivos-com-C-Sharp.git
cd Organizador-de-Arquivos-com-C-Sharp
```

2. Compile e execute (se houver um arquivo .csproj na raiz, `dotnet run` basta):

```bash
dotnet run
```

Ou, se preferir, use `dotnet build` e execute o binário gerado:

```bash
dotnet build
# depois execute o executável em bin/Debug/netX.Y/...
```

## Uso

Ao executar, você verá um menu com opções numeradas (1 a 7). Exemplos de uso:

- Pressione 1 para alterar a pasta alvo (por exemplo: `C:\Users\Public\Documents`).
- Pressione 2 para listar arquivos na pasta atual.
- Pressione 3 para mostrar o tamanho dos arquivos.
- Pressione 4 para buscar arquivos (informe o nome ou um padrão exato).
- Pressione 5 para criar arquivos (Opcionalmente adicione o conteudo do arquivo)
- Pressione 6 para deletar arquivos (confirme o nome exatamente como busca).
- Pressione 7 para renomear arquivos encontrados (informe o novo nome).
- Pressione 8 para converter arquivos (informe o nome e novo formato).
- Pressione 9 para sair.

Observação: Atualmente, a busca usa o parâmetro `nomeArquivo` diretamente com Directory.GetFiles — isso significa que é possível usar curingas (por exemplo: `*.txt`) para corresponder a vários arquivos.

## Estrutura do projeto

- Program.cs — aplicação de console com menu de interação
- Organizador/Helpers.cs — funções utilitárias para manipulação de arquivos


## Contribuições

Pull requests são bem-vindos. Para contribuições:

1. Fork o repositório
2. Crie uma branch com a sua feature/fix: `git checkout -b minha-feature`
3. Faça commits claros e descritivos
4. Abra um Pull Request descrevendo a mudança
