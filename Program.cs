using System;
using System.Diagnostics;
using System.IO;
using Helpers;

class FileTool
{
    static void Main()
    {
        string pasta = @"C:\Users";
        bool fim = false;
        while (!fim)
        {
            Console.WriteLine("Bem-vindo ao Orgranizador de Arquivos!");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("Editar pasta caminho\t\t Pressione 1");
            Console.WriteLine("Listar arquivos\t\t\t Pressione 2");
            Console.WriteLine("Mostrar tamanho dos arquivos\t Pressione 3");
            Console.WriteLine("Buscar arquivos\t\t\t Pressione 4");
            Console.WriteLine("Criar arquivos\t\t\t Pressione 5");
            Console.WriteLine("Deletar arquivos\t\t Pressione 6");
            Console.WriteLine("Renomear arquivos\t\t Pressione 7");
            Console.WriteLine("Converter arquivos\t\t Pressione 8");
            Console.WriteLine("Sair\t\t\t\t Pressione 9");
            int resposta=Helper.CorretoInt(Console.ReadLine()??"",1,9);
            switch (resposta)
            {
                case 1:

                    Console.WriteLine("Digite o caminho da pasta (exemplo: C:\\Users\\Public\\Documents):");
                    pasta = Console.ReadLine()??"";
                    break;
                case 2:
                    Helper.ListarArquivos(pasta);
                    break;
                case 3:
                    Helper.MostrarTamanho(pasta);
                    break;
                case 4:
                    Console.WriteLine("Digite o nome do arquivo que deseja buscar:");
                    string nomeArquivo = Console.ReadLine()??"";
                    Helper.BuscarArquivos(pasta,nomeArquivo);
                
                    break;
                case 5:
                    Console.WriteLine("Digite o nome do arquivo que deseja criar:");
                    string nomeArquivoCriar = Console.ReadLine()??"";
                    Console.WriteLine("Digite o conteúdo do arquivo (opcional):");
                    string conteudoArquivo = Console.ReadLine()??"";
                    Helper.CriarArquivos(pasta,nomeArquivoCriar,conteudoArquivo);
                    break;
                case 6:
                    Console.WriteLine("Digite o nome do arquivo que deseja deletar:");
                    string nomeArquivoDeletar = Console.ReadLine()??"";
                    Helper.DeletarArquivos(pasta,nomeArquivoDeletar);
                    break;
                
                case 7:
                    Console.WriteLine("Digite o nome do arquivo que deseja renomear:");
                    string nomeArquivoRenomear = Console.ReadLine()??"";
                    Console.WriteLine("Digite o novo nome do arquivo:");
                    string novoNomeArquivo = Console.ReadLine()??"";
                    Helper.RenomearArquivos(pasta,nomeArquivoRenomear,novoNomeArquivo);
                    break;
                case 8:
                    Console.WriteLine("Digite o nome do arquivo que deseja converter:");
                    string ArquivoInicial=Console.ReadLine()??"";
                    Console.WriteLine("Digite o novo formato do arquivo:");
                    string ArquivoFinal=Console.ReadLine()??"";
                    Helper.Conversor(pasta,ArquivoInicial,ArquivoFinal);
                    break;
                case 9:
                    fim= true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    fim = true;
                    break;
            }
        }
    }
  
}