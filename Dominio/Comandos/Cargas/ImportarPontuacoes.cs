using System;
using System.Linq;
using System.Collections.Generic;
using MontaGrupos.Dominio.Servicos.Cargas;
using MontaGrupos.Dominio.Repositorios;
using MontaGrupos.Dominio.Dtos;

// var importarPontuacoes = new ImportarPontuacoes();
// importarPontuacoes.Executar(Confederacao.AFC, "01_CopaÁsia_FaseEliminatorias");
// importarPontuacoes.Executar(Confederacao.AFC, "01_CopaÁsia_FaseFinal");
// importarPontuacoes.Executar(Confederacao.AFC, "01_CopaÁsia_FaseGrupos");

// importarPontuacoes.Executar(Confederacao.CAF, "01_CopaAfricana_FaseEliminatorias");
// importarPontuacoes.Executar(Confederacao.CAF, "01_CopaAfricana_FaseFinal");
// importarPontuacoes.Executar(Confederacao.CAF, "01_CopaAfricana_FaseGrupos");

// importarPontuacoes.Executar(Confederacao.CONCACAF, "01_CopaOuro_FaseEliminatorias");
// importarPontuacoes.Executar(Confederacao.CONCACAF, "01_CopaOuro_FaseFinal");
// importarPontuacoes.Executar(Confederacao.CONCACAF, "01_CopaOuro_FaseGrupos");

// importarPontuacoes.Executar(Confederacao.CONMEBOL, "01_CopaAmérica_FaseEliminatorias");
// importarPontuacoes.Executar(Confederacao.CONMEBOL, "01_CopaAmérica_FaseFinal");
// importarPontuacoes.Executar(Confederacao.CONMEBOL, "01_CopaAmérica_FaseGrupos");

// importarPontuacoes.Executar(Confederacao.UEFA, "01_Eurocopa_FaseEliminatorias");
// importarPontuacoes.Executar(Confederacao.UEFA, "01_Eurocopa_FaseFinal");
// importarPontuacoes.Executar(Confederacao.UEFA, "01_Eurocopa_FaseGrupos");

// importarPontuacoes.Executar(Confederacao.AFC, "01_CopaDoMundo_FaseEliminatorias");

// importarPontuacoes.Executar(Confederacao.CAF, "01_CopaDoMundo_FaseEliminatorias");

// importarPontuacoes.Executar(Confederacao.CONCACAF, "01_CopaDoMundo_FaseEliminatorias");

// importarPontuacoes.Executar(Confederacao.CONMEBOL, "01_CopaDoMundo_FaseEliminatorias");

// importarPontuacoes.Executar(Confederacao.UEFA, "01_CopaDoMundo_FaseEliminatorias");

// importarPontuacoes.Executar(Confederacao.FIFA, "01_CopaDasConfederações_FaseGrupos");
// importarPontuacoes.Executar(Confederacao.FIFA, "01_CopaDasConfederações_FaseFinal");

// importarPontuacoes.Executar(Confederacao.FIFA, "01_CopaDoMundo_FaseGrupos");
// importarPontuacoes.Executar(Confederacao.FIFA, "01_CopaDoMundo_FaseFinal");

namespace MontaGrupos.Dominio.Comandos.Cargas
{
    public class ImportarPontuacoes
    {
        private readonly IList<string> logErros = new List<string>();

        public ImportarPontuacoes()
        {
            logErros = new List<string>();
        }

        public void Executar(Confederacao confederacao, string nomeCampeonato)
        {
            var cargasPontuacoes = CargasPontuacoes.Obter(confederacao, nomeCampeonato);
            if (!ValidarCargasPontuacoes(cargasPontuacoes))
                return;
            Salvar(cargasPontuacoes);
        }

        public void Executar(string nomeArquivo)
        {
            var cargasPontuacoes = CargasPontuacoes.Obter(nomeArquivo);
            if (!ValidarCargasPontuacoes(cargasPontuacoes))
                return;
            Salvar(cargasPontuacoes);
        }

        private bool ValidarCargasPontuacoes(IDictionary<string, IEnumerable<RegistroPontuacao>> cargasPontuacoes)
        {
            if (cargasPontuacoes == null)
                return false;
            return true;
        }

        private void Salvar(IDictionary<string, IEnumerable<RegistroPontuacao>> cargasPontuacoes)
        {
            if (!ValidarSelecoes(cargasPontuacoes))
                return;

            using (var selecaoRepositorio = new SelecaoRepositorio())
            {
                foreach (var campeonato in cargasPontuacoes)
                {
                    var nomeCampeonato = campeonato.Key;
                    foreach (var registroPontuacao in campeonato.Value)
                    {
                        var selecao = selecaoRepositorio.ObterPorNome(registroPontuacao.Id);
                        selecao.AdicionarHistorico(
                            new HistoricoPontuacao()
                            {
                                Descricao = nomeCampeonato,
                                Pontos = registroPontuacao.Pontuacao
                            }
                        );
                        selecaoRepositorio.Salvar(selecao);
                    }
                }
            }
        }

        private bool ValidarSelecoes(IDictionary<string, IEnumerable<RegistroPontuacao>> cargasPontuacoes)
        {
            logErros.Clear();

            using (var selecaoRepositorio = new SelecaoRepositorio())
            {
                foreach (var campeonato in cargasPontuacoes)
                {
                    var nomeCampeonato = campeonato.Key;
                    foreach (var registroPontuacao in campeonato.Value)
                    {
                        var selecao = selecaoRepositorio.ObterPorNome(registroPontuacao.Id);
                        if (selecao == null)
                        {
                            logErros.Add($"{nameof(registroPontuacao.Id)} {registroPontuacao.Id} não encontrado " +
                                $"no repositorio (arquivo: {nomeCampeonato})");
                            continue;
                        }
                    }
                }
            }

            if (logErros.Any())
                foreach (var log in logErros)
                    Console.WriteLine(log);

            return !logErros.Any();
        }
    }
}