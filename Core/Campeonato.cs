
namespace MontaGrupos.Core
{
    public class Campeonato
    {
        private int QuantidadePotes;
        private int QuantidadeGrupos;
        private int TamanhoPotes;
        private int TamanhoGrupos;
        public Pote[] Potes { get; private set; }

        public Grupo[] Grupos { get; private set; }

        public Campeonato()
        {
            QuantidadePotes = 4;
            QuantidadeGrupos = 8;
            TamanhoPotes = 8;
            TamanhoGrupos = 4;
            CriarPotes();
            CriarGrupos();
        }
        public Campeonato(int quantidadePote, int quantidadeGrupo, int tamanhoPote, int tamanhoGrupo)
        {
            QuantidadePotes = quantidadePote;
            QuantidadeGrupos = quantidadeGrupo;
            TamanhoPotes = tamanhoPote;
            TamanhoGrupos = tamanhoGrupo;
            CriarPotes();
            CriarGrupos();
        }

        private void CriarPotes()
        {
            Potes = new Pote[QuantidadePotes + 1];
            for (int i = 1; i <= QuantidadePotes; i++)
            {
                Potes[i] = new Pote(nome: $"Pote {i}", tamanho: TamanhoPotes);
            }
        }

        private void CriarGrupos()
        {
            Grupos = new Grupo[QuantidadeGrupos + 1];
            for (int i = 1; i <= QuantidadeGrupos; i++)
            {
                Grupos[i] = new Grupo(nome: $"Grupo {i}", tamanho: TamanhoGrupos);
            }
        }

        public void SortearPote(int numeroPote)
        {
            var numeroGrupo = 1;

            while (Potes[numeroPote].ListaTimes.Count > 0)
            {
                var selecaoSorteada = (Selecao)Potes[numeroPote].Sortear();
                Potes[numeroPote].ListaTimes.Remove(selecaoSorteada);
                Grupos[numeroGrupo].Inserir(selecaoSorteada);
                numeroGrupo++;
            }
        }

        public string ListarPotes()
        {
            var listaDePotes = "";
            foreach (var pote in Potes)
            {
                if (listaDePotes.Trim().Length > 0)
                {
                    listaDePotes += "\n";
                }
                listaDePotes += pote?.Listar();
            }

            return listaDePotes;
        }

        public string ListarGrupos()
        {
            var listaDeGrupos = "";
            foreach (var grupo in Grupos)
            {
                if (listaDeGrupos.Trim().Length > 0)
                {
                    listaDeGrupos += "\n";
                }
                listaDeGrupos += grupo?.Listar();
            }

            return listaDeGrupos;
        }
    }
}