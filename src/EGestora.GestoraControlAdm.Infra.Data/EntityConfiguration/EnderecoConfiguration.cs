using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(e => e.EnderecoId);

            HasRequired(e => e.Pessoa)
                .WithMany(p => p.EnderecoList)
                .HasForeignKey(e => e.PessoaId);

            Ignore(e => e.ValidationResult);

            Ignore(e => e.EnderecoCompleto);

            ToTable("Enderecos");
        }
    }
}
