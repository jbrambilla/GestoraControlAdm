using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Validations.CodigoSegurancas;
using System;
namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class CodigoSeguranca
    {
        public CodigoSeguranca()
        {
            CodigoSegurancaId = Guid.NewGuid();
        }

        public Guid CodigoSegurancaId { get; set; }
        public Guid ClienteId { get; set; }
        public string Codigo { get; set; }
        public DateTime DataTrava { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual Cliente Cliente { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new CodigoSegurancaEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
