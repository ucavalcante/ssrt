using System;
using System.IO;
using System.Text;

namespace ssrt
{
    public class Recorder
    {
        public static void PersistirArquivo(FileInfo arquivo, StringBuilder sb)
        {
            try
            {
                FileInfo newFile = new FileInfo(arquivo.FullName);
                FileInfo bakFile = new FileInfo(arquivo.FullName + ".bak");
                if (bakFile.Exists)
                {
                    bakFile.Delete();
                }
                arquivo.MoveTo(bakFile.FullName);
                File.WriteAllText(newFile.FullName, sb.Remove(sb.Length - 2, 2).ToString(), Encoding.UTF8);
            }
            catch (System.Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
    }
}