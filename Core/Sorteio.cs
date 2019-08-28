using System;
using System.Collections.Generic;

namespace MontaGrupos.Core
{
  public static class Sorteio
  {
    public static void Executar(List<Time> pote, out Time timeSorteado)
    {
      timeSorteado = null;

      if (pote.Count > 0)
      {
        var random = new Random().Next(0, pote.Count - 1);
        timeSorteado = pote[random];
      }
      else
      {
        // TODO - lançar exception quando pote estiver vazio
      }
    }
  }
}