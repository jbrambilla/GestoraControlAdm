using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class RevendaViewModel : PessoaViewModel
    {
        public RevendaViewModel()
            : base()
        {
        }

        public ICollection<ClienteViewModel> ClienteList { get; set; }
    }
}
