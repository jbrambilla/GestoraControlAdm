using System;
namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Proprietario
    {
        public Proprietario()
        {
            ProprietarioId = Guid.NewGuid();
        }

        public Guid ProprietarioId { get; set; }
        public Guid PessoaId { get; set; }
        public Guid PessoaJuridicaId { get; set; }
        public decimal PorcentagemParticipacao { get; set; }
        public Pessoa Pessoa { get; set; }
        public PessoaJuridica PessoaJuridica { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }

    }
}
