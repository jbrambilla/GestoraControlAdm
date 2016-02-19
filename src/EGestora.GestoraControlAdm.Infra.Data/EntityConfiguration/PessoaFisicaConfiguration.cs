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
                .HasMaxLength(11);

            Property(c => c.Nome)
                .HasMaxLength(100);

        }
    }
}
