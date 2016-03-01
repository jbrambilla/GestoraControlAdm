using System;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Anexo
    {
        public Anexo()
        {
            AnexoId = Guid.NewGuid();
        }

        public Guid AnexoId { get; set; }
        public Guid PessoaId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
