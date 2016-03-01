using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class RegimeApuracaoViewModel
    {
        public RegimeApuracaoViewModel()
        {
            RegimeApuracaoId = Guid.NewGuid();
            ClienteList = new List<ClienteViewModel>();
            EmpresaList = new List<EmpresaViewModel>();
        }

        [Key]
        public Guid RegimeApuracaoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Código")]
        [DisplayName("Código")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<ClienteViewModel> ClienteList { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<EmpresaViewModel> EmpresaList { get; set; }

        [ScaffoldColumn(false)]
        public string Display { get; set; }
    }
}
