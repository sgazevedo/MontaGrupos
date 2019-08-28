using MontaGrupos.Core;

namespace MontaGrupos.Campeonatos
{
  public class Eurocopa
  {
    public Pote[] Potes { get; private set; }

    public Grupo[] Grupos { get; private set; }

    public Eurocopa()
    {
      CriarPotes();
      CriarGrupos();
    }

    private void CriarPotes()
    {
      Potes = new Pote[] {
            new Pote(nome: "Pote 1", tamanho: 8),
            new Pote(nome: "Pote 2", tamanho: 8),
            new Pote(nome: "Pote 3", tamanho: 8),
            new Pote(nome: "Pote 4", tamanho: 8)
        };
    }

    private void CriarGrupos()
    {
      Grupos = new Grupo[] {
            new Grupo(nome: "Grupo A", tamanho: 4),
            new Grupo(nome: "Grupo B", tamanho: 4),
            new Grupo(nome: "Grupo C", tamanho: 4),
            new Grupo(nome: "Grupo D", tamanho: 4),
            new Grupo(nome: "Grupo E", tamanho: 4),
            new Grupo(nome: "Grupo F", tamanho: 4),
            new Grupo(nome: "Grupo G", tamanho: 4),
            new Grupo(nome: "Grupo H", tamanho: 4)
        };
    }

    public string ListarPotes()
    {
      var listaDePotes = "";
      foreach (var pote in Potes)
      {
        if (listaDePotes.Trim().Length > 0)
        {
          listaDePotes += "\n";
        }
        listaDePotes += pote.Listar();
      }

      return listaDePotes;
    }

    public string ListarGrupos()
    {
      var listaDeGrupos = "";
      foreach (var grupo in Grupos)
      {
        if (listaDeGrupos.Trim().Length > 0)
        {
          listaDeGrupos += "\n";
        }
        listaDeGrupos += grupo.Listar();
      }

      return listaDeGrupos;
    }

    public void SortearPote(int numeroPote)
    {
      var numeroGrupo = 0;

      while (Potes[numeroPote].ListaTimes.Count > 0)
      {
        var selecaoSorteada = (Selecao)Potes[numeroPote].Sortear();
        Potes[numeroPote].ListaTimes.Remove(selecaoSorteada);
        Grupos[numeroGrupo].Inserir(selecaoSorteada);
        numeroGrupo++;
      }
    }
  }
}