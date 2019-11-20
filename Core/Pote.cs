using System.Collections.Generic;

namespace MontaGrupos.Core
{ // TODO - classe pote tem mesmas características de um grupo, refatorar classe herdando as definições da classe Grupo e implementar as funções extras para classe Pote
    public class Pote
    {
        public string Nome { get; set; }
        public List<ITime> ListaTimes { get; set; }
        public int Tamanho { get; private set; }

        public Pote()
        {
            Nome = "";
            ListaTimes = new List<ITime>();
            Tamanho = 0;
        }

        public Pote(string nome, int tamanho)
        {
            Nome = nome;
            ListaTimes = new List<ITime>();
            Tamanho = tamanho;
        }

        public void Inserir(ITime time)
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

        public void Inserir(params ITime[] times)
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
            var timesEmLista = "";
            foreach (var time in ListaTimes)
            {
                if (timesEmLista.Trim().Length > 0)
                {
                    timesEmLista += " | ";
                }
                timesEmLista = timesEmLista + time.ObterNome();
            }
            return $"{Nome}: " + (timesEmLista.Trim().Length > 0 ? timesEmLista.Trim() : "Nenhum time cadastrado");
        }

        public ITime Sortear()
        {
            Sorteio.Executar(ListaTimes, out var timeSorteado);
            ListaTimes.Remove(timeSorteado);
            return timeSorteado;
        }

        public void MontarPotes(List<ITime> lista)
        {
            // TODO - implementar rotina para importar arquivo e montar os potes
        }
    }
}