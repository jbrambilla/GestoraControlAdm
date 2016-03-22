using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class BoletoViewModel
    {
        public BoletoViewModel()
        {
            BoletoId = Guid.NewGuid();
        }

        [Key]
        public Guid BoletoId { get; set; }

        [Required(ErrorMessage = "Debito é obrigatório")]
        [DisplayName("Débito")]
        public Guid DebitoId { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Preencha um valor monetário.")]
        [DisplayName("Valor")]
        [Required]
        public decimal Valor { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Vencimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public DebitoViewModel Debito { get; set; }
    }
}
