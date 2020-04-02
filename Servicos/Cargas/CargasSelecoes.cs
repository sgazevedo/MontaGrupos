using System.Collections.Generic;
using System.IO;
using MontaGrupos.Dominio.Dtos;
using MontaGrupos.Infra.Arquivos;
using MontaGrupos.Dominio.Entidades;

namespace MontaGrupos.Dominio.Servicos.Cargas
{
    public static class CargasSelecoes
    {
        private static IList<Selecao> listaSelecoes;
        private const string CaminhoPadrao = @"Suites/Selecoes/";

        public static IEnumerable<Selecao> Obter()
        {
            listaSelecoes = new List<Selecao>();
            ImportarTodas();
            return listaSelecoes;
        }

        private static void ImportarTodas()
        {
            Importar(Confederacao.AFC);
            Importar(Confederacao.CAF);
            Importar(Confederacao.CONCACAF);
            Importar(Confederacao.CONMEBOL);
            Importar(Confederacao.OFC);
            Importar(Confederacao.UEFA);
        }

        private static void Importar(Confederacao confederacao)
        {
            var nomes = Texto.Obter(Path.Combine(CaminhoPadrao, $"{confederacao}.txt"));
            foreach (var nome in nomes)
                listaSelecoes.Add(new Selecao(nome, confederacao));
        }
    }
}