using DomainValidation.Validation;
using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Cliente : Pessoa
    {
        public bool ComNota { get; set; }
        public DateTime VencimentoBoleto { get; set; }
    }
}
