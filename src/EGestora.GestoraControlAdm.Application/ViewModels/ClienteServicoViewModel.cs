using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ClienteServicoViewModel
    {
        public ClienteServicoViewModel()
        {
            ClienteServicoId = Guid.NewGuid();
        }

        [Key]
        public Guid ClienteServicoId { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Preencha um valor monetário.")]
        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        public bool Faturar { get; set; }

        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Selecione um Serviço")]
        [DisplayName("Serviço")]
        public Guid ServicoId { get; set; }

        [ScaffoldColumn(false)]
        public ClienteViewModel Cliente { get; set; }

        [ScaffoldColumn(false)]
        public ServicoViewModel Servico { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }
    }
}
