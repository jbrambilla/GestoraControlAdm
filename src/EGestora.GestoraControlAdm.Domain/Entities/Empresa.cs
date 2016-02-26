using System;
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
        }

        public decimal Aliquota { get; set; }
        public string LoginIss { get; set; }
        public string SenhaIss { get; set; }
        public string WebServiceHomologacao { get; set; }
        public string WebServiceProducao { get; set; }
        public bool OptanteSimplesNacional { get; set; }

        public virtual ICollection<Funcionario> FuncionarioList { get; set; }
        public virtual ICollection<Cnae> CnaeList { get; set; }
    }
}
