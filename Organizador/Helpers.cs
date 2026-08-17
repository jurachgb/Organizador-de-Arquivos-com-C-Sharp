namespace Helpers;

public class Helper
{
    // Valida o input ate ser um valor inteiro e valido
    public static int CorretoInt(string valor, int a, int b)
    {
        while (true)
        {
            if (int.TryParse(valor, out int value) && value >= a && value <= b)
            {
                return value;
            }

            Console.Write($"Opcao errada, digite um numero valido entre {a} e {b}: ");
            valor = Console.ReadLine() ?? "";
        }
    }

    private static bool PastaValida(string pasta)
    {
        if (string.IsNullOrWhiteSpace(pasta) || !Directory.Exists(pasta))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro: a pasta '{pasta}' nao existe.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        return true;
    }

    // Lista os arquivos da pasta
    public static void ListarArquivos(string pasta)
    {
        if (!PastaValida(pasta))
        {
            return;
        }

        try
        {
            string[] arquivos = Directory.GetFiles(pasta);
            if (arquivos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum arquivo encontrado nessa pasta.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string arquivo in arquivos)
            {
                Console.WriteLine(arquivo);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao listar arquivos: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Mostra o tamanho de cada arquivo em bytes
    public static void MostrarTamanho(string pasta)
    {
        if (!PastaValida(pasta))
        {
            return;
        }

        try
        {
            string[] arquivos = Directory.GetFiles(pasta);
            if (arquivos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nenhum arquivo encontrado nessa pasta.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string arquivo in arquivos)
            {
                FileInfo info = new FileInfo(arquivo);
                Console.WriteLine($"{arquivo} - {info.Length} bytes");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao mostrar tamanho dos arquivos: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Busca arquivos dentro da pasta
    public static void BuscarArquivos(string pasta, string nomeArquivo)
    {
        if (!PastaValida(pasta))
        {
            return;
        }

        try
        {
            string[] busca = Directory.GetFiles(pasta, nomeArquivo, SearchOption.AllDirectories);
            if (busca.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum arquivo encontrado.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string arquivo in busca)
            {
                Console.WriteLine($"Encontramos o arquivo: {arquivo}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao buscar arquivos: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Cria um arquivo na pasta
    public static void CriarArquivos(string pasta, string nomeArquivo, string conteudo = "")
    {
        if (!PastaValida(pasta))
        {
            return;
        }

        try
        {
            string caminhoCompleto = Path.Combine(pasta, nomeArquivo);
            if (File.Exists(caminhoCompleto))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: o arquivo ja existe.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            File.Create(caminhoCompleto).Close();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Arquivo criado: {caminhoCompleto}");
            if (!string.IsNullOrWhiteSpace(conteudo))
            {
                File.WriteAllText(caminhoCompleto, conteudo);
                Console.WriteLine($"Conteúdo adicionado ao arquivo: {caminhoCompleto}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao criar arquivo: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Deleta o arquivo
    public static void DeletarArquivos(string pasta, string nomeArquivo)
    {
        if (!PastaValida(pasta))
        {
            return;
        }

        try
        {
            string[] busca = Directory.GetFiles(pasta, nomeArquivo, SearchOption.AllDirectories);
            if (busca.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum arquivo encontrado para deletar.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string arquivo in busca)
            {
                File.Delete(arquivo);
                Console.WriteLine($"Arquivo deletado: {arquivo}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao deletar arquivo: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Renomeia o arquivo
    public static void RenomearArquivos(string pasta, string nomeArquivo, string novoNome)
    {
        if (!PastaValida(pasta))
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(novoNome))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Novo nome invalido.");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        try
        {
            string[] busca = Directory.GetFiles(pasta, nomeArquivo, SearchOption.AllDirectories);
            if (busca.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum arquivo encontrado para renomear.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string arquivo in busca)
            {
                string extensao = Path.GetExtension(arquivo);
                string nomeFinal = Path.GetExtension(novoNome) == "" ? novoNome + extensao : novoNome;
                string novoCaminho = Path.Combine(Path.GetDirectoryName(arquivo) ?? "", nomeFinal);
                File.Move(arquivo, novoCaminho);
                Console.WriteLine($"Arquivo renomeado: {arquivo} para {novoCaminho}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao renomear arquivo: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    // Converte o arquivo para outro formato
    public static void Conversor(string pasta, string nomeArquivo, string novoFormato)
    {
        if (!PastaValida(pasta))
        {
            return;
        }

        try
        {
            string[] busca = Directory.GetFiles(pasta, nomeArquivo, SearchOption.AllDirectories);
            if (busca.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum arquivo encontrado para converter.");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string arquivo in busca)
            {
                string novo = Path.ChangeExtension(arquivo, novoFormato);
                File.Move(arquivo, novo);
                Console.WriteLine($"Arquivo convertido: {arquivo} para {novo}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao converter arquivo: {ex.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

