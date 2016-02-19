using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Pessoa
    {
        public Pessoa()
        {
            PessoaId = Guid.NewGuid();
            EnderecoList = new List<Endereco>();
        }

        public Guid PessoaId { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }

        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new PessoaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool IsPessoaFisica()
        {
            return PessoaJuridica == null && PessoaFisica != null;
        }

        public bool IsPessoaJuridica()
        {
            return PessoaJuridica != null && PessoaFisica == null;
        }
    }
}
