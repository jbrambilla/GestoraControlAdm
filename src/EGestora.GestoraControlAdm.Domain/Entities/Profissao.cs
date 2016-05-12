using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Profissao
    {
        public Profissao()
        {
            ProfissaoId = Guid.NewGuid();
            PessoaFisicaList = new List<PessoaFisica>();
        }

        public Guid ProfissaoId { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<PessoaFisica> PessoaFisicaList { get; set; }
    }
}
