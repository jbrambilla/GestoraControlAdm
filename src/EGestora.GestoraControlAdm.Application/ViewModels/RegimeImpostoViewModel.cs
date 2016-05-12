using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class RegimeImpostoViewModel
    {
        public RegimeImpostoViewModel()
        {
            RegimeImpostoId = Guid.NewGuid();
            PessoaJuridicaList = new List<PessoaJuridicaViewModel>();
        }

        [Key]
        public Guid RegimeImpostoId { get; set; }

        [Required(ErrorMessage="Preencha o campo Descrição")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<PessoaJuridicaViewModel> PessoaJuridicaList { get; set; }
    }
}
