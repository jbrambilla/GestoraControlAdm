using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class PessoaJuridica
    {
        public PessoaJuridica()
        {
            PessoaId = Guid.NewGuid();
            CnaeList = new List<Cnae>();
            FuncionarioList = new List<Funcionario>();
        }

        public Guid PessoaId { get; set; }
        public Guid RegimeImpostoId { get; set; }
        public Guid CnaeId { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public DateTime DataFundacao { get; set; }
        public DateTime DataAniversario { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual RegimeImposto RegimeImposto { get; set; }
        public virtual Cnae Cnae { get; set; }
        public virtual ICollection<Cnae> CnaeList { get; set; }
        public virtual ICollection<Funcionario> FuncionarioList { get; set; }
        public virtual ICollection<Proprietario> ProprietarioList { get; set; }
    }
}
