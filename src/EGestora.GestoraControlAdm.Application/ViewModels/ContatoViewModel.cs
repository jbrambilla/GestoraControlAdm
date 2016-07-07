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

        [Required]
        [ScaffoldColumn(false)]
        [DisplayName("Tipo do Contato")]
        public Guid TipoContatoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição para o contato")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Descrição")]
        public string DescricaoContato { get; set; }

        [Required(ErrorMessage = "Preencha o campo Contato")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Contato")]
        public string InformacaoContato { get; set; }

        public bool Newsletter { get; set; }

        public bool Nfse { get; set; }

        public bool Boleto { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa { get; set; }

        [ScaffoldColumn(false)]
        public TipoContatoViewModel TipoContato { get; set; }
    }
}
