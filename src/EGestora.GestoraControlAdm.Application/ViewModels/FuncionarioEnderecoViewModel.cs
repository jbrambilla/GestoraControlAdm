using System;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class FuncionarioEnderecoViewModel : PessoaEnderecoViewModel
    {
        public FuncionarioEnderecoViewModel()
            : base()
        {
            
        }

        [Required]
        public Guid EmpresaId { get; set; }
    }
}
