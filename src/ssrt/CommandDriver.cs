using System;

namespace ssrt
{
    public static class CommandDriver
    {
        private static string buildVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
        public static void CarregarDriversDeComando(string[] args)
        {
            var msgHelp = "Digite -h|--help para ajuda.";
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case ".":
                        Reader.Executar(Environment.CurrentDirectory);
                        break;
                    case "-d":
                        if (args.Length >= i++)
                        {
                            Reader.Executar(args[i++]);
                        }
                        break;
                    case "-h":
                        MenuAjuda(false);
                        break;
                    case "--help":
                        MenuAjuda(true);
                        break;
                    default:
                        Console.WriteLine(msgHelp);
                        break;
                }
            }
            if (args.Length == 0)
            {
                Console.WriteLine(msgHelp);
            }
        }

        private static void MenuAjuda(bool details)
        {
            Console.WriteLine($"Ferramentas de Linha de Comando para remoção de linhas vazias no script do Altitude {buildVersion}{Environment.NewLine}");
            Console.WriteLine($"Uso dotnet tool:");
            Console.WriteLine($"\tExecute:\tssrt -d <DIRECTORY>");
            Console.WriteLine("\tExemplo:\tssrt -d C:\\SCRIPTS");
            Console.WriteLine($"Diretorio Atual:\tssrt .");
            
            

        }
    }
}