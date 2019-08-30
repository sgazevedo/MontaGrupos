using MontaGrupos.Core;

namespace MontaGrupos.Campeonatos
{
    public class EurocopaEliminatorias : Campeonato
    {
        public EurocopaEliminatorias()
          : base(nomeCampeonato: "EurocopaEliminatórias", quantidadePote: 4, quantidadeGrupo: 13, tamanhoPote: 13, tamanhoGrupo: 4)
        {

        }

        public EurocopaEliminatorias(string nomeCampeonato, int quantidadePote, int quantidadeGrupo, int tamanhoPote, int tamanhoGrupo)
          : base(nomeCampeonato, quantidadePote, quantidadeGrupo, tamanhoPote, tamanhoGrupo)
        {

        }

        public void MontarPotes()
        {
            MontarPotes(nomeArquivo: "UEFA.txt");
        }
    }

}