using System.Collections.Generic;
using MontaGrupos.Dominio.Dtos;

namespace MontaGrupos.Dominio.Entidades
{
    public class Selecao
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public Confederacao Confederacao { get; set; }
        public IList<HistoricoPontuacao> HistoricoPontuacao { get; set; }
        public int Pontuacao
        {
            get
            {
                var soma = 0;
                foreach (var historico in HistoricoPontuacao)
                    soma += historico.Pontos;
                return soma;
            }
        }

        public Selecao(string nome, Confederacao confederacao)
        {
            Id = string.Empty;
            Nome = nome;
            Confederacao = confederacao;
            HistoricoPontuacao = new List<HistoricoPontuacao>();
        }

        public void AdicionarHistorico(HistoricoPontuacao historicoPontuacao) =>
            HistoricoPontuacao.Add(historicoPontuacao);
    }
}