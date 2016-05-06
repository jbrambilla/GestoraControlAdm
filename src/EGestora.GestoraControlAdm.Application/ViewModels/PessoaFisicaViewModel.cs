using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class PessoaFisicaViewModel
    {
        [Key]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Apelido")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Preencha o campo RG")]
        [MaxLength(12, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("RG")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(18, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Selecione um Gênero")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Gênero")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Selecione um Estado Civil")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Nascimento { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa;
    }
}
