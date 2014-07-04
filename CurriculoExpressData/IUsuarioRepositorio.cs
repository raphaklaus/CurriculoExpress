using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurriculoExpressDomain;
using System.Collections;

namespace CurriculoExpressData
{
    public interface IUsuarioRepositorio
    {
        void Novo(UsuarioRegistro usuario);
        void Excluir(UsuarioRegistro usuario);
        UsuarioRegistro ObterPor(int id);
        IEnumerable ObterTodos();
        bool CPFJaExiste(UsuarioRegistro usuario);
        
    }
}