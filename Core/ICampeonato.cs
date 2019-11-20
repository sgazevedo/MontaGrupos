namespace MontaGrupos.Core
{
    public interface ICampeonato
    {
        string ListarPotes();
        string ListarGrupos();
        void MontarPotes();
        void MontarPotes(string nomeArquivo);
        void MontarGrupos();
        void SalvarGrupos();
        void SortearPote(int numeroPote);
    }
}