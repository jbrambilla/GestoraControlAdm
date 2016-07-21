using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Empresa
    {
        public Empresa()
        {
            EmpresaId = Guid.NewGuid();
            NotaServicoList = new List<NotaServico>();
        }

        public Guid EmpresaId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid RegimeApuracaoId { get; set; }
        public Guid RegimeTributacaoId { get; set; }
        public Guid NaturezaOperacaoId { get; set; }
        public Guid EnquadramentoServicoId { get; set; }
        public decimal Aliquota { get; set; }
        public string LoginIss { get; set; }
        public string SenhaIss { get; set; }
        public string WebServiceHomologacao { get; set; }
        public string WebServiceProducao { get; set; }
        public bool OptanteSimplesNacional { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual RegimeApuracao RegimeApuracao { get; set; }
        public virtual RegimeTributacao RegimeTributacao { get; set; }
        public virtual NaturezaOperacao NaturezaOperacao { get; set; }
        public virtual EnquadramentoServico EnquadramentoServico { get; set; }
        public virtual ICollection<NotaServico> NotaServicoList { get; set; }

        public string Nome
        {
            get
            {
                if (Pessoa == null)
                    return "";
                return Pessoa.IsPessoaFisica ? Pessoa.PessoaFisica.Nome : Pessoa.PessoaJuridica.RazaoSocial;
            }
        }
    }
}
