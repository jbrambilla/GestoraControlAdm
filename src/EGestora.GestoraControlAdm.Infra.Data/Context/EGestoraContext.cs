using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.Context
{
    public class EGestoraContext : DbContext
    {
        public EGestoraContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Revenda> Revendas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<Cnae> Cnaes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ClienteServico> ClienteServico { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<RegimeApuracao> RegimeApuracao { get; set; }
        public DbSet<RegimeTributacao> RegimeTributacao { get; set; }
        public DbSet<NaturezaOperacao> NaturezaOperacao { get; set; }
        public DbSet<EnquadramentoServico> EnquadramentoServico { get; set; }
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<NotaServico> NotaServico { get; set; }
        public DbSet<LoteFaturamento> LoteFaturamento { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Debito> Debitos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<CodigoSeguranca> CodigoSeguranca { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new FornecedorConfiguration());
            modelBuilder.Configurations.Add(new RevendaConfiguration());
            modelBuilder.Configurations.Add(new PessoaConfiguration());
            modelBuilder.Configurations.Add(new PessoaFisicaConfiguration());
            modelBuilder.Configurations.Add(new PessoaJuridicaConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new CnaeConfiguration());
            modelBuilder.Configurations.Add(new ServicoConfiguration());
            modelBuilder.Configurations.Add(new ClienteServicoConfiguration());
            modelBuilder.Configurations.Add(new EmpresaConfiguration());
            modelBuilder.Configurations.Add(new FuncionarioConfiguration());
            modelBuilder.Configurations.Add(new RegimeApuracaoConfiguration());
            modelBuilder.Configurations.Add(new RegimeTributacaoConfiguration());
            modelBuilder.Configurations.Add(new EnquadramentoServicoConfiguration());
            modelBuilder.Configurations.Add(new NaturezaOperacaoConfiguration());
            modelBuilder.Configurations.Add(new AnexoConfiguration());
            modelBuilder.Configurations.Add(new NotaServicoConfiguration());
            modelBuilder.Configurations.Add(new LoteFaturamentoConfiguration());
            modelBuilder.Configurations.Add(new ContatoConfiguration());
            modelBuilder.Configurations.Add(new DebitoConfiguration());
            modelBuilder.Configurations.Add(new BoletoConfiguration());
            modelBuilder.Configurations.Add(new CodigoSegurancaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("AlteradoEm") != null))
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("AlteradoEm").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
