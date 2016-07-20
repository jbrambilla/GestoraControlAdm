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
            HasKey(c => c.ClienteId);

            HasRequired(c => c.Pessoa)
                .WithMany()
                .HasForeignKey(c => c.PessoaId);

            Property(p => p.VencimentoBoleto)
                .IsRequired();

            Property(p => p.ComNota)
                .IsRequired();

            HasMany(c => c.ClienteServicoList)
                .WithRequired(cs => cs.Cliente)
                .HasForeignKey(cs => cs.PessoaId);

            HasOptional(c => c.Revenda)
                .WithMany(r => r.ClienteList)
                .HasForeignKey(c => c.RevendaId);

            HasRequired(c => c.RegimeApuracao)
                .WithMany(r => r.ClienteList)
                .HasForeignKey(c => c.RegimeApuracaoId);

            Ignore(c => c.ValorTotalServicos);

            Ignore(c => c.DiscriminacaoServicos);

            Ignore(c => c.Nome);

            ToTable("Clientes");
        }
    }
}
