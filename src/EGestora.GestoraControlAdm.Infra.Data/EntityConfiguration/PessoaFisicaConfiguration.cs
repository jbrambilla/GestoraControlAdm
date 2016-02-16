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
            HasKey(p => p.PessoaFisicaId);

            Property(c => c.Cpf)
                .HasMaxLength(11);

            Property(c => c.Nome)
                .HasMaxLength(100);

            // MAPEAMENTO DE MUITOS PARA MUITOS
            HasMany(f => f.EnderecoList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaFisicaId");
                    me.MapRightKey("EnderecoId");
                    me.ToTable("PessoaFisicaEndereco");
                });

        }
    }
}
