using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class NaturezaOperacao
    {
        public NaturezaOperacao()
        {
            NaturezaOperacaoId = Guid.NewGuid();
            EmpresaList = new List<Empresa>();
        }
        
        public Guid NaturezaOperacaoId { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Empresa> EmpresaList { get; set; }
    }
}
