using MontaGrupos.Infra.BancoDeDados;
using System.Collections.Generic;
using Raven.Client.Documents.Linq;
using System.Linq;
using MontaGrupos.Dominio.Entidades;
using MontaGrupos.Dominio.Dtos;

namespace MontaGrupos.Dominio.Repositorios
{
    public class SelecaoRepositorio : Repositorio<Selecao>
    {
        public SelecaoRepositorio()
        {
        }

        public void Salvar(Selecao entidade)
        {
            var selecao = ObterPorNome(entidade.Nome);
            if (selecao != null)
                base.Atualizar(entidade, selecao.Id);
            else
                base.Incluir(entidade);
        }

        public Selecao ObterPorNome(string nome) =>
            base.Selecionar().FirstOrDefault(x => x.Nome == nome);

        public IEnumerable<Selecao> ObterPorConfederacao(Confederacao confederacao) =>
            base.Selecionar().Where(x => x.Confederacao == confederacao);

        public IEnumerable<Selecao> ObterPorConfederacaoOrdenadoPorPontuacao(Confederacao confederacao) =>
            ObterOrdenacaoPorPontuacaoENome(ObterPorConfederacao(confederacao));

        public IEnumerable<Selecao> ObterTodasOrdenadoPorPontuacao() =>
            ObterOrdenacaoPorPontuacaoENome(base.Selecionar());

        public IEnumerable<Selecao> ObterSelecoes(IEnumerable<string> selecoes)
        {
            var listaDeSelecoes = new List<Selecao>();
            foreach (var selecao in selecoes)
            {
                var selecaoDaLista = ObterPorNome(selecao);
                if (selecaoDaLista != null)
                    listaDeSelecoes.Add(selecaoDaLista);
            }
            return ObterOrdenacaoPorPontuacaoENome(listaDeSelecoes);
        }

        private IEnumerable<Selecao> ObterOrdenacaoPorPontuacaoENome(IEnumerable<Selecao> listaDeSelecoes) =>
            from selecao in listaDeSelecoes
            orderby selecao.Pontuacao descending, selecao.Nome
            select selecao;
    }
}