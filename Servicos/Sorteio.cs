using System.Linq;
using System;
using System.Collections.Generic;

namespace MontaGrupos.Dominio.Servicos.Cargas
{
    public static class Sorteio
    {
        public static void Executar<TEntidade>(IEnumerable<TEntidade> pote, out TEntidade entidadeSorteada)
        {
            entidadeSorteada = default;
            if (!pote.Any())
                return;
            var indiceEntidadeSorteada = new Random().Next(0, pote.ToList().Count);
            entidadeSorteada = pote.ToList()[indiceEntidadeSorteada];
        }
    }
}