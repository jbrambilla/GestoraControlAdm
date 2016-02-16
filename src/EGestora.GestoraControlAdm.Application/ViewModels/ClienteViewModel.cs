using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            ClienteId = Guid.NewGuid();
        }

        [Key]
        public Guid ClienteId { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public Guid PessoaJuridicaId { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        public bool ComNota { get; set; }

        [Display(Name = "Data do Vencimento do Boleto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime VencimentoBoleto { get; set; }

        [ScaffoldColumn(false)]
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }
    }
}
