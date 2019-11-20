using System;

namespace MontaGrupos.Core
{
    public class Time : ITime
    {
        public string Nome { get; set; }
        public Time(string nome) =>
            Nome = nome;
        public string ObterNome() =>
            Nome;
    }
}

