using System.Collections.Generic;
using MontaGrupos.Dominio.Entidades;
using MontaGrupos.Dominio.Repositorios;
using MontaGrupos.Infra.Sistema;

namespace MontaGrupos.Dominio.Comandos.Campeonatos
{
    public static class MontarCopaDasConfederacoes
    {
        public static void Executar()
        {
            var listaDeSelecoes = new List<string>()
            {
                "Gana",
                "Uruguai",
                "Estados Unidos",
                "Austrália",
                "Uzbequistão",
                "Nova Zelândia",
                "Itália",
                "Espanha"
            };
            Executar(listaDeSelecoes);
        }

        public static void Executar(IEnumerable<string> selecoes)
        {
            var campeonatos = new Dtos.Campeonatos();
            Configuracoes.Definir("Campeonatos", campeonatos);

            var campeonato = new Campeonato(campeonatos.CampeonatosSelecoes.CopaConcacaf, ObterListaSelecoes(selecoes));
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