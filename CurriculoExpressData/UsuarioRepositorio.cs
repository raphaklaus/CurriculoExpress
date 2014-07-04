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
    public class UsuarioRepositorio: IUsuarioRepositorio
    {
        private readonly ISession _session;

        public UsuarioRepositorio(ISession session)
        {
            _session = session;
        }

        public void Novo(UsuarioRegistro usuario)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Save(usuario);
                tran.Commit();
            }
        }

        public void Excluir(UsuarioRegistro usuario)
        {
            using (var tran = _session.BeginTransaction())
            {
                _session.Delete(usuario);
                tran.Commit();
            }
        }

        public UsuarioRegistro ObterPor(int id)
        {
          return _session.Get<UsuarioRegistro>(id);

        }

        public bool CPFJaExiste(UsuarioRegistro usuario)
        {
          var query =_session.QueryOver<UsuarioRegistro>().Where(x => x.CPF == usuario.CPF);
          return query.List().Count > 0;
        }

        public IEnumerable ObterTodos()
        {
          return _session.Query<UsuarioRegistro>().ToList();                
        }

        public UsuarioRegistro ObterPorCPF(string CPF)
        {

          return _session.Query<UsuarioRegistro>().FirstOrDefault(x => x.CPF == CPF);
        }


        public bool Autenticou(UsuarioRegistro usuario)
        {
          usuario.CPF = usuario.CPF.Replace(".", "").Replace("-", "");
          var usuarioRegistrado = ObterPorCPF(usuario.CPF);

          if (usuarioRegistrado == null)
            return false;

          if ((usuarioRegistrado.CPF == usuario.CPF) && (usuarioRegistrado.Senha == usuario.Senha))
          {
            return true;
          }
          else
          {
            return false;
          }
        }
            
    }
}