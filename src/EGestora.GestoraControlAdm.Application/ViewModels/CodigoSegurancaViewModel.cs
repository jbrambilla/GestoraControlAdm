using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class CodigoSegurancaViewModel
    {
        public CodigoSegurancaViewModel()
        {
            CodigoSegurancaId = Guid.NewGuid();
            Gerar = new List<string>();
        }

        [Key]
        public Guid CodigoSegurancaId { get; set; }

        [Required]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [DisplayName("Código")]
        [MaxLength(12, ErrorMessage="O Código deve ter no máximo {1} caracteres.")]
        [MinLength(12, ErrorMessage = "O Código deve ter no mínimo {1} caracteres.")]
        public string Codigo { get; set; }

        [Display(Name = "Data da Trava")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataTrava { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Criado Em")]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public ClienteViewModel Cliente { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        //Guids dos clientes selecionados
        [ScaffoldColumn(false)]
        public virtual ICollection<string> Gerar { get; set; }

        //Numero de códigos gerados nesse request
        [ScaffoldColumn(false)]
        public int QuantidadeGerada { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Enviar Por E-mail")]
        public bool EnviarEmail { get; set; }
    }
}
