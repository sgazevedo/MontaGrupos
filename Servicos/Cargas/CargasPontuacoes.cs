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
                            PontosGanhos = Convert.ToInt32(planilhaExcel.Obter(linha, "B")),
                            Vitorias = Convert.ToInt32(planilhaExcel.Obter(linha, "C")),
                            Empates = Convert.ToInt32(planilhaExcel.Obter(linha, "D")),
                            Derrotas = Convert.ToInt32(planilhaExcel.Obter(linha, "E")),
                            GolsPro = Convert.ToInt32(planilhaExcel.Obter(linha, "F")),
                            GolsContra = Convert.ToInt32(planilhaExcel.Obter(linha, "G")),
                            SaldoGols = Convert.ToInt32(planilhaExcel.Obter(linha, "H"))
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
        public int PontosGanhos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
        public int SaldoGols { get; set; }
        public int Pontuacao
        {
            get => SomaDePontos();
        }

        private int SomaDePontos() =>
            PontosGanhos + (Vitorias * 2) + GolsPro;
    }
}