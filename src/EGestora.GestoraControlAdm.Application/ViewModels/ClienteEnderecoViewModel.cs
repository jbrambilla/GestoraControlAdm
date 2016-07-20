using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ClienteEnderecoViewModel : PessoaEnderecoViewModel
    {
        public ClienteEnderecoViewModel()
            : base()
        {
        }

        [Required]
        [DisplayName("Com Nota")]
        public bool ComNota { get; set; }

        [Display(Name = "Data do Vencimento do Boleto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime VencimentoBoleto { get; set; }

        [DisplayName("Revenda")]
        public Guid? RevendaId { get; set; }

        [Required(ErrorMessage = "Selecione um Regime de Apuração.")]
        [DisplayName("Regime de Apuração")]
        public Guid RegimeApuracaoId { get; set; }
    }
}
