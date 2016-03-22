using DomainValidation.Validation;
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

        public List<decimal> ValorParcelaList
        {
            get
            {
                var valorParcelaList = new List<decimal>();
                var dizima = ((ValorLiquido / Parcelas) * 100)/100;
                var valorParcela = Math.Round(dizima, 2);
                var somaParcela = valorParcela * Parcelas;
                var diferencaPrimeiraParcela = ValorLiquido - somaParcela;
                valorParcelaList.Add(valorParcela + diferencaPrimeiraParcela);
                for (int i = 1; i < Parcelas; i++ )
                {
                    valorParcelaList.Add(valorParcela);
                }

                return valorParcelaList;
            }
        }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new DebitoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

