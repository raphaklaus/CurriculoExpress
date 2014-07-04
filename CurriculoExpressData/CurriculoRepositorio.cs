using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurriculoExpressDomain;
using NHibernate;
using NHibernate.Linq;
using System.Collections;

namespace CurriculoExpressData
{
  public class CurriculoRepositorio : ICurriculoRepositorio
    {
        private readonly ISession _session;

        public CurriculoRepositorio(ISession session)
        {
            _session = session;
        }

        public void Novo(Curriculo curriculo)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(curriculo);
                tran.Commit();
            }
        }

        public void Excluir(Curriculo curriculo)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(curriculo);
                tran.Commit();
            }
        }

        public Curriculo ObterPor(int id)
        {
          return _session.Get<Curriculo>(id);

        }

        public bool CPFJaExiste(Curriculo curriculo)
        {
          var query = _session.QueryOver<Curriculo>().Where(x => x.CPF == curriculo.CPF);
          return query.List().Count > 0;
        }

        public bool IdentidadeJaExiste(Curriculo curriculo)
        {
          var query = _session.QueryOver<Curriculo>().Where(x => x.Identidade == curriculo.Identidade);
          return query.List().Count > 0;
        }

        public IEnumerable ObterTodos()
        {
          return _session.Query<Curriculo>().ToList();                
        }           
    }
}