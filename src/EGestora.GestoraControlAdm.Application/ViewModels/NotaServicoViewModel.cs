using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class NotaServicoViewModel
    {
        public NotaServicoViewModel()
        {
            NotaServicoId = Guid.NewGuid();
        }

        [Key]
        public Guid NotaServicoId { get; set; }

        [Required(ErrorMessage = "Selecione a Empresa.")]
        [DisplayName("Empresa")]
        public Guid EmpresaId { get; set; }

        [Required(ErrorMessage = "Selecione o Cliente.")]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [DisplayName("Código de Verificação")]
        public string CodigoVerificacao { get; set; }

        [DisplayName("Discriminação de Serviço")]
        [Required(ErrorMessage = "O Campo Discriminação de Serviço é obrigatório.")]
        public string DiscriminacaoServico { get; set; }

        [DisplayName("Outras Informações")]
        [Required(ErrorMessage = "O Campo Outras Informações é obrigatório.")]
        public string OutrasInformacoes { get; set; }

        [DisplayName("Série")]
        public string Serie { get; set; }

        [DisplayName("Xml")]
        [ScaffoldColumn(false)]
        public string Xml { get; set; }

        [DisplayName("Nota Finalizada")]
        [ScaffoldColumn(false)]
        public bool NotaFinalizada { get; set; }

        [DisplayName("Máquina")]
        public string Maquina { get; set; }

        [DisplayName("Usuário")]
        public string Usuario { get; set; }

        [DisplayName("ISS Retiro")]
        public bool IssRetido { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        /** VALORES **/
        [DataType(DataType.Currency, ErrorMessage = "Valor em formato inválido.")]
        [DisplayName("Valor Total")]
        [Required(ErrorMessage = "Valor Total é obrigatório.")]
        public decimal ValorTotal { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valor em formato inválido.")]
        [DisplayName("Valor das Deduções")]
        [Required(ErrorMessage = "Valor das Deduções é obrigatório.")]
        public decimal ValorDeducoes { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valor em formato inválido.")]
        [DisplayName("Alíquota")]
        [Required(ErrorMessage = "Alíquota é obrigatória.")]
        public decimal Aliquota { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valor em formato inválido.")]
        [DisplayName("Base de Cálculo")]
        [Required(ErrorMessage = "Base de Cálculo é obrigatório.")]
        public decimal BaseCalculo { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valor em formato inválido.")]
        [DisplayName("Valor ISS")]
        [Required(ErrorMessage = "Valor ISS é obrigatório.")]
        public decimal ValorISS { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valor em formato inválido.")]
        [DisplayName("Valor Líquido")]
        [Required(ErrorMessage = "Valor Líquido é obrigatório.")]
        public decimal ValorLiquido { get; set; }

        [ScaffoldColumn(false)]
        public EmpresaViewModel Empresa { get; set; }

        [ScaffoldColumn(false)]
        public ClienteViewModel Cliente { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
