
using System.Linq;
using MontaGrupos.Dominio.Dtos;
using MontaGrupos.Dominio.Entidades;
using MontaGrupos.Dominio.Repositorios;

namespace MontaGrupos.Dominio.Comandos.Campeonatos
{
    public static class MontarCampeonato
    {
        public static void Executar(ParametrosCampeonato parametrosCampeonato)
        {
            using (var selecaoRepositorio = new SelecaoRepositorio())
            {
                var listaTimes = selecaoRepositorio
                    .ObterPorConfederacaoOrdenadoPorPontuacao(parametrosCampeonato.Confederacao).ToList();
                var campeonato = new Campeonato(parametrosCampeonato, listaTimes);
                campeonato.Montar();
            }
        }
    }
}