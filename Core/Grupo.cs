using System;
using System.Collections.Generic;

namespace MontaGrupos.Core
{
  public class Grupo
  {
    public string Nome { get; set; }
    public List<Time> ListaTimes { get; private set; }
    public int Tamanho { get; private set; }

    public Grupo()
    {
      ListaTimes = new List<Time>();
    }

    public Grupo(string nome, int tamanho)
    {
      ListaTimes = new List<Time>();
      Nome = nome;
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

    public string Listar()
    {
      var timesEmGrupo = "";
      foreach (var time in ListaTimes)
      {
        if (timesEmGrupo.Trim().Length > 0)
        {
          timesEmGrupo += " | ";
        }
        timesEmGrupo = timesEmGrupo + time.ToString();
      }
      return $"{Nome}: " + (timesEmGrupo.Trim().Length > 0 ? timesEmGrupo.Trim() : "Nenhum time no grupo");
    }
  }
}