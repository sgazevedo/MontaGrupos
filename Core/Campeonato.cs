using System.Collections.Generic;

namespace MontaGrupos.Core
{
    public class Campeonato : ICampeonato
    {
        public ConexaoRavenDB _conexaoDB;
        public ParametrosCampeonato _parametrosCampeonato;
        public Pote[] Potes { get; private set; }
        public Grupo[] Grupos { get; private set; }
        public Campeonato(ConexaoRavenDB conexao, ParametrosCampeonato parametrosCampeonato)
        {
            _conexaoDB = conexao;
            _parametrosCampeonato = parametrosCampeonato;
            Inicializar();
        }
        private void Inicializar()
        {
            Potes = new Pote[_parametrosCampeonato.QuantidadePotes + 1];
            for (int i = 1; i <= _parametrosCampeonato.QuantidadePotes; i++)
            {
                Potes[i] = new Pote(nome: $"Pote {i}", tamanho: _parametrosCampeonato.TamanhoPotes);
            }

            Grupos = new Grupo[_parametrosCampeonato.QuantidadeGrupos + 1];
            for (int i = 1; i <= _parametrosCampeonato.QuantidadeGrupos; i++)
            {
                Grupos[i] = new Grupo(nome: $"Grupo {i}", tamanho: _parametrosCampeonato.TamanhoGrupos);
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
            Arquivo.ImportarArquivo(_parametrosCampeonato.NomeArquivoEntrada, out var listaTimes);

            var numeroPote = 1;
            foreach (var time in listaTimes)
            {
                if (Potes[numeroPote].ListaTimes.Count == _parametrosCampeonato.TamanhoPotes)
                {
                    numeroPote++;
                }

                if (numeroPote <= _parametrosCampeonato.QuantidadePotes)
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
            for (var numeroPote = 1; numeroPote <= _parametrosCampeonato.QuantidadePotes; numeroPote++)
            {
                SortearPote(numeroPote);
            }
        }

        public void SalvarGrupos()
        {
            var nomeArquivo = @"~/" + _parametrosCampeonato.Nome + ".txt";
            Arquivo.EscreverArquivo(nomeArquivo, new string[] { ListarGrupos() });
        }
    }
}