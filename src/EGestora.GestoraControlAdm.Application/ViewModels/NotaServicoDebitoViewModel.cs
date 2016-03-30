using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class NotaServicoDebitoViewModel
    {
        public NotaServicoDebitoViewModel()
        {
            NotaServicoId = Guid.NewGuid();
            DebitoId = Guid.NewGuid();
        }

        [Key]
        public Guid NotaServicoId { get; set; }

        [Required(ErrorMessage = "Selecione a Empresa.")]
        [DisplayName("Empresa")]
        public Guid EmpresaId { get; set; }

        [Required(ErrorMessage = "Selecione o Cliente.")]
        [DisplayName("Cliente")]
        public Guid ClienteId { get; set; }

        [DisplayName("Discriminação de Serviço")]
        [Required(ErrorMessage = "O Campo Discriminação de Serviço é obrigatório.")]
        public string DiscriminacaoServico { get; set; }

        [DisplayName("Outras Informações")]
        [Required(ErrorMessage = "O Campo Outras Informações é obrigatório.")]
        public string OutrasInformacoes { get; set; }

        [DisplayName("Máquina")]
        public string Maquina { get; set; }

        [DisplayName("Usuário")]
        public string Usuario { get; set; }

        [DisplayName("ISS Retido")]
        public bool IssRetido { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Emissão")]
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

        // DEBITO

        [Key]
        public Guid DebitoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Detalhes")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Detalhes")]
        public string Detalhes { get; set; }

        [Required(ErrorMessage = "Selecione um número de parcelas.")]
        public int Parcelas { get; set; }

        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Vencimento { get; set; }


        //Não estao no banco de dados

        [ScaffoldColumn(false)]
        [DisplayName("Emitir Nota")]
        public bool Emitir { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Enviar Por E-mail")]
        public bool EnviarEmail { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Imprimir")]
        public bool Imprimir { get; set; }

        [ScaffoldColumn(false)]
        public byte[] PdfNfse { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }
    }
}
