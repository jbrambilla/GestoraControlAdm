using System;
using System.Linq;
using System.Collections.Generic;
using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Validations.LoteFaturamentos;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class LoteFaturamento
    {
        public LoteFaturamento()
        {
            LoteFaturamentoId = Guid.NewGuid();
            ClienteList = new List<Cliente>();
        }

        public Guid LoteFaturamentoId { get; set; }
        public DateTime Referencia { get; set; }
        public DateTime? DataFechamento { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public decimal ValorTotalSemNota
        {
            get
            {
                var valor = 0M;
                ClienteList.Where(c => !c.ComNota).ToList().ForEach(c => valor += c.ValorTotalServicos);
                return valor;
            }
        }

        public decimal ValorTotalComNota
        {
            get
            {
                var valor = 0M;
                ClienteList.Where(c => c.ComNota).ToList().ForEach(c => valor += c.ValorTotalServicos);
                return valor;
            }
        }

        public decimal ValorTotalGeral
        {
            get
            {
                return ValorTotalSemNota + ValorTotalComNota;
            }
        }

        public virtual ICollection<Cliente> ClienteList { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new LoteFaturamentoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
