using System;
using System.Collections.Generic;
namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class TipoContato
    {
        public TipoContato()
        {
            TipoContatoId = Guid.NewGuid();
            ContatoList = new List<Contato>();
        }

        public Guid TipoContatoId { get; set; }
        public string Nome { get; set; }
        public string Mascara { get; set; }
        public virtual ICollection<Contato> ContatoList { get; set; }
    }
}
