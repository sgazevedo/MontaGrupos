namespace MontaGrupos.Core
{
    public class CargasSelecoes
    {
        private ConexaoRavenDB _conexaoRavenDB;
        public CargasSelecoes(ConexaoRavenDB conexao) =>
            _conexaoRavenDB = conexao;
        public void Importar(Confederacao confederacao)
        {
            Arquivo.ImportarArquivo($"~/{confederacao}.txt", out var listaTimes);
            foreach (var time in listaTimes)
            {
                Repositorio.IncluirSelecao(_conexaoRavenDB, new Selecao(time.ObterNome(), confederacao, 0));
            }
        }
        public void ImportarTodas()
        {
            Importar(Confederacao.AFC);
            Importar(Confederacao.CAF);
            Importar(Confederacao.CONCACAF);
            Importar(Confederacao.CONMEBOL);
            Importar(Confederacao.OFC);
            Importar(Confederacao.UEFA);
        }
        public static void CarregarSelecoes(ConexaoRavenDB conexao) =>
            new CargasSelecoes(conexao).ImportarTodas();
    }
}