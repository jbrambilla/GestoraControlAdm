using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ContatoConfiguration : EntityTypeConfiguration<Contato>
    {
        public ContatoConfiguration()
        {
            HasKey(e => e.ContatoId);

            Property(c => c.TipoContato)
                .HasMaxLength(20)
                .IsRequired();

            Property(c => c.InformacaoContato)
                .HasMaxLength(80)
                .IsRequired();

            HasRequired(e => e.Pessoa)
                .WithMany(p => p.ContatoList)
                .HasForeignKey(e => e.PessoaId);

            ToTable("Contatos");
        }
    }
}
