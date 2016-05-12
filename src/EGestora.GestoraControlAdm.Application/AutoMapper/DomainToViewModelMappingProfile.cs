using AutoMapper;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Cliente, PessoaViewModel>();
            Mapper.CreateMap<Cliente, ClienteEnderecoViewModel>();

            Mapper.CreateMap<Fornecedor, FornecedorViewModel>();
            Mapper.CreateMap<Fornecedor, PessoaViewModel>();
            Mapper.CreateMap<Fornecedor, FornecedorEnderecoViewModel>();

            Mapper.CreateMap<Revenda, RevendaViewModel>();
            Mapper.CreateMap<Revenda, PessoaViewModel>();
            Mapper.CreateMap<Revenda, RevendaEnderecoViewModel>();

            Mapper.CreateMap<Empresa, EmpresaViewModel>();
            Mapper.CreateMap<Empresa, PessoaViewModel>();
            Mapper.CreateMap<Empresa, EmpresaEnderecoViewModel>();

            Mapper.CreateMap<Funcionario, FuncionarioViewModel>();
            Mapper.CreateMap<Funcionario, PessoaViewModel>();
            Mapper.CreateMap<Funcionario, FuncionarioEnderecoViewModel>();

            Mapper.CreateMap<Endereco, EnderecoViewModel>();
            Mapper.CreateMap<Endereco, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Endereco, FornecedorEnderecoViewModel>();
            Mapper.CreateMap<Endereco, RevendaEnderecoViewModel>();
            Mapper.CreateMap<Endereco, EmpresaEnderecoViewModel>();
            Mapper.CreateMap<Endereco, FuncionarioEnderecoViewModel>();
            Mapper.CreateMap<Endereco, PessoaEnderecoViewModel>();

            Mapper.CreateMap<Contato, ContatoViewModel>();
            Mapper.CreateMap<Contato, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Contato, FornecedorEnderecoViewModel>();
            Mapper.CreateMap<Contato, RevendaEnderecoViewModel>();
            Mapper.CreateMap<Contato, EmpresaEnderecoViewModel>();
            Mapper.CreateMap<Contato, FuncionarioEnderecoViewModel>();
            Mapper.CreateMap<Contato, PessoaEnderecoViewModel>();

            Mapper.CreateMap<PessoaJuridica, PessoaEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
            Mapper.CreateMap<PessoaJuridica, ClienteEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, ClienteViewModel>();
            Mapper.CreateMap<PessoaJuridica, FornecedorEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, FornecedorViewModel>();
            Mapper.CreateMap<PessoaJuridica, RevendaEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, RevendaViewModel>();
            Mapper.CreateMap<PessoaJuridica, EmpresaEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, EmpresaViewModel>();
            Mapper.CreateMap<PessoaJuridica, FuncionarioEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, FuncionarioViewModel>();

            Mapper.CreateMap<PessoaFisica, PessoaEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, PessoaFisicaViewModel>();
            Mapper.CreateMap<PessoaFisica, ClienteEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, ClienteViewModel>();
            Mapper.CreateMap<PessoaFisica, FornecedorEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, FornecedorViewModel>();
            Mapper.CreateMap<PessoaFisica, RevendaEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, RevendaViewModel>();
            Mapper.CreateMap<PessoaFisica, EmpresaEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, EmpresaViewModel>();
            Mapper.CreateMap<PessoaFisica, FuncionarioEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, FuncionarioViewModel>();

            Mapper.CreateMap<Pessoa, PessoaViewModel>();
            Mapper.CreateMap<Pessoa, PessoaEnderecoViewModel>();

            Mapper.CreateMap<Cnae, CnaeViewModel>();

            Mapper.CreateMap<Servico, ServicoViewModel>();

            Mapper.CreateMap<ClienteServico, ClienteServicoViewModel>();

            Mapper.CreateMap<RegimeApuracao, RegimeApuracaoViewModel>();

            Mapper.CreateMap<RegimeTributacao, RegimeTributacaoViewModel>();

            Mapper.CreateMap<NaturezaOperacao, NaturezaOperacaoViewModel>();

            Mapper.CreateMap<EnquadramentoServico, EnquadramentoServicoViewModel>();

            Mapper.CreateMap<Anexo, AnexoViewModel>();

            Mapper.CreateMap<NotaServico, NotaServicoViewModel>();
            Mapper.CreateMap<NotaServico, NotaServicoDebitoViewModel>();

            Mapper.CreateMap<LoteFaturamento, LoteFaturamentoViewModel>();

            Mapper.CreateMap<Debito, DebitoViewModel>();
            Mapper.CreateMap<Debito, NotaServicoDebitoViewModel>();

            Mapper.CreateMap<Boleto, BoletoViewModel>();

            Mapper.CreateMap<CodigoSeguranca, CodigoSegurancaViewModel>();

            Mapper.CreateMap<AuditController, AuditControllerViewModel>();

            Mapper.CreateMap<AuditAction, AuditActionViewModel>();

            Mapper.CreateMap<Audit, AuditViewModel>();

            Mapper.CreateMap<TipoContato, TipoContatoViewModel>();

            Mapper.CreateMap<RegimeImposto, RegimeImpostoViewModel>();

            Mapper.CreateMap<Profissao, ProfissaoViewModel>();
        }
    }
}
