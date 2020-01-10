using System;
using System.IO;
using MontaGrupos.Core;
using Microsoft.Extensions.Configuration;

namespace MontaGrupos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            var configuracaoRavenDB = new ConfiguracaoRavenDB();
            configuration.Bind("ConfiguracaoRavenDB", configuracaoRavenDB);

            var conexao = new ConexaoRavenDB(configuracaoRavenDB);
            // conexao.Conectar();

            var campeonatos = new Campeonatos();
            configuration.Bind("Campeonatos", campeonatos);

            MontarCampeonato(conexao, campeonatos.CampeonatosSelecoes.CopaConcacafEliminatorias);
            // var campeonato = new Campeonato(conexao, campeonatos.CampeonatosSelecoes.CopaConcacafEliminatorias);
            // campeonato.MontarPotes();
            // Console.WriteLine(campeonato.ListarPotes());
            // campeonato.MontarGrupos();
            // Console.WriteLine(campeonato.ListarGrupos());
            // campeonato.SalvarGrupos();


            // //CargasSelecoes.CarregarSelecoes(conexao);
            // var selecao = Repositorio.ObterSelecao(conexao, "Argentina");
            // Console.WriteLine($"{selecao.Id} {selecao.Nome} {selecao.Confederacao} {selecao.Pontuacao}");

            // conexao.Desconectar();
            Console.ReadKey();
        }

        private static void MontarCampeonato(ConexaoRavenDB conexao, ParametrosCampeonato parametrosCampeonato)
        {
            var campeonato = new Campeonato(conexao, parametrosCampeonato);
            campeonato.MontarPotes();
            Console.WriteLine(campeonato.ListarPotes());
            campeonato.MontarGrupos();
            Console.WriteLine(campeonato.ListarGrupos());
            campeonato.SalvarGrupos();
        }
    }
}
