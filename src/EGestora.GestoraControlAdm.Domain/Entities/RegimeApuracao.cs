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
        }

        public Guid RegimeApuracaoId { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public ICollection<Cliente> ClienteList { get; set; }
    }
}
