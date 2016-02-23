﻿using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;


namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(p => p.PessoaId);

            Property(p => p.Email)
                .IsRequired();

            Property(p => p.Ativo)
                .IsRequired();

            Property(p => p.CriadoEm)
                .IsRequired();

            Property(p => p.AlteradoEm)
                .IsRequired();

            HasOptional(p => p.PessoaFisica)
                    .WithRequired(pf => pf.Pessoa);

            HasOptional(p => p.PessoaJuridica)
                    .WithRequired(pf => pf.Pessoa);

            HasMany(f => f.CnaeList)
                .WithMany()
                .Map(me =>
                {
                    me.MapLeftKey("PessoaId");
                    me.MapRightKey("CnaeId");
                    me.ToTable("PessoaCnae");
                });

            Ignore(p => p.ValidationResult);

            Ignore(p => p.IsPessoaFisica);

            Ignore(p => p.IsPessoaJuridica);

            ToTable("Pessoa");
        }
    }
}
