using System.Collections.Generic;
using MontaGrupos.Dominio.Entidades;
using MontaGrupos.Dominio.Repositorios;
using MontaGrupos.Infra.Sistema;

namespace MontaGrupos.Dominio.Comandos.Campeonatos
{
    public static class MontarCopaDoMundo
    {
        public static void Executar()
        {
            var selecoes = new List<string>()
            {
                "Espanha",
                "Itália",
                "Portugal",
                "Inglaterra",
                "Holanda",
                "Alemanha",
                "Sérvia",
                "República Tcheca",
                "Turquia",
                "Irlanda",
                "Suíça",
                "Romênia",
                "Croácia",
                "Brasil",
                "Argentina",
                "Uruguai",
                "Paraguai",
                "Austrália",
                "Iraque",
                "Japão",
                "Irã",
                "Estados Unidos",
                "México",
                "Costa Rica",
                "Honduras",
                "Gana",
                "África do Sul",
                "Algéria",
                "Marrocos",
                "Costa do Marfim",
                "Coréia do Sul",
                "Peru"
            };
            Executar(selecoes);
        }

        public static void Executar(IEnumerable<string> selecoes)
        {
            var campeonatos = new Dtos.Campeonatos();
            Configuracoes.Definir("Campeonatos", campeonatos);

            var campeonato = new Campeonato(campeonatos.CampeonatosSelecoes.WorldCup, ObterListaSelecoes(selecoes));
            campeonato.Montar();
        }

        private static IEnumerable<Selecao> ObterListaSelecoes(IEnumerable<string> selecoes)
        {
            using (var selecaoRepositorio = new SelecaoRepositorio())
            {
                return selecaoRepositorio.ObterSelecoes(selecoes);
            }
        }
    }
}