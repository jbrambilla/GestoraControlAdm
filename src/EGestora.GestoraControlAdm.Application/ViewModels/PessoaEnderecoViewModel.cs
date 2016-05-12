using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class PessoaEnderecoViewModel
    {

        public PessoaEnderecoViewModel()
        {
            PessoaId = Guid.NewGuid();
            EnderecoId = Guid.NewGuid();
            ContatoId = Guid.NewGuid();
            Ativo = true;
        }

        //Pessoa

        [Key]
        public Guid PessoaId { get; set; }

        [Required]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase Foto { get; set; }

        [DisplayName("Lista de Anexos")]
        public IEnumerable<HttpPostedFileBase> Anexos { get; set; }

        [Required(ErrorMessage = "Preencha o campo Observação")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Observação")]
        public string Observacao { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CriadoEm { get; set; }

        [ScaffoldColumn(false)]
        public DateTime AlteradoEm { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        //Pessoa Jurídica

        //[Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Razão Social")]
        public string RazaoSocial { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Nome Fantasia")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Nome Fantasia")]
        public string NomeFantasia { get; set; }

        //[Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(18, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("CNPJ")]
        public string Cnpj { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Inscrição Municipal")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Inscrição Municipal")]
        public string InscricaoMunicipal { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Inscrição Estadual")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Display(Name = "Data de Fundação")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataFundacao { get; set; }

        [Display(Name = "Data de Aniversário")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataAniversario { get; set; }

        [Required(ErrorMessage = "Selecione um Regime de Imposto")]
        [DisplayName("Regime de Imposto")]
        public Guid RegimeImpostoId { get; set; }

        [Required(ErrorMessage = "Selecione um Cnae principal.")]
        [DisplayName("Cnae Principal")]
        public Guid CnaeId { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<Guid> SelectedCnaeList { get; set; }

        //Pessoa Física

        //[Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Apelido")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Apelido { get; set; }

        //[Required(ErrorMessage = "Preencha o campo RG")]
        [MaxLength(12, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("RG")]
        public string Rg { get; set; }

        //[Required(ErrorMessage = "Preencha o campo Orgão Emissor")]
        [MaxLength(12, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Orgão Emissor")]
        public string OrgaoEmissor { get; set; }

        //[Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        //[Required(ErrorMessage = "Selecione um Gênero")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Gênero")]
        public string Genero { get; set; }

        //[Required(ErrorMessage = "Selecione um Estado Civil")]
        [MaxLength(14, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Estado Civil")]
        public string EstadoCivil { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Nascimento { get; set; }

        //Endereço

        [Key]
        public Guid EnderecoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Preencha o campo Numero")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "Preencha o campo Complemento")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Preencha o campo CEP")]
        [MaxLength(9, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(9, ErrorMessage = "Mínimo {1} caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Preencha o campo Estado")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Estado { get; set; }

        [DisplayName("Cobrança")]
        public bool Cobranca { get; set; }

        [DisplayName("Entrega")]
        public bool Entrega { get; set; }

        [DisplayName("Principal")]
        public bool Principal { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        //Contato

        [Key]
        public Guid ContatoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Descrição")]
        public string DescricaoContato { get; set; }

        [Required(ErrorMessage = "Preencha o campo Contato")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        [DisplayName("Contato")]
        public string InformacaoContato { get; set; }

        [Required(ErrorMessage = "Selecione o Tipo de Contato")]
        [DisplayName("Tipo do Contato")]
        public Guid TipoContatoId { get; set; }

        //extra not in database
        public bool FlagIsPessoaJuridica { get; set; }
    }
}
