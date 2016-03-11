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
            Mapper.CreateMap<FuncionarioEnderecoViewModel, Funcionario>();
            Mapper.CreateMap<PessoaViewModel, Funcionario>();

            Mapper.CreateMap<EnderecoViewModel, Endereco>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Endereco>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, Endereco>();
            Mapper.CreateMap<RevendaEnderecoViewModel, Endereco>();
            Mapper.CreateMap<EmpresaEnderecoViewModel, Endereco>();
            Mapper.CreateMap<FuncionarioEnderecoViewModel, Endereco>();

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

            Mapper.CreateMap<CnaeViewModel, Cnae>();

            Mapper.CreateMap<ServicoViewModel, Servico>();

            Mapper.CreateMap<ClienteServicoViewModel, ClienteServico>();
            
            Mapper.CreateMap<RegimeApuracaoViewModel, RegimeApuracao>();

            Mapper.CreateMap<RegimeTributacaoViewModel, RegimeTributacao>();

            Mapper.CreateMap<NaturezaOperacaoViewModel, NaturezaOperacao>();

            Mapper.CreateMap<EnquadramentoServicoViewModel, EnquadramentoServico>();

            Mapper.CreateMap<AnexoViewModel, Anexo>();

            Mapper.CreateMap<NotaServicoViewModel, NotaServico>();

            Mapper.CreateMap<LoteFaturamentoViewModel, LoteFaturamento>();
        }
    }
}
