using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ContatoViewModel
    {
        public ContatoViewModel()
        {
            ContatoId = Guid.NewGuid();
        }

        [Key]
        public Guid ContatoId { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo de contato")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Tipo de contato")]
        public string TipoContato { get; set; }

        [Required(ErrorMessage = "Preencha o campo Contato")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Contato")]
        public string InformacaoContato { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa { get; set; }
    }
}
