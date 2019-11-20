using System;
using System.Collections.Generic;

namespace MontaGrupos.Core
{
    public static class Sorteio
    {
        public static void Executar(List<ITime> pote, out ITime timeSorteado)
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