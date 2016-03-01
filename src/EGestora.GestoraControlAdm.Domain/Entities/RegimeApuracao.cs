using System;
using System.Collections.Generic;
namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class RegimeApuracao
    {
        public RegimeApuracao()
        {
            RegimeApuracaoId = Guid.NewGuid();
            ClienteList = new List<Cliente>();
            EmpresaList = new List<Empresa>();
        }

        public Guid RegimeApuracaoId { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Cliente> ClienteList { get; set; }
        public virtual ICollection<Empresa> EmpresaList { get; set; }

        public string Display
        {
            get { return Codigo + " - " + Descricao; }
        }
    }
}
