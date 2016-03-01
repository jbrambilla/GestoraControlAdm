using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class EnquadramentoServico
    {
        public EnquadramentoServico()
        {
            EnquadramentoServicoId = Guid.NewGuid();
            EmpresaList = new List<Empresa>();
        }

        public Guid EnquadramentoServicoId { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Empresa> EmpresaList { get; set; }
    }
}
