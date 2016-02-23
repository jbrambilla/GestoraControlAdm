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

            Mapper.CreateMap<Endereco, EnderecoViewModel>();
            Mapper.CreateMap<Endereco, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Endereco, FornecedorEnderecoViewModel>();
            Mapper.CreateMap<Endereco, RevendaEnderecoViewModel>();

            Mapper.CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
            Mapper.CreateMap<PessoaJuridica, ClienteEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, ClienteViewModel>();
            Mapper.CreateMap<PessoaJuridica, FornecedorEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, FornecedorViewModel>();
            Mapper.CreateMap<PessoaJuridica, RevendaEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, RevendaViewModel>();

            Mapper.CreateMap<PessoaFisica, PessoaFisicaViewModel>();
            Mapper.CreateMap<PessoaFisica, ClienteEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, ClienteViewModel>();
            Mapper.CreateMap<PessoaFisica, FornecedorEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, FornecedorViewModel>();
            Mapper.CreateMap<PessoaFisica, RevendaEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, RevendaViewModel>();

            Mapper.CreateMap<Cnae, CnaeViewModel>();
        }
    }
}
