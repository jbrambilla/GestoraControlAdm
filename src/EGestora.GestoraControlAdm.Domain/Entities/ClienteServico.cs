using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Validations.ClienteServicos;
using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class ClienteServico
    {
        public ClienteServico()
        {
            ClienteServicoId = Guid.NewGuid();
        }

        public Guid ClienteServicoId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid ServicoId { get; set; }
        public decimal Valor { get; set; }
        public bool Faturar { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Servico Servico { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new ClienteServicoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
