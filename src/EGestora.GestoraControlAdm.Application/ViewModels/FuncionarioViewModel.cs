using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        public FuncionarioViewModel()
        {
            FuncionarioId = Guid.NewGuid();
        }

        [Key]
        public Guid FuncionarioId { get; set; }

        [Required(ErrorMessage="Selecione uma pessoa")]
        [DisplayName("Pessoa")]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Selecione uma pessoa juridica")]
        [DisplayName("Pessoa Juridica")]
        public Guid PessoaJuridicaId { get; set; }

        [Required(ErrorMessage="Selecione um cargo")]
        [DisplayName("Cargo")]
        public Guid CargoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa { get; set; }

        [ScaffoldColumn(false)]
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }

        [ScaffoldColumn(false)]
        public CargoViewModel Cargo { get; set; }
    }
}
