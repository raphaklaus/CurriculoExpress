using System;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CurriculoExpressDomain
{
    public class Curriculo
    {
        public virtual int id { get; set; }

        [Required(ErrorMessage = @"Por favor, preencha o Nome.")]
        [StringLength(40, ErrorMessage = @"Tamanho do Nome deve ter até 40 caracteres.")]
        public virtual string Nome { get; set; }

        [Required(ErrorMessage = @"Por favor, preencha o CPF.")]
        [StringLength(14, ErrorMessage = @"CPF deve ter 14 números.")]
        [Remote("CPFJaCadastrado", "Curriculo", HttpMethod = "POST", ErrorMessage = "CPF Já existente.")]
        public virtual string CPF { get; set; }

        [Required(ErrorMessage = @"Por favor, preencha a Identidade.")]
        [StringLength(12, ErrorMessage = @"Identidade deve ter 12 números.")]
        [Remote("IdentidadeJaExiste", "Curriculo", HttpMethod = "POST", ErrorMessage = "Identidade Já existente.")]
        public virtual string Identidade { get; set; }

        [Required(ErrorMessage = @"Por favor, preencha a Orgão Emissor.")]
        [StringLength(5, ErrorMessage = @"Orgão emissor deve ter até 5 caractéres.")]
        public virtual string OrgaoEmissor { get; set; }

        [Required(ErrorMessage = @"Por favor, preencha o Endereço.")]
        [StringLength(60, ErrorMessage = @"Endereço deve ter até 60 caractéres.")]
        public virtual string Endereco { get; set; }

        [Required(ErrorMessage = @"Por favor, preencha o Cidade.")]
        public virtual string Cidade { get; set; }

        [Required(ErrorMessage = @"Por favor, preencha o Estado.")]
        public virtual string Estado { get; set; }
    }
}