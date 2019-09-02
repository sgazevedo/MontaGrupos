using System;
using System.IO;

using System.Collections.Generic;

namespace MontaGrupos.Core
{
    public static class ExtensaoString
    {
        public static string ParseHome(this string path)
        {
            string home = (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
                ? Environment.GetEnvironmentVariable("HOME")
                : Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

            return path.Replace("~", home);
        }
    }

    public static class Arquivo
    {
        public static void EscreverArquivo(string nomeArquivo, string[] conteudo)
        {
            var path = nomeArquivo.ParseHome();

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Close();
                }
            }

            if (conteudo.Length > 0)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    foreach (var texto in conteudo)
                    {
                        sw.WriteLine(texto);
                    }
                }
            }
        }

        public static void ImportarArquivo(string nomeArquivo, out List<Time> listaTimes)
        {
            listaTimes = new List<Time>();

            var path = nomeArquivo.ParseHome();

            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            var nomeTime = sr.ReadLine();
                            if (nomeTime.Trim().Length > 0)
                            {
                                listaTimes.Add(new Time(nomeTime.Trim()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
