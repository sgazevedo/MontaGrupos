using System.Collections.Generic;

namespace MontaGrupos.Dominio.Dtos
{
    public struct ParametrosCampeonato
    {
        public string Nome { get; set; }
        public Confederacao Confederacao { get; set; }
        public int QuantidadePotes { get; set; }
        public int QuantidadeGrupos { get; set; }
        public int TamanhoPotes { get; set; }
        public int TamanhoGrupos { get; set; }
        public List<Regras> Regras { get; set; }
        public string NomeArquivoEntrada { get; set; }
        public string NomeArquivoSaida { get; set; }
    }
}