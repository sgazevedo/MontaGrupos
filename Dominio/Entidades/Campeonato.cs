using System.Collections.Generic;
using MontaGrupos.Dominio.Dtos;
using MontaGrupos.Infra.Arquivos;

namespace MontaGrupos.Dominio.Entidades
{
    public class Campeonato
    {
        private readonly ParametrosCampeonato parametrosCampeonato;
        private readonly IList<Selecao> listaTimes;
        public Pote[] Potes { get; private set; }
        public Grupo[] Grupos { get; private set; }
        public Campeonato(ParametrosCampeonato parametrosCampeonato, IList<Selecao> listaTimes)
        {
            this.parametrosCampeonato = parametrosCampeonato;
            this.listaTimes = listaTimes;
            Inicializar();
        }
        private void Inicializar()
        {
            Potes = new Pote[parametrosCampeonato.QuantidadePotes + 1];
            for (int i = 1; i <= parametrosCampeonato.QuantidadePotes; i++)
            {
                Potes[i] = new Pote(nome: $"Pote {i}", tamanho: parametrosCampeonato.TamanhoPotes);
            }

            Grupos = new Grupo[parametrosCampeonato.QuantidadeGrupos + 1];
            for (int i = 1; i <= parametrosCampeonato.QuantidadeGrupos; i++)
            {
                Grupos[i] = new Grupo(nome: $"Grupo {i}", tamanho: parametrosCampeonato.TamanhoGrupos);
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

        public void MontarPotes()
        {
            var numeroPote = 1;
            foreach (var time in listaTimes)
            {
                if (Potes[numeroPote].ListaTimes.Count == parametrosCampeonato.TamanhoPotes)
                {
                    numeroPote++;
                }

                if (numeroPote <= parametrosCampeonato.QuantidadePotes)
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
            for (var numeroPote = 1; numeroPote <= parametrosCampeonato.QuantidadePotes; numeroPote++)
            {
                SortearPote(numeroPote);
            }
        }

        public void SalvarGrupos()
        {
            var nomeArquivo = @"~/" + parametrosCampeonato.Nome + ".txt";
            Texto.Salvar(nomeArquivo, new string[] { ListarGrupos() });
        }
    }
}