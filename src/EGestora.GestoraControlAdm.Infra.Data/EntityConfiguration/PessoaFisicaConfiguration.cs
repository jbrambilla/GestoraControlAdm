using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class PessoaFisicaConfiguration : EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfiguration()
        {
            HasKey(p => p.PessoaId);

            Property(c => c.Cpf)
                .HasMaxLength(14);

            Property(c => c.Rg)
                .HasMaxLength(12);

            Property(c => c.Nome)
                .HasMaxLength(100);

        }
    }
}
