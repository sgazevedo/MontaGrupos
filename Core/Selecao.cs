using System;

namespace MontaGrupos.Core
{
    // AFC = Ásia, CAF = África, CONCACAF = América Central e do Norte, CONMEBOL = América do Sul, OFC = Oceania, UEFA = Europa
    public enum EConfederacao { Indefinido, AFC, CAF, CONCACAF, CONMEBOL, OFC, UEFA }

    public class Selecao : Time
    {
        public EConfederacao Confederacao { get; private set; }
        public int Pontuacao { get; set; }

        public Selecao()
        {
            Nome = "nome";
            Confederacao = EConfederacao.Indefinido;
            Pontuacao = 0;
        }

        public Selecao(string nome)
        {
            Nome = nome;
            Confederacao = EConfederacao.Indefinido;
            Pontuacao = 0;
        }

        public Selecao(string nome, EConfederacao confederacao, int pontuacao)
        {
            Nome = nome;
            Confederacao = confederacao;
            Pontuacao = pontuacao;
        }

        public override string ToString()
        {
            return $"{base.ToString()}";
        }
    }
}

