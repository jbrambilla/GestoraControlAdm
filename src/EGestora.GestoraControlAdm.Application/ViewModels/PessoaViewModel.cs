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
        }

        [Key]
        public Guid PessoaId { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase Foto { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
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
        public virtual PessoaJuridicaViewModel PessoaJuridica { get; set; }

        [ScaffoldColumn(false)]
        public virtual PessoaFisicaViewModel PessoaFisica { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<EnderecoViewModel> EnderecoList { get; set; }
    }
}
