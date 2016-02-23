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
        }

        public bool ComNota { get; set; }
        public DateTime VencimentoBoleto { get; set; }
        public virtual ICollection<Cnae> CnaeList { get; set; }
    }
}
