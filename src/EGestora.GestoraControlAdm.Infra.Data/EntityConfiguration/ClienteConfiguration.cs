using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(p => p.ClienteId);

            Property(p => p.CriadoEm)
                .IsRequired();

            Property(p => p.AlteradoEm)
                .IsRequired();

            Property(p => p.VencimentoBoleto)
                .IsRequired();

            Property(p => p.ComNota)
                .IsRequired();

            Property(p => p.Email)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

            HasRequired(c => c.PessoaJuridica)
                .WithMany()
                .HasForeignKey(c => c.PessoaJuridicaId);

            Ignore(c => c.ValidationResult);

            ToTable("Clientes");
        }
    }
}
