using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Validations.Clientes;
using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Cliente
    {
        public Cliente()
        {
            ClienteId = Guid.NewGuid();
        }

        public Guid ClienteId { get; set; }
        public Guid PessoaJuridicaId { get; set; }
        public bool Ativo { get; set; }
        public string Email { get; set; }
        public bool ComNota { get; set; }
        public DateTime VencimentoBoleto { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }

        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public ValidationResult ValidationResult { get; set; }
        public bool IsValid()
        {
            ValidationResult = new ClienteEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
