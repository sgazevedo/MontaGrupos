using System.Collections;
using System;
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
            ObterPorConfederacao(confederacao).OrderByDescending(x => x.Pontuacao);

        public IEnumerable<Selecao> ObterTodasOrdenadoPorPontuacao() =>
            base.Selecionar().OrderByDescending(x => x.Pontuacao);
    }
}