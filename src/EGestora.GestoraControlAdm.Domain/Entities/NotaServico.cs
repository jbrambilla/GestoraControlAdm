using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Validations.NotaServicos;
using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class NotaServico
    {
        public NotaServico()
        {
            NotaServicoId = Guid.NewGuid();
        }

        public Guid NotaServicoId { get; set; }
        public string Numero { get; set; }
        public string CodigoVerificacao { get; set; }
        public string DiscriminacaoServico { get; set; }
        public string OutrasInformacoes { get; set; }
        public string Serie { get; set; }
        public string Xml { get; set; }
        public bool NotaFinalizada { get; set; }
        public string Maquina { get; set; }
        public string Usuario { get; set; }
        public bool IssRetido { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        /** VALORES **/
        public decimal ValorTotal { get; set; }
        public decimal ValorDeducoes { get; set; }
        public decimal Aliquota { get; set; }
        public decimal BaseCalculo { get; set; }
        public decimal ValorISS { get; set; }
        public decimal ValorLiquido { get; set; }

        /** RELACIONAMENTOS **/
        public Guid EmpresaId { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Cliente Cliente { get; set; }

        /** NÃO ESTÃO NO BANCO DE DADOS **/
        public bool Emitir { get; set; }
        public bool EnviarEmail { get; set; }
        public byte[] PdfNfse { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public bool IsValid()
        {
            ValidationResult = new NotaServicoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void CalcularValores()
        {
            if (Cliente != null && Empresa != null)
            {
                ValorTotal = Cliente.ValorTotalServicos;
                ValorDeducoes = 0;
                Aliquota = Empresa.Aliquota;
                BaseCalculo = ValorTotal;
                ValorISS = BaseCalculo * (Aliquota / 100);
                ValorLiquido = ValorTotal - ValorISS;
            }
            else
            {
                ValorTotal = 0;
                ValorDeducoes = 0;
                Aliquota = 0;
                BaseCalculo = 0;
                ValorISS = 0;
                ValorLiquido = 0;
            }

        }

    }
}
