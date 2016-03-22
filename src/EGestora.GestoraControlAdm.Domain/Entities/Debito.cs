﻿using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Validations.Debitos;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Debito
    {
        public Debito()
        {
            DebitoId = Guid.NewGuid();
            BoletoList = new List<Boleto>();
        }

        public Guid DebitoId { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorLiquido { get; set; }
        public string Detalhes { get; set; }
        public string CodigoSeguranca { get; set; }
        public int Parcelas { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Boleto> BoletoList { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new DebitoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
