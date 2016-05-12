using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ProfissaoViewModel
    {
        public ProfissaoViewModel()
        {
            ProfissaoId = Guid.NewGuid();
            PessoaFisicaList = new List<PessoaFisicaViewModel>();
        }

        [Key]
        public Guid ProfissaoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome da Profissão")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Nome da Profissão")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<PessoaFisicaViewModel> PessoaFisicaList { get; set; }
    }
}
