using System;
using System.Collections.Generic;
using MontaGrupos.Dominio.Entidades;

namespace MontaGrupos.Dominio.Servicos.Cargas
{
    public static class Sorteio
    {
        public static void Executar(List<Selecao> pote, out Selecao timeSorteado)
        {
            timeSorteado = null;

            if (pote.Count > 0)
            {
                var random = new Random().Next(0, pote.Count);
                timeSorteado = pote[random];
            }
            else
            {
                // TODO - lançar exception quando pote estiver vazio
            }
        }
    }
}