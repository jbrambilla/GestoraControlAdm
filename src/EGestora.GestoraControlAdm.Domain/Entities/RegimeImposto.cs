
using System;
using System.Collections.Generic;
namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class RegimeImposto
    {
        public RegimeImposto()
        {
            RegimeImpostoId = Guid.NewGuid();
            PessoaJuridicaList = new List<PessoaJuridica>();
        }

        public Guid RegimeImpostoId { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<PessoaJuridica> PessoaJuridicaList { get; set; }
    }
}
