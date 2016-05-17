using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class PessoaJuridicaViewModel
    {
        [Key]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Selecione um Regime de Imposto")]
        [DisplayName("Regime de Imposto")]
        public Guid RegimeImpostoId { get; set; }

        [Required(ErrorMessage = "Selecione um Cnae Principal")]
        [DisplayName("Cnae Principal")]
        public Guid CnaeId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(18, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Preencha o campo Inscrição Municipal")]
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        [Required(ErrorMessage = "Preencha o campo Inscrição Estadual")]
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Data de Fundação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataFundacao { get; set; }

        [Display(Name = "Data de Aniversário")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAniversario { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa;

        [ScaffoldColumn(false)]
        public virtual RegimeImpostoViewModel RegimeImposto { get; set; }

        [ScaffoldColumn(false)]
        public virtual CnaeViewModel Cnae { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<CnaeViewModel> CnaeList { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<FuncionarioViewModel> FuncionarioList { get; set; }
    }
}
