using System;
using System.IO;
using System.Text;

namespace ssrt
{
    public class Reader
    {
        public static void Executar(string currentDirectory)
        {
            if (!String.IsNullOrEmpty(currentDirectory))
            {
                Console.WriteLine("Iniciando!");
                DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);
                if (directoryInfo.Exists)
                {
                    foreach (FileInfo arquivo in directoryInfo.GetFiles())
                    {
                        FileReader(arquivo);
                    }
                }
                Console.WriteLine("Finalizado!");
            }
        }

        private static void FileReader(FileInfo arquivo)
        {
            if (arquivo.Extension == ".ags" || arquivo.Extension == ".agm")
            {
                Console.WriteLine($"Arquivo Localizado:{arquivo.Name}");
                int lineCount = 0;
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(arquivo.FullName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("font {"))
                        {
                            if (!line.Contains("header") && !line.Contains("set"))
                            {
                                sb.AppendLine(line);
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (String.IsNullOrEmpty(line)|| String.IsNullOrWhiteSpace(line))
                                    {
                                        lineCount++;
                                    }
                                    else
                                    {
                                        sb.AppendLine(line);
                                        if (line.Contains("}"))
                                        {
                                            break;
                                        }

                                    }
                                }
                            }
                            else
                            {
                                sb.AppendLine(line);
                            }
                        }
                        else
                        {
                            sb.AppendLine(line);
                        }
                    }
                }
                if (lineCount > 0)
                {
                    Recorder.PersistirArquivo(arquivo, sb);
                }
                Console.WriteLine($"Espaços Removidos:{lineCount}");
            }
        }
    }
}