using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Revenda : Pessoa
    {
        public Revenda()
        {
            ClienteList = new List<Cliente>();
        }

        public virtual ICollection<Cliente> ClienteList { get; set; }
    }
}
