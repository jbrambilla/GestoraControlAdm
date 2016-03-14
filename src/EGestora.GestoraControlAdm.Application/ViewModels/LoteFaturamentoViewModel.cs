using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class LoteFaturamentoViewModel
    {
        public LoteFaturamentoViewModel()
        {
            LoteFaturamentoId = Guid.NewGuid();
            ClienteList = new List<ClienteViewModel>();
            Faturar = new List<string>();
        }

        [Key]
        public Guid LoteFaturamentoId { get; set; }

        [Display(Name = "Data de Referência")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Referencia { get; set; }

        [Display(Name = "Data do Fechamento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataFechamento { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Criação")]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "Data de Alteração")]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Valor Total Sem Nota")]
        [DataType(DataType.Currency)]
        public decimal ValorTotalSemNota { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Valor Total Com Nota")]
        [DataType(DataType.Currency)]
        public decimal ValorTotalComNota { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Valor Total")]
        [DataType(DataType.Currency)]
        public decimal ValorTotalGeral { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<ClienteViewModel> ClienteList { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        //Guids dos clientes selecionados
        [ScaffoldColumn(false)]
        public virtual ICollection<string> Faturar { get; set; }
    }
}
