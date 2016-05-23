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

            HasRequired(e => e.Pessoa)
                .WithMany(p => p.ContatoList)
                .HasForeignKey(e => e.PessoaId);

            HasRequired(e => e.TipoContato)
                .WithMany(tc => tc.ContatoList)
                .HasForeignKey(tc => tc.TipoContatoId);

            ToTable("Contatos");
        }
    }
}
