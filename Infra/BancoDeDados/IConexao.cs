namespace MontaGrupos.Infra.BancoDeDados
{
    public interface IConexao
    {
        void Conectar();
        void Desconectar();
    }
}