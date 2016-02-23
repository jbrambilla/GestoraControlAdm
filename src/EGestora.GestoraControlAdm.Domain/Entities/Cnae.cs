using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Cnae
    {
        public Cnae()
        {
            CnaeId = Guid.NewGuid();
        }

        public Guid CnaeId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Pessoa> PessoaList { get; set; }
    }
}
