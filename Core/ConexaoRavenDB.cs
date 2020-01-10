using Raven.Client.Documents;

namespace MontaGrupos.Core
{
    public interface IConexao
    {
        void Conectar();
        void Desconectar();
    }
    public class ConfiguracaoRavenDB
    {
        public string[] Urls { get; set; }
        public string Database { get; set; }
    }
    public class ConexaoRavenDB : IConexao
    {
        public DocumentStore DocumentStore { get; set; }
        private ConfiguracaoRavenDB _configuracaoRavenDB;
        public ConexaoRavenDB(ConfiguracaoRavenDB configuracaoRavenDB) =>
            _configuracaoRavenDB = configuracaoRavenDB;
        public void Conectar()
        {
            DocumentStore = new DocumentStore()
            {
                Urls = _configuracaoRavenDB.Urls,
                Database = _configuracaoRavenDB.Database
            };
            DocumentStore.Initialize();
        }
        public void Desconectar() =>
            DocumentStore.Dispose();
    }
}