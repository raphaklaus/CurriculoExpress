using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CurriculoExpressDomain
{
    public class UsuarioRegistro
    {
      public virtual int id { get; set; }

      [Required(ErrorMessage = @"Por favor, preencha o CPF."),
      StringLength(14, ErrorMessage = @"Tamanho do CPF inválido.")]
      [Remote("CPFJaCadastrado", "Login", HttpMethod = "POST", ErrorMessage = "CPF Já existente.")]
      public virtual string CPF { get; set; }
        
      [Required(ErrorMessage = @"Por favor, preencha a Senha."),
      StringLength(20, ErrorMessage = @"Tamanho de senha inválido.")]
      [DataType(DataType.Password)]
      public virtual string Senha { get; set; }
    }

    public class UsuarioLogin
    {
      public virtual int id { get; set; }

      [Required(ErrorMessage = @"Por favor, preencha a Senha."),
      StringLength(50, ErrorMessage = @"Tamanho de login inválido.")]
      public virtual string CPF { get; set; }

      [Required(ErrorMessage = @"Por favor, preencha a Senha."),
      StringLength(20, ErrorMessage = @"Tamanho de senha inválido.")]
      [DataType(DataType.Password)]
      public virtual string Senha { get; set; }
    }
}