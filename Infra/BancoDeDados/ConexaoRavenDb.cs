using Raven.Client.Documents;
using MontaGrupos.Infra.Sistema;

namespace MontaGrupos.Infra.BancoDeDados
{
    public class ConfiguracaoRavenDb
    {
        public string[] Urls { get; set; }
        public string Database { get; set; }
    }

    public class ConexaoRavenDb : IConexao
    {
        public DocumentStore DocumentStore { get; set; }
        private readonly ConfiguracaoRavenDb configuracaoRavenDb;

        public ConexaoRavenDb()
        {
            configuracaoRavenDb = new ConfiguracaoRavenDb();
            Configuracoes.Definir("ConfiguracaoRavenDB", configuracaoRavenDb);
        }

        public void Conectar()
        {
            DocumentStore = new DocumentStore()
            {
                Urls = configuracaoRavenDb.Urls,
                Database = configuracaoRavenDb.Database
            };
            DocumentStore.Initialize();
        }

        public void Desconectar() =>
            DocumentStore.Dispose();
    }
}