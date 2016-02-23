using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class CnaeViewModel
    {
        public CnaeViewModel()
        {
            CnaeId = Guid.NewGuid();
        }

        [Key]
        public Guid CnaeId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {2} caracteres")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {2} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}
