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
            AnexoList = new List<Anexo>();
            ContatoList = new List<Contato>();
            Ativo = true;
        }

        public Guid PessoaId { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Proprietario Proprietario { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }
        public virtual ICollection<Contato> ContatoList { get; set; }
        public virtual ICollection<Anexo> AnexoList { get; set; }

        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new PessoaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool IsPessoaFisica 
        {
            get { return PessoaJuridica == null && PessoaFisica != null;  } 
        }

        public bool IsPessoaJuridica
        {
            get { return PessoaJuridica != null && PessoaFisica == null; }
        }
    }
}
