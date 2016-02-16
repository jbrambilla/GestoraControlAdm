using AutoMapper;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application
{
    public class ClienteAppService : ApplicationService, IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork _uow)
            : base(_uow)
        {
            _clienteService = clienteService;
        }

        public ClienteEnderecoViewModel Add(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            var cliente = Mapper.Map<ClienteEnderecoViewModel, Cliente>(clienteEnderecoViewModel);
            var pessoaJuridica = Mapper.Map<ClienteEnderecoViewModel, PessoaJuridica>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);

            BeginTransaction();

            pessoaJuridica.EnderecoList.Add(endereco);
            cliente.PessoaJuridica = pessoaJuridica;
            
            var clienteReturn = _clienteService.Add(cliente);
            clienteEnderecoViewModel = Mapper.Map<Cliente, ClienteEnderecoViewModel>(clienteReturn);

            if (!clienteEnderecoViewModel.ValidationResult.IsValid)
            {
                return clienteEnderecoViewModel;
            }

            Commit();
            return clienteEnderecoViewModel;
        }

        public ClienteViewModel GetById(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetById(id));
        }

        public ClienteViewModel GetByCnpj(string cnpj)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetByCnpj(cnpj));
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteService.GetAll());
        }

        public ClienteViewModel Update(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

            BeginTransaction();

            var clienteResult = _clienteService.Update(cliente);
            clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(clienteResult);

            Commit();
            return clienteViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _clienteService.Remove(id);
            Commit();
        }

        public EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _clienteService.AddEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            var endereco = Mapper.Map<EnderecoViewModel, Endereco>(enderecoViewModel);

            BeginTransaction();
            _clienteService.UpdateEndereco(endereco);
            Commit();

            return enderecoViewModel;
        }

        public EnderecoViewModel GetEnderecoById(Guid id)
        {
            return Mapper.Map<Endereco, EnderecoViewModel>(_clienteService.GetEnderecoById(id));
        }

        public void RemoveEndereco(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoveEndereco(id);
            Commit();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
