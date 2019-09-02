using System;
namespace MontaGrupos.Core
{
    public class Campeonato
    {
        public string Nome { get; set; }
        private int QuantidadePotes;
        private int QuantidadeGrupos;
        private int TamanhoPotes;
        private int TamanhoGrupos;
        public Pote[] Potes { get; private set; }

        public Grupo[] Grupos { get; private set; }

        // public Campeonato()
        // {
        //     Nome = "";
        //     QuantidadePotes = 4;
        //     QuantidadeGrupos = 8;
        //     TamanhoPotes = 8;
        //     TamanhoGrupos = 4;
        //     Inicializar();
        // }

        public Campeonato(string nomeCampeonato, int quantidadePote, int quantidadeGrupo, int tamanhoPote, int tamanhoGrupo)
        {
            Nome = nomeCampeonato;
            QuantidadePotes = quantidadePote;
            QuantidadeGrupos = quantidadeGrupo;
            TamanhoPotes = tamanhoPote;
            TamanhoGrupos = tamanhoGrupo;
            Inicializar();
        }

        private void Inicializar()
        {
            Potes = new Pote[QuantidadePotes + 1];
            for (int i = 1; i <= QuantidadePotes; i++)
            {
                Potes[i] = new Pote(nome: $"Pote {i}", tamanho: TamanhoPotes);
            }

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
                var timeSorteado = Potes[numeroPote].Sortear();
                Potes[numeroPote].ListaTimes.Remove(timeSorteado);
                Grupos[numeroGrupo].Inserir(timeSorteado);
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

        public void MontarPotes(string nomeArquivo)
        {
            Arquivo.ImportarArquivo(nomeArquivo, out var listaTimes);

            var numeroPote = 1;
            foreach (var time in listaTimes)
            {
                if (Potes[numeroPote].ListaTimes.Count == TamanhoPotes)
                {
                    numeroPote++;
                }

                if (numeroPote <= QuantidadePotes)
                {
                    Potes[numeroPote].Inserir(time);
                }
                else
                {
                    break;
                }
            }
        }

        public void MontarGrupos()
        {
            for (var numeroPote = 1; numeroPote <= QuantidadePotes; numeroPote++)
            {
                SortearPote(numeroPote);
            }
        }

        public void SalvarGrupos()
        {
            var nomeArquivo = @"~/" + Nome + ".txt";
            Arquivo.EscreverArquivo(nomeArquivo, new string[] { ListarGrupos() });
        }
    }
}