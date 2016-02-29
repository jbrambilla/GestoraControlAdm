using System;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class FuncionarioViewModel : PessoaViewModel
    {
        public FuncionarioViewModel()
            : base()
        {
        }

        [Required]
        public Guid EmpresaId { get; set; }

        public EmpresaViewModel Empresa { get; set; }
    }
}
