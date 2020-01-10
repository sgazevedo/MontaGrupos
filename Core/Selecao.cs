using System;
using System.Collections.Generic;

namespace MontaGrupos.Core
{
    public class Selecao : ITime
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public Confederacao Confederacao { get; set; }
        public int Pontuacao
        {
            get =>
                CalcularPontuacao();
            set =>
                Pontuacao = value;
        }
        public List<HistoricoPontuacao> HistoricoPontuacao { get; set; }
        public Selecao(string nome, Confederacao confederacao, int pontuacao)
        {
            Id = Guid.NewGuid().ToString();
            Nome = nome;
            Confederacao = confederacao;
            Pontuacao = pontuacao;
            HistoricoPontuacao = new List<HistoricoPontuacao>();
        }

        public string ObterNome() =>
            Nome;
        private int CalcularPontuacao()
        {
            var pontuacao = 0;
            foreach (var historico in HistoricoPontuacao)
            {
                pontuacao += historico.Pontos;
            }
            return pontuacao;
        }
    }
}