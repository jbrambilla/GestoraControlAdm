using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class DebitoViewModel
    {
        public DebitoViewModel()
        {
            DebitoId = Guid.NewGuid();
        }

        [Key]
        public Guid DebitoId { get; set; }

        [Required(ErrorMessage="Selecione um Cliente.")]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor.")]
        [DataType(DataType.Currency, ErrorMessage = "Preencha um valor monetário.")]
        [DisplayName("Valor")]
        public decimal ValorLiquido { get; set; }

        [Required(ErrorMessage = "Preencha o campo Detalhes")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Detalhes")]
        public string Detalhes { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código de Segurança")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Código de Segurança")]
        public string CodigoSeguranca { get; set; }

        [Required(ErrorMessage="Selecione um número de parcelas.")]
        public int Parcelas { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Vencimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public ClienteViewModel Cliente { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<BoletoViewModel> BoletoList { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
