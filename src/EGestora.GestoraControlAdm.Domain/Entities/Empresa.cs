using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Empresa : Pessoa
    {
        public Empresa()
            : base()
        {
            CnaeList = new List<Cnae>();
            FuncionarioList = new List<Funcionario>();
            NotaServicoList = new List<NotaServico>();
        }

        public Guid RegimeApuracaoId { get; set; }
        public Guid RegimeTributacaoId { get; set; }
        public Guid NaturezaOperacaoId { get; set; }
        public Guid EnquadramentoServicoId { get; set; }
        public Guid CnaeId { get; set; }
        public decimal Aliquota { get; set; }
        public string LoginIss { get; set; }
        public string SenhaIss { get; set; }
        public string WebServiceHomologacao { get; set; }
        public string WebServiceProducao { get; set; }
        public bool OptanteSimplesNacional { get; set; }

        public virtual Cnae Cnae { get; set; }
        public virtual RegimeApuracao RegimeApuracao { get; set; }
        public virtual RegimeTributacao RegimeTributacao { get; set; }
        public virtual NaturezaOperacao NaturezaOperacao { get; set; }
        public virtual EnquadramentoServico EnquadramentoServico { get; set; }
        public virtual ICollection<Funcionario> FuncionarioList { get; set; }
        public virtual ICollection<Cnae> CnaeList { get; set; }
        public virtual ICollection<NotaServico> NotaServicoList { get; set; }
    }
}
