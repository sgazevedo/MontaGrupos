namespace MontaGrupos.Core
{
    public enum MetodoArmazenamento
    {
        Arquivo,
        BancoDeDados
    }

    public class ParametrosSistema
    {
        public MetodoArmazenamento MetodoArmazenamento { get; set; }
    }
    // TODO - codificar persitencia de dados em banco de dados RavenDB
}