using System;
using System.Collections.Generic;
using System.IO;
using MontaGrupos.Dominio.Dtos;
using MontaGrupos.Infra.Arquivos;

namespace MontaGrupos.Dominio.Servicos.Cargas
{
    public static class CargasPontuacoes
    {
        private const string CaminhoPadrao = @"Suites/Pontuacoes/";

        public static IDictionary<string, IEnumerable<RegistroPontuacao>> Obter(Confederacao confederacao)
        {
            // var diretorio = Path.Combine(CaminhoPadrao, confederacao.ToString());
            throw new NotImplementedException();
            // TODO - implementar leitura de arquivos por diretorio
        }

        public static IDictionary<string, IEnumerable<RegistroPontuacao>> Obter(Confederacao confederacao, string nomeCampeonato)
        {
            var nomeArquivo = Path.Combine(CaminhoPadrao, Path.Combine(confederacao.ToString(), $"{nomeCampeonato}.xlsx"));
            return Obter(nomeArquivo);
        }

        public static IDictionary<string, IEnumerable<RegistroPontuacao>> Obter(string nomeArquivo)
        {
            var registrosPontuacao = ObterRegistrosPontuacao(nomeArquivo);
            if (registrosPontuacao == null)
                return default;

            var nomeCampeonato = ObterNomeCampeonato(nomeArquivo);

            return new Dictionary<string, IEnumerable<RegistroPontuacao>>()
            {
                {
                    nomeCampeonato, registrosPontuacao
                }
            };
        }

        private static IEnumerable<RegistroPontuacao> ObterRegistrosPontuacao(string nomeArquivo)
        {
            if (!File.Exists(nomeArquivo))
                return default;

            var pontuacao = new List<RegistroPontuacao>();

            using (var planilhaExcel = new PlanilhaExcel(nomeArquivo))
            {
                for (int linha = 2; ; linha++)
                {
                    if (planilhaExcel.LinhaEmBranco(linha))
                        break;

                    pontuacao.Add(
                        new RegistroPontuacao()
                        {
                            Id = planilhaExcel.Obter(linha, "A"),
                            PontosGanhos = planilhaExcel.Obter(linha, "B"),
                            Vitorias = planilhaExcel.Obter(linha, "C"),
                            Empates = planilhaExcel.Obter(linha, "D"),
                            Derrotas = planilhaExcel.Obter(linha, "E"),
                            GolsPro = planilhaExcel.Obter(linha, "F"),
                            GolsContra = planilhaExcel.Obter(linha, "G"),
                            SaldoGols = planilhaExcel.Obter(linha, "H")
                        }
                    );
                }
            }

            return pontuacao;
        }

        private static string ObterNomeCampeonato(string nomeArquivo) =>
            Path.GetFileNameWithoutExtension(nomeArquivo).Replace(Path.GetDirectoryName(nomeArquivo), "");
    }

    public class RegistroPontuacao
    {
        public string Id { get; set; }
        public string PontosGanhos { get; set; }
        public string Vitorias { get; set; }
        public string Empates { get; set; }
        public string Derrotas { get; set; }
        public string GolsPro { get; set; }
        public string GolsContra { get; set; }
        public string SaldoGols { get; set; }
        public int Pontuacao
        {
            get
            {
                var somaPontos = 0;
                int result;
                int.TryParse(PontosGanhos, out result);
                somaPontos += result;
                int.TryParse(Vitorias, out result);
                somaPontos += result;
                int.TryParse(GolsPro, out result);
                somaPontos += result;
                return somaPontos;
            }
        }
    }
}