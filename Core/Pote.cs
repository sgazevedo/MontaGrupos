using System;
using System.Collections.Generic;

namespace MontaGrupos.Core
{
  public class Pote
  {
    public string Nome { get; set; }
    public List<Time> ListaTimes { get; set; }
    public int Tamanho { get; private set; }

    public Pote()
    {
      Nome = "";
      ListaTimes = new List<Time>();
      Tamanho = 8;
    }

    public Pote(string nome, int tamanho)
    {
      Nome = nome;
      ListaTimes = new List<Time>();
      Tamanho = tamanho;
    }

    public void Inserir(Time time)
    {
      if (ListaTimes.Count <= Tamanho)
      {
        ListaTimes.Add(time);
      }
      else
      {
        // TODO - lançar exception quando não tem mais espaço para inserir
      }
    }

    public void Inserir(params Time[] times)
    {
      if (times.Length > 0 && times.Length <= Tamanho)
      {
        foreach (var time in times)
        {
          Inserir(time);
        }
      }
      else
      {
        // TODO - lançar exception quando o array passado por parâmetro possui tamanho maior que a lista
      }
    }

    public Time Sortear()
    {
      Sorteio.Executar(ListaTimes, out var timeSorteado);
      ListaTimes.Remove(timeSorteado);
      return timeSorteado;
    }

    public string Listar()
    {
      var timesEmLista = "";
      foreach (var time in ListaTimes)
      {
        if (timesEmLista.Trim().Length > 0)
        {
          timesEmLista += " | ";
        }
        timesEmLista = timesEmLista + time.ToString();
      }
      return $"{Nome}: " + (timesEmLista.Trim().Length > 0 ? timesEmLista.Trim() : "Nenhum time na lista");
    }
  }
}