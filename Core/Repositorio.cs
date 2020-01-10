using System.Collections.Generic;
using Raven.Client.Documents.Linq;
using System.Linq;

namespace MontaGrupos.Core
{
    public class Repositorio
    {
        public static void IncluirSelecao(ConexaoRavenDB conexao, Selecao selecao)
        {
            using (var session = conexao.DocumentStore.OpenSession())
            {
                session.Store(selecao);
                session.SaveChanges();
            }
        }
        public static Selecao ObterSelecao(ConexaoRavenDB conexao, string nomeSelecao)
        {
            using (var session = conexao.DocumentStore.OpenSession())
            {
                var selecoes = session.Query<Selecao>().Where(c => c.Nome.Equals(nomeSelecao)).ToList();
                foreach (var selecao in selecoes)
                {
                    return selecao;
                }
                return null;
            }
        }
        public static void IncluirHistoricoPontuacao(ConexaoRavenDB conexao, string nomeSelecao,
            HistoricoPontuacao historicoPontuacao)
        {

        }


        public static void ObterListaSelecoes(ConexaoRavenDB conexao, ParametrosCampeonato parametrosCampeonato, out List<Selecao> listaTimes)
        {
            listaTimes = new List<Selecao>();

        }

    }
}
