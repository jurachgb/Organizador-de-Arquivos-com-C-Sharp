using System.Collections.Concurrent;
using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace Helpers;
 
public class Helper
{   
    //Valida o input ate ser um valor inteiro e valido
    public static int CorretoInt(string valor,int a,int b)
    {
        int value=0;
        while(true)
        {
            if(int.TryParse(valor,out value)&& value>=a&& value<=b)
            {
                break;
            }
            else
            {
                System.Console.Write($"Opção errada, digite um numero valido entre {a} e {b}  :");
                valor=Console.ReadLine()??"";
            }
           
        }
        return value;
        
    }
   
    //Lista os Arquivos da pasta
    public static void ListarArquivos(string pasta)
    {
        foreach (string arquivo in Directory.GetFiles(pasta))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(arquivo);
        }
        Console.ResetColor();

    }



    //Mostra o tamanho de cada arquivo em bytes
    public static void MostrarTamanho(string pasta)
    {
        foreach (string arquivo in Directory.GetFiles(pasta))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            FileInfo info = new FileInfo(arquivo);
            Console.WriteLine($"{arquivo} - {info.Length} bytes");
        }
        Console.ResetColor();
    }




    //Busca arquivos dentro da pasta e subpastas
    public static void BuscarArquivos(string pasta, string nomeArquivo)
    {
        var busca = Directory.GetFiles(pasta, nomeArquivo, SearchOption.AllDirectories);
        foreach (string arquivo in busca)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Encomtramos o arquivo: {arquivo}");
        }
        if(busca.Length==0||busca==null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum arquivo encontrado.");
        }
        Console.ResetColor();
    }
    public static void DeletarArquivos(string pasta, string nomeArquivo)
    {
        var busca = Directory.GetFiles(pasta, nomeArquivo, SearchOption.AllDirectories);
        foreach (string arquivo in busca)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            File.Delete(arquivo);
            Console.WriteLine($"Arquivo deletado: {arquivo}");
        }
        if(busca.Length==0||busca==null)
        {
            Console.WriteLine("Nenhum arquivo encontrado para deletar.");
        }
        Console.ResetColor();
    }

    public static void RenomearArquivos(string pasta, string nomeArquivo, string novoNome)
    {
        var busca = Directory.GetFiles(pasta, nomeArquivo, SearchOption.AllDirectories);
        foreach (string arquivo in busca)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            string novoCaminho = Path.Combine(Path.GetDirectoryName(arquivo) ?? "", novoNome);
            File.Move(arquivo, novoCaminho);
            Console.WriteLine($"Arquivo renomeado: {arquivo} para {novoCaminho}");
        }
        if(busca.Length==0||busca==null)
        {
            Console.WriteLine("Nenhum arquivo encontrado para renomear.");
        }
        Console.ResetColor();
    }
    
}

