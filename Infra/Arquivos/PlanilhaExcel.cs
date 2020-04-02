using System.IO;
using System;
using OfficeOpenXml;

namespace MontaGrupos.Infra.Arquivos
{
    public class PlanilhaExcel : IDisposable
    {
        private readonly ExcelPackage arquivo;
        private readonly ExcelWorksheet planilha;

        public PlanilhaExcel(string nomeArquivo, string nomePlanilha = "Plan1")
        {
            if (!File.Exists(nomeArquivo))
                throw new FileLoadException("Arquivo inválido.");
            arquivo = new ExcelPackage(new FileInfo(nomeArquivo));
            planilha = arquivo.Workbook.Worksheets[nomePlanilha];
            if (planilha == null)
                throw new FileNotFoundException("Planilha não existe.");
        }

        public bool LinhaEmBranco(int linha) =>
            string.IsNullOrEmpty(Obter(linha, "A"))
                && string.IsNullOrEmpty(Obter(linha, "B"))
                && string.IsNullOrEmpty(Obter(linha, "C"));

        public string Obter(int linha, int coluna) =>
            (planilha.GetValue(linha, coluna) as string).Trim();

        public string Obter(int linha, string coluna) =>
            planilha.Cells[$"{coluna}{linha}"].Text.Trim();

        public void Dispose()
        {
            arquivo.Dispose();
            planilha.Dispose();
        }
    }
}