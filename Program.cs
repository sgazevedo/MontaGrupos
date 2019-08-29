using System;
using MontaGrupos.Core;
using MontaGrupos.Campeonatos;

namespace MontaGrupos
{
    class Program
    {
        static void Main(string[] args)
        {
            var eurocopa = new Eurocopa(quantidadePote: 4, quantidadeGrupo: 8, tamanhoPote: 8, tamanhoGrupo: 4);
            eurocopa.Potes[1].Inserir(
              new Selecao("Alemanha", EConfederacao.UEFA, 100),
              new Selecao("Itália", EConfederacao.UEFA, 100),
              new Selecao("França", EConfederacao.UEFA, 100),
              new Selecao("Holanda", EConfederacao.UEFA, 100),
              new Selecao("Espanha", EConfederacao.UEFA, 100),
              new Selecao("Inglaterra", EConfederacao.UEFA, 100),
              new Selecao("Portugal", EConfederacao.UEFA, 100),
              new Selecao("Bélgica", EConfederacao.UEFA, 100));

            eurocopa.Potes[2].Inserir(
              new Selecao("Grécia", EConfederacao.UEFA, 100),
              new Selecao("Dinamarca", EConfederacao.UEFA, 100),
              new Selecao("Croácia", EConfederacao.UEFA, 100),
              new Selecao("Suíça", EConfederacao.UEFA, 100),
              new Selecao("Sérvia", EConfederacao.UEFA, 100),
              new Selecao("Suécia", EConfederacao.UEFA, 100),
              new Selecao("Polônia", EConfederacao.UEFA, 100),
              new Selecao("Rússia", EConfederacao.UEFA, 100));

            eurocopa.Potes[3].Inserir(
              new Selecao("Turquia", EConfederacao.UEFA, 100),
              new Selecao("Romênia", EConfederacao.UEFA, 100),
              new Selecao("Bósnia", EConfederacao.UEFA, 100),
              new Selecao("Escócia", EConfederacao.UEFA, 100),
              new Selecao("Rep. Tcheca", EConfederacao.UEFA, 100),
              new Selecao("Irlanda", EConfederacao.UEFA, 100),
              new Selecao("Ucrânia", EConfederacao.UEFA, 100),
              new Selecao("Eslováquia", EConfederacao.UEFA, 100));

            eurocopa.Potes[4].Inserir(
              new Selecao("Eslovênia", EConfederacao.UEFA, 100),
              new Selecao("Áustria", EConfederacao.UEFA, 100),
              new Selecao("Bulgária", EConfederacao.UEFA, 100),
              new Selecao("Montenegro", EConfederacao.UEFA, 100),
              new Selecao("Hungria", EConfederacao.UEFA, 100),
              new Selecao("Islândia", EConfederacao.UEFA, 100),
              new Selecao("Irlanda do Norte", EConfederacao.UEFA, 100),
              new Selecao("Gales", EConfederacao.UEFA, 100));

            Console.WriteLine(eurocopa.ListarPotes());

            eurocopa.SortearPote(numeroPote: 1);
            eurocopa.SortearPote(numeroPote: 2);
            eurocopa.SortearPote(numeroPote: 3);
            eurocopa.SortearPote(numeroPote: 4);

            Console.WriteLine(eurocopa.ListarGrupos());

            Console.ReadKey();
        }
    }
}
