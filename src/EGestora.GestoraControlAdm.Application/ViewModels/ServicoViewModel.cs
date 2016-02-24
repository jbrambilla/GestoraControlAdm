using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ServicoViewModel
    {
        public ServicoViewModel()
        {
            ServicoId = Guid.NewGuid();
        }

        [Key]
        public Guid ServicoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Preencha um valor monetário.")]
        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }
    }
}
