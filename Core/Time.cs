using System;

namespace MontaGrupos.Core
{
  public class Time
  {
    public string Nome { get; set; }

    public Time() { }

    public Time(string nome)
    {
      Nome = nome;
    }

    public override string ToString()
    {
      return Nome;
    }

  }
}

