using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ProprietarioViewModel
    {
        public ProprietarioViewModel()
        {
            ProprietarioId = Guid.NewGuid();
        }

        [Key]
        public Guid ProprietarioId { get; set; }

        [Required(ErrorMessage = "Selecione uma pessoa")]
        [DisplayName("Pessoa")]
        public Guid PessoaId { get; set; }

        [Required(ErrorMessage = "Selecione uma pessoa juridica")]
        [DisplayName("Pessoa Juridica")]
        public Guid PessoaJuridicaId { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valor em formato inválido.")]
        [DisplayName("% de Participação")]
        [Required(ErrorMessage = "A % de participação é obrigatória.")]
        public decimal PorcentagemParticipacao { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa { get; set; }

        [ScaffoldColumn(false)]
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }
    }
}
