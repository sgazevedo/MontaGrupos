using System;
using System.IO;
using MontaGrupos.Core;
using Microsoft.Extensions.Configuration;

namespace MontaGrupos
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var campeonatos = new Campeonatos();
            configuration.Bind("Campeonatos", campeonatos);

            var campeonato = new Campeonato(campeonatos.CampeonatosSelecoes.WorldCup);
            campeonato.MontarPotes();
            Console.WriteLine(campeonato.ListarPotes());
            campeonato.MontarGrupos();
            Console.WriteLine(campeonato.ListarGrupos());
            campeonato.SalvarGrupos();

            Console.ReadKey();
        }
    }
}
