namespace MontaGrupos.Core
{
    public interface ICampeonato
    {
        string ListarPotes();
        string ListarGrupos();
        void MontarPotes();
        void MontarGrupos();
        void SalvarGrupos();
        void SortearPote(int numeroPote);
    }
}