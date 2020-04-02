using System;
using System.Collections.Generic;
using System.Linq;

namespace MontaGrupos.Infra.BancoDeDados
{
    public abstract class Repositorio<TEntidade> : IDisposable
    {
        private readonly ConexaoRavenDb conexaoRavenDb;

        public Repositorio()
        {
            conexaoRavenDb = new ConexaoRavenDb();
            conexaoRavenDb.Conectar();
        }

        public virtual void Incluir(TEntidade entidade)
        {
            using (var session = conexaoRavenDb.DocumentStore.OpenSession())
            {
                session.Store(entidade);
                session.SaveChanges();
            }
        }

        public virtual void Atualizar(TEntidade entidade, string id)
        {
            using (var session = conexaoRavenDb.DocumentStore.OpenSession())
            {
                session.Store(entidade, id);
                session.SaveChanges();
            }
        }

        public virtual IEnumerable<TEntidade> Selecionar()
        {
            using (var session = conexaoRavenDb.DocumentStore.OpenSession())
            {
                return session.Query<TEntidade>().ToList();
            }
        }

        public void Dispose()
        {
            conexaoRavenDb.Desconectar();
        }
    }
}