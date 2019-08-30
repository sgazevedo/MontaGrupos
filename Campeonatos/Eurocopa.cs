using MontaGrupos.Core;

namespace MontaGrupos.Campeonatos
{
    public class Eurocopa : Campeonato
    {
        public Eurocopa()
          : base(nomeCampeonato: "Eurocopa", quantidadePote: 4, quantidadeGrupo: 8, tamanhoPote: 8, tamanhoGrupo: 4)
        {

        }

        public Eurocopa(string nomeCampeonato, int quantidadePote, int quantidadeGrupo, int tamanhoPote, int tamanhoGrupo)
          : base(nomeCampeonato, quantidadePote, quantidadeGrupo, tamanhoPote, tamanhoGrupo)
        {

        }

        public void MontarPotes()
        {
            MontarPotes(nomeArquivo: "Eurocopa.txt");
        }
    }
}