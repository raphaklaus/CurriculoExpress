using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurriculoExpressDomain;
using System.Collections;

namespace CurriculoExpressData
{
    public interface ICurriculoRepositorio
    {
      void Novo(Curriculo curriculo);
      void Excluir(Curriculo curriculo);
      Curriculo ObterPor(int id);
      IEnumerable ObterTodos();
      bool CPFJaExiste(Curriculo curriculo);
      bool IdentidadeJaExiste(Curriculo curriculo);
    }
}