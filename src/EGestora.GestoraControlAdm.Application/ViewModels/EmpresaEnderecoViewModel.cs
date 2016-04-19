﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EGestora.GestoraControlAdm.Application.ViewModels
{
    public class EmpresaEnderecoViewModel : PessoaEnderecoViewModel
    {
        public EmpresaEnderecoViewModel()
            : base()
        {
            CnaeList = new List<CnaeViewModel>();
            SelectedCnaeList = new List<Guid>();
        }

        [Required(ErrorMessage = "Selecione um Cnae principal.")]
        [DisplayName("Cnae Principal")]
        public Guid CnaeId { get; set; }

        [Required(ErrorMessage = "Seleciona o Regime de Apuração.")]
        [DisplayName("Regime de Apuração")]
        public Guid RegimeApuracaoId { get; set; }

        [Required(ErrorMessage = "Seleciona o Regime de Tributação.")]
        [DisplayName("Regime de Tributação")]
        public Guid RegimeTributacaoId { get; set; }

        [Required(ErrorMessage = "Seleciona a Natureza da Operação.")]
        [DisplayName("Natureza da Operação")]
        public Guid NaturezaOperacaoId { get; set; }

        [Required(ErrorMessage = "Seleciona o Enquadramento de Serviço.")]
        [DisplayName("Enquadramento de Serviço")]
        public Guid EnquadramentoServicoId { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Preencha um valor monetário.")]
        [DisplayName("Valor")]
        public decimal Aliquota { get; set; }

        [Required(ErrorMessage = "Preencha o campo Login ISS")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Login ISS")]
        public string LoginIss { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha ISS")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Senha ISS")]
        public string SenhaIss { get; set; }

        [Required(ErrorMessage = "Preencha o campo WebService de Homologacao")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("WebService de Homologacao")]
        public string WebServiceHomologacao { get; set; }

        [Required(ErrorMessage = "Preencha o campo WebService de Producao")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("WebService de Producao")]
        public string WebServiceProducao { get; set; }

        [Required]
        [DisplayName("Optante Simples Nacional")]
        public bool OptanteSimplesNacional { get; set; }

        [ScaffoldColumn(false)]
        public ICollection<CnaeViewModel> CnaeList { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<Guid> SelectedCnaeList { get; set; }
    }
}
