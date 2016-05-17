using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ProprietarioConfiguration : EntityTypeConfiguration<Proprietario>
    {
        public ProprietarioConfiguration()
        {
            HasKey(p => p.ProprietarioId);

            HasRequired(p => p.Pessoa)
                .WithMany()
                .HasForeignKey(p => p.PessoaId);

            HasRequired(p => p.PessoaJuridica)
                .WithMany(pj => pj.ProprietarioList)
                .HasForeignKey(p => p.PessoaJuridicaId);

            ToTable("Proprietarios");
        }
    }
}
