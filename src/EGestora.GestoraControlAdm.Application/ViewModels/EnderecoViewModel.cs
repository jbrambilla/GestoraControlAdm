using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            EnderecoId = Guid.NewGuid();
        }

        [Key]
        public Guid EnderecoId { get; set; }

        [ScaffoldColumn(false)]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Numero")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Complemento")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(9, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(9, ErrorMessage = "Mínimo {1} caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Estado { get; set; }

        [DisplayName("Cobrança")]
        public bool Cobranca { get; set; }

        [DisplayName("Entrega")]
        public bool Entrega { get; set; }

        [DisplayName("Principal")]
        public bool Principal { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        [ScaffoldColumn(false)]
        public string EnderecoCompleto
        {
            get
            {
                return string.Format("{0}, {1} {2} - {3} | {4} - {5}", Logradouro, Numero, Complemento, Bairro, Cidade, Estado);
            }
            private set { }
        }
    }
}
