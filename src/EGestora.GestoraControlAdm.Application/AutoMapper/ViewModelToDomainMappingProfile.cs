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

            Mapper.CreateMap<EnderecoViewModel, Endereco>();
            Mapper.CreateMap<ClienteEnderecoViewModel, Endereco>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, Endereco>();
            Mapper.CreateMap<RevendaEnderecoViewModel, Endereco>();

            Mapper.CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
            Mapper.CreateMap<ClienteEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<ClienteViewModel, PessoaJuridica>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<FornecedorViewModel, PessoaJuridica>();
            Mapper.CreateMap<RevendaEnderecoViewModel, PessoaJuridica>();
            Mapper.CreateMap<RevendaViewModel, PessoaJuridica>();

            Mapper.CreateMap<PessoaFisicaViewModel, PessoaFisica>();
            Mapper.CreateMap<ClienteEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<ClienteViewModel, PessoaFisica>();
            Mapper.CreateMap<FornecedorEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<FornecedorViewModel, PessoaFisica>();
            Mapper.CreateMap<RevendaEnderecoViewModel, PessoaFisica>();
            Mapper.CreateMap<RevendaViewModel, PessoaFisica>();
            
        }
    }
}
