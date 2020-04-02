using MontaGrupos.Dominio.Servicos.Cargas;
using MontaGrupos.Dominio.Repositorios;

namespace MontaGrupos.Dominio.Comandos.Cargas
{
    public static class ImportarSelecoes
    {
        public static void Executar()
        {
            var selecoes = CargasSelecoes.Obter();
            using (var selecaoRepositorio = new SelecaoRepositorio())
            {
                foreach (var selecao in selecoes)
                    selecaoRepositorio.Salvar(selecao);
            }
        }
    }
}