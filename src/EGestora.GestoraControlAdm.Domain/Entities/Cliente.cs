using DomainValidation.Validation;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public Cliente()
            : base()
        {
            CnaeList = new List<Cnae>();
            ClienteServicoList = new List<ClienteServico>();
        }

        public bool ComNota { get; set; }
        public DateTime VencimentoBoleto { get; set; }
        public virtual ICollection<Cnae> CnaeList { get; set; }
        public virtual ICollection<ClienteServico> ClienteServicoList { get; set; }
    }
}
