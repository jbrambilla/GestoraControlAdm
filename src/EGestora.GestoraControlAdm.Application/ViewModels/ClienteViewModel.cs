using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ClienteViewModel : PessoaViewModel
    {
        public ClienteViewModel()
            : base()
        {
        }
       
        [Required]
        [DisplayName("Com Nota")]
        public bool ComNota { get; set; }

        [Display(Name = "Vencimento do Boleto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime VencimentoBoleto { get; set; }
    }
}
