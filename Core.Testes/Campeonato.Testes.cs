using Xunit;
using FluentAssertions;
using System.IO;
using MontaGrupos.Core;

public class TestesCampeonato
{
    [Fact]
    public void TesteMontarPotes()
    {
        var campeonato = new Campeonato("Euro_RoundOne", 4, 2, 2, 4);
        campeonato.MontarPotes(@"~/eurocopa.txt");
        Assert.True(campeonato.Potes[1].ListaTimes.Count > 0);
    }

    [Fact]
    public void TesteMontarGrupos()
    {
        var campeonato = new Campeonato("Euro_RoundOne", 4, 2, 2, 4);
        campeonato.MontarPotes(@"~/eurocopa.txt");
        campeonato.MontarGrupos();
        Assert.True(campeonato.Grupos[1].ListaTimes.Count == 4);
    }

    [Fact]
    public void TesteSalvarGrupos()
    {
        var nomeCampeonato = "Euro_RoundOne";
        var campeonato = new Campeonato(nomeCampeonato, 4, 2, 2, 4);
        campeonato.MontarPotes(@"~/eurocopa.txt");
        campeonato.MontarGrupos();
        campeonato.SalvarGrupos();

        var nomeArquivo = @"~/" + nomeCampeonato + ".txt";
        Assert.True(File.Exists(nomeArquivo.ParseHome()));
    }

}