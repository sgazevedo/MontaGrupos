namespace MontaGrupos.Core
{
    public class Campeonatos
    {
        public CampeonatosSelecoes CampeonatosSelecoes { get; set; }
    }
    public class CampeonatosSelecoes
    {
        public ParametrosCampeonato CopaAfrica { get; set; }
        public ParametrosCampeonato CopaAfricaEliminatorias { get; set; }
        public ParametrosCampeonato CopaAmerica { get; set; }
        public ParametrosCampeonato CopaAmericaEliminatorias { get; set; }
        public ParametrosCampeonato CopaAsia { get; set; }
        public ParametrosCampeonato CopaAsiaEliminatorias { get; set; }
        public ParametrosCampeonato CopaConcacaf { get; set; }
        public ParametrosCampeonato CopaConcacafEliminatorias { get; set; }
        public ParametrosCampeonato Eurocopa { get; set; }
        public ParametrosCampeonato EurocopaEliminatorias { get; set; }
        public ParametrosCampeonato WorldCup { get; set; }
    }
}