﻿using AutoMapper;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
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
            var pf = Mapper.Map<ClienteEnderecoViewModel, PessoaFisica>(clienteEnderecoViewModel);
            var pj = Mapper.Map<ClienteEnderecoViewModel, PessoaJuridica>(clienteEnderecoViewModel);
            var endereco = Mapper.Map<ClienteEnderecoViewModel, Endereco>(clienteEnderecoViewModel);
            var selectedCnaeList = clienteEnderecoViewModel.SelectedCnaeList;
            var foto = clienteEnderecoViewModel.Foto;

            if (clienteEnderecoViewModel.FlagIsPessoaJuridica)
            {
                pf = null;
            }
            else
            {
                pj = null;
            }

            BeginTransaction();

            /** Adicionando PF, PJ e ENDEREÇO **/
            cliente.PessoaFisica = pf;
            cliente.PessoaJuridica = pj;
            cliente.EnderecoList.Add(endereco);
            /** FIM Adicionando PF, PJ e ENDEREÇO **/

            /** Adicionando CNAES **/
            foreach (var CnaeId in selectedCnaeList)
            {
                var cnae = _clienteService.GetCnaeById(CnaeId);
                cliente.CnaeList.Add(cnae);
            }
            /** FIM Adicionando CNAES **/

            var clienteReturn = _clienteService.Add(cliente);
            clienteEnderecoViewModel = Mapper.Map<Cliente, ClienteEnderecoViewModel>(clienteReturn);

            if (!clienteEnderecoViewModel.ValidationResult.IsValid)
            {
                return clienteEnderecoViewModel;
            }

            if (!ImagemUtil.SalvarImagem(foto, clienteEnderecoViewModel.PessoaId, FilePathConstants.CLIENTES_IMAGE_PATH))
            {
                // Tomada de decisão caso a imagem não seja gravada.
                clienteEnderecoViewModel.ValidationResult.Message = "Cliente salvo sem foto";
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

        public ClienteViewModel GetByCpf(string cpf)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_clienteService.GetByCpf(cpf));
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

        public IEnumerable<CnaeViewModel> GetAllCnae()
        {
            return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_clienteService.GetAllCnae());
        }

        public CnaeViewModel GetCnaeById(Guid id)
        {
            return Mapper.Map<Cnae, CnaeViewModel>(_clienteService.GetCnaeById(id));
        }

        public void AddCnae(Guid id, Guid pessoaId)
        {
            BeginTransaction();
            _clienteService.AddCnae(id, pessoaId);
            Commit();
        }

        public void RemoveCnae(Guid cnaeId, Guid pessoaId)
        {
            BeginTransaction();
            _clienteService.RemoveCnae(cnaeId, pessoaId);
            Commit();
        }

        public IEnumerable<CnaeViewModel> GetAllCnaeOutPessoa(Guid id)
        {
            return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_clienteService.GetAllCnaeOutPessoa(id));
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }


        
    }
}
