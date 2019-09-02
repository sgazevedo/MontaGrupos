using Xunit;
using FluentAssertions;
using System.IO;
using MontaGrupos.Core;

public class ArquivoTestes
{
    [Fact]
    public void TesteEscreverArquivo()
    {
        var nomeArquivo = @"~/eurocopa.txt";
        var selecoes = new string[] {
            "Alemanha",
            "Itália",
            "França",
            "Holanda",
            "Espanha",
            "Inglaterra",
            "Portugal",
            "Bélgica"
        };
        Arquivo.EscreverArquivo(nomeArquivo, selecoes);
        Assert.True(File.Exists(nomeArquivo.ParseHome()));
    }

    [Fact]
    public void TesteImportarArquivo()
    {
        var nomeArquivo = @"~/eurocopa.txt";
        Arquivo.ImportarArquivo(nomeArquivo, out var selecoes);
        Assert.True(selecoes.Count > 0);
    }

}