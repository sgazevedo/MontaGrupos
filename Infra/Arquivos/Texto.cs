using System;
using System.IO;
using System.Collections.Generic;

namespace MontaGrupos.Infra.Arquivos
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

    public static class Texto
    {
        public static IList<string> Obter(string nomeArquivo)
        {
            if (!File.Exists(nomeArquivo))
                return default;

            var conteudo = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(nomeArquivo))
                {
                    while (sr.Peek() >= 0)
                    {
                        var nome = sr.ReadLine();
                        if (!string.IsNullOrEmpty(nome.Trim()))
                        {
                            conteudo.Add(nome.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return conteudo;
        }

        public static void Salvar(string nomeArquivo, string[] conteudo)
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
    }
}