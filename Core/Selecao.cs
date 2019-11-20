// TODO - Implementar struct Historico e nessa classe List<Historico> HistoricoPontuacao
using System;

namespace MontaGrupos.Core
{
    public class Selecao : ITime
    {
        public string Nome { get; set; }
        public Confederacao Confederacao { get; private set; }
        public int Pontuacao { get; set; }
        //public List<Historico> HistoricoPontuacao {get; set; }

        public Selecao(string nome)
        {
            Nome = nome;
            Confederacao = Confederacao.INDEFINIDO;
            Pontuacao = 0;
        }

        public Selecao(string nome, Confederacao confederacao, int pontuacao)
        {
            Nome = nome;
            Confederacao = confederacao;
            Pontuacao = pontuacao;
        }

        public string ObterNome() =>
            Nome;
    }
}