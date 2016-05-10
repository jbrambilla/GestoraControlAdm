using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class TipoContatoViewModel
    {
        public TipoContatoViewModel()
        {
            TipoContatoId = Guid.NewGuid();
            ContatoList = new List<ContatoViewModel>();
        }

        [Key]
        public Guid TipoContatoId { get; set; }

        public string Nome { get; set; }

        [DisplayName("Máscara")]
        public string Mascara { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<ContatoViewModel> ContatoList { get; set; }
    }
}
