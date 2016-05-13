using AutoMapper;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;

namespace EGestora.GestoraControlAdm.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ClienteViewModel, Cliente>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Cliente>();
            Mapper.CreateMap<PessoaViewModel, Cliente>();

            Mapper.CreateMap<FornecedorViewModel, Fornecedor>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, Fornecedor>();
            Mapper.CreateMap<PessoaViewModel, Fornecedor>();

            Mapper.CreateMap<RevendaViewModel, Revenda>();
            Mapper.CreateMap<RevendaEnderecoViewModel, Revenda>();
            Mapper.CreateMap<PessoaViewModel, Revenda>();

            Mapper.CreateMap<EmpresaViewModel, Empresa>();
            Mapper.CreateMap<EmpresaEnderecoViewModel, Empresa>();
            Mapper.CreateMap<PessoaViewModel, Empresa>();

            Mapper.CreateMap<FuncionarioViewModel, Funcionario>();

            Mapper.CreateMap<EnderecoViewModel, Endereco>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Endereco>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, Endereco>();
            Mapper.CreateMap<RevendaEnderecoViewModel, Endereco>();
            Mapper.CreateMap<EmpresaEnderecoViewModel, Endereco>();
            Mapper.CreateMap<FuncionarioEnderecoViewModel, Endereco>();
            Mapper.CreateMap<PessoaEnderecoViewModel, Endereco>();

            Mapper.CreateMap<ContatoViewModel, Contato>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Contato>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, Contato>();
            Mapper.CreateMap<RevendaEnderecoViewModel, Contato>();
            Mapper.CreateMap<EmpresaEnderecoViewModel, Contato>();
            Mapper.CreateMap<FuncionarioEnderecoViewModel, Contato>();
            Mapper.CreateMap<PessoaEnderecoViewModel, Contato>();

            Mapper.CreateMap<PessoaEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
            Mapper.CreateMap<ClienteEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<ClienteViewModel, PessoaJuridica>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<FornecedorViewModel, PessoaJuridica>();
            Mapper.CreateMap<RevendaEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<RevendaViewModel, PessoaJuridica>();
            Mapper.CreateMap<EmpresaEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<EmpresaViewModel, PessoaJuridica>();
            Mapper.CreateMap<FuncionarioEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<FuncionarioViewModel, PessoaJuridica>();

            Mapper.CreateMap<PessoaEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<PessoaFisicaViewModel, PessoaFisica>();
            Mapper.CreateMap<ClienteEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<ClienteViewModel, PessoaFisica>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<FornecedorViewModel, PessoaFisica>();
            Mapper.CreateMap<RevendaEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<RevendaViewModel, PessoaFisica>();
            Mapper.CreateMap<EmpresaEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<EmpresaViewModel, PessoaFisica>();
            Mapper.CreateMap<FuncionarioEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<FuncionarioViewModel, PessoaFisica>();

            Mapper.CreateMap<PessoaViewModel, Pessoa>();
            Mapper.CreateMap<PessoaEnderecoViewModel, Pessoa>();

            Mapper.CreateMap<CnaeViewModel, Cnae>();

            Mapper.CreateMap<ServicoViewModel, Servico>();

            Mapper.CreateMap<ClienteServicoViewModel, ClienteServico>();
            
            Mapper.CreateMap<RegimeApuracaoViewModel, RegimeApuracao>();

            Mapper.CreateMap<RegimeTributacaoViewModel, RegimeTributacao>();

            Mapper.CreateMap<NaturezaOperacaoViewModel, NaturezaOperacao>();

            Mapper.CreateMap<EnquadramentoServicoViewModel, EnquadramentoServico>();

            Mapper.CreateMap<AnexoViewModel, Anexo>();

            Mapper.CreateMap<NotaServicoViewModel, NotaServico>();
            Mapper.CreateMap<NotaServicoDebitoViewModel, NotaServico>();

            Mapper.CreateMap<LoteFaturamentoViewModel, LoteFaturamento>();

            Mapper.CreateMap<DebitoViewModel, Debito>();
            Mapper.CreateMap<NotaServicoDebitoViewModel, Debito>();

            Mapper.CreateMap<BoletoViewModel, Boleto>();

            Mapper.CreateMap<CodigoSegurancaViewModel, CodigoSeguranca>();

            Mapper.CreateMap<AuditControllerViewModel, AuditController>();

            Mapper.CreateMap<AuditActionViewModel, AuditAction>();

            Mapper.CreateMap<AuditViewModel, Audit>();

            Mapper.CreateMap<TipoContatoViewModel, TipoContato>();

            Mapper.CreateMap<RegimeImpostoViewModel, RegimeImposto>();

            Mapper.CreateMap<ProfissaoViewModel, Profissao>();
        }
    }
}
