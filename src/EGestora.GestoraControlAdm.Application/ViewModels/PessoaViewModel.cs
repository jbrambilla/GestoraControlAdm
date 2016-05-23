using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            PessoaId = Guid.NewGuid();
            EnderecoList = new List<EnderecoViewModel>();
            AnexoList = new List<AnexoViewModel>();
            ContatoList = new List<ContatoViewModel>();
            Ativo = true;
        }

        [Key]
        public Guid PessoaId { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase Foto { get; set; }

        [Required(ErrorMessage = "Preencha o campo Observação")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public bool IsPessoaJuridica { get; set; }

        [ScaffoldColumn(false)]
        public bool IsPessoaFisica { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }

        [ScaffoldColumn(false)]
        public PessoaFisicaViewModel PessoaFisica { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<EnderecoViewModel> EnderecoList { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<ContatoViewModel> ContatoList { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<AnexoViewModel> AnexoList { get; set; }

        [ScaffoldColumn(false)]
        public FuncionarioViewModel Funcionario { get; set; }

        [ScaffoldColumn(false)]
        public ProprietarioViewModel Proprietario { get; set; }
    }
}
