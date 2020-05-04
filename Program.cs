using System.Collections.Generic;
using System.Linq;
using System;
using MontaGrupos.Dominio.Dtos;
using MontaGrupos.Dominio.Repositorios;
using MontaGrupos.Infra.Sistema;
using MontaGrupos.Dominio.Entidades;
using MontaGrupos.Dominio.Comandos.Cargas;
using MontaGrupos.Dominio.Comandos.Campeonatos;

namespace MontaGrupos
{
    public class Program
    {
        public static void Main()
        {
            var campeonatos = new Campeonatos();
            Configuracoes.Definir("Campeonatos", campeonatos);
            MontarCampeonato.Executar(campeonatos.CampeonatosSelecoes.CopaConcacafEliminatorias);

            // using (var selecaoRepositorio = new SelecaoRepositorio())
            // {
            //     var selecoes = selecaoRepositorio.ObterPorConfederacaoOrdenadoPorPontuacao(Confederacao.UEFA);
            //     foreach (var selecao in selecoes)
            //         Console.WriteLine($"{selecao.Nome} {selecao.Pontuacao}");
            // }

            //MontarCopaDoMundo.Executar();




            Console.ReadKey();
        }
    }
}
