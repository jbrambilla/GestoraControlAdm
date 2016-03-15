using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Contato
    {
        public Contato()
        {
            ContatoId = Guid.NewGuid();
        }

        public Guid ContatoId { get; set; }
        public Guid PessoaId { get; set; }
        public string Tipo { get; set; }
        public string InformacaoContato { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
