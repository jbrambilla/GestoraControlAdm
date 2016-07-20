using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
            : base()
        {
            CnaeList = new List<CnaeViewModel>();
            ClienteServicoList = new List<ClienteServicoViewModel>();
            DebitoList = new List<DebitoViewModel>();
            NotaServicoList = new List<NotaServicoViewModel>();
            CodigoSegurancaList = new List<CodigoSegurancaViewModel>();
        }

        [Key]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Selecione uma Pessoa.")]
        [DisplayName("Regime de Apuração")]
        public Guid PessoaId { get; set; }

        [DisplayName("Revenda")]
        public Guid? RevendaId { get; set; }

        [Required(ErrorMessage = "Selecione um Regime de Apuração.")]
        [DisplayName("Regime de Apuração")]
        public Guid RegimeApuracaoId { get; set; }

        [Required(ErrorMessage = "Selecione um Cnae principal.")]
        [DisplayName("Cnae Principal")]
        public Guid CnaeId { get; set; }

        [Required]
        [DisplayName("Com Nota")]
        public bool ComNota { get; set; }

        [Display(Name = "Vencimento do Boleto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime VencimentoBoleto { get; set; }


        [ScaffoldColumn(false)]
        public ICollection<CnaeViewModel> CnaeList { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<ClienteServicoViewModel> ClienteServicoList { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<DebitoViewModel> DebitoList { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<NotaServicoViewModel> NotaServicoList { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<CodigoSegurancaViewModel> CodigoSegurancaList { get; set; }

        [ScaffoldColumn(false)]
        public PessoaViewModel Pessoa { get; set; }

        [ScaffoldColumn(false)]
        public RevendaViewModel Revenda { get; set; }

        [ScaffoldColumn(false)]
        public CnaeViewModel Cnae { get; set; }

        [ScaffoldColumn(false)]
        public RegimeApuracaoViewModel RegimeApuracao { get; set; }

        [ScaffoldColumn(false)]
        public string DiscriminacaoServicos { get; set; }

        [ScaffoldColumn(false)]
        public decimal ValorTotalServicos { get; set; }
    }
}
