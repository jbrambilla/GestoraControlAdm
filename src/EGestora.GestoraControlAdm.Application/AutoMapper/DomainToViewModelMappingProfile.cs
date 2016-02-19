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

            Mapper.CreateMap<Endereco, EnderecoViewModel>();
            Mapper.CreateMap<Endereco, ClienteEnderecoViewModel>();

            Mapper.CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
            Mapper.CreateMap<PessoaJuridica, ClienteEnderecoViewModel>();
            Mapper.CreateMap<PessoaJuridica, ClienteViewModel>();

            Mapper.CreateMap<PessoaFisica, PessoaFisicaViewModel>();
            Mapper.CreateMap<PessoaFisica, ClienteEnderecoViewModel>();
            Mapper.CreateMap<PessoaFisica, ClienteViewModel>();
        }
    }
}
