using System.Linq;
using System;
using MontaGrupos.Dominio.Dtos;
using MontaGrupos.Dominio.Repositorios;
using MontaGrupos.Infra.Sistema;
using MontaGrupos.Dominio.Entidades;

namespace MontaGrupos
{
    public class Program
    {
        public static void Main()
        {
            var campeonatos = new Campeonatos();
            Configuracoes.Definir("Campeonatos", campeonatos);
            MontarCampeonato(campeonatos.CampeonatosSelecoes.CopaConcacafEliminatorias);

            Console.ReadKey();
        }

        private static void MontarCampeonato(ParametrosCampeonato parametrosCampeonato)
        {
            using (var selecaoRepositorio = new SelecaoRepositorio())
            {
                var listaTimes = selecaoRepositorio.ObterPorConfederacaoOrdenadoPorPontuacao(parametrosCampeonato.Confederacao).ToList();
                var campeonato = new Campeonato(parametrosCampeonato, listaTimes);
                campeonato.MontarPotes();
                Console.WriteLine(campeonato.ListarPotes());
                campeonato.MontarGrupos();
                Console.WriteLine(campeonato.ListarGrupos());
                campeonato.SalvarGrupos();
            }
        }
    }
}
