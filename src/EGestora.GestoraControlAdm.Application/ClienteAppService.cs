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
using System.IO;
using System.Web;

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

        public ClienteViewModel Add(ClienteViewModel clienteViewModel)
        {
            var cliente = Mapper.Map<ClienteViewModel, Cliente>(clienteViewModel);

            BeginTransaction();

            var clienteReturn = _clienteService.Add(cliente);
            clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(clienteReturn);

            //if (!clienteViewModel.ValidationResult.IsValid)
            //{
            //    return clienteEnderecoViewModel;
            //}

            //if (!ImagemUtil.SalvarImagem(foto, clienteEnderecoViewModel.PessoaId, FilePathConstants.CLIENTES_IMAGE_PATH))
            //{
            //    clienteEnderecoViewModel.ValidationResult.Message = "Cliente salvo sem foto";
            //}

            Commit();
            return clienteViewModel;
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

        public ContatoViewModel AddContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _clienteService.AddContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel)
        {
            var contato = Mapper.Map<ContatoViewModel, Contato>(contatoViewModel);

            BeginTransaction();
            _clienteService.UpdateContato(contato);
            Commit();

            return contatoViewModel;
        }

        public ContatoViewModel GetContatoById(Guid id)
        {
            return Mapper.Map<Contato, ContatoViewModel>(_clienteService.GetContatoById(id));
        }

        public void RemoveContato(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoveContato(id);
            Commit();
        }

        public IEnumerable<ServicoViewModel> GetAllServicos()
        {
            return Mapper.Map<IEnumerable<Servico>, IEnumerable<ServicoViewModel>>(_clienteService.GetAllServicos());
        }

        public IEnumerable<ServicoViewModel> GetAllServicosOutPessoa(Guid id)
        {
            return Mapper.Map<IEnumerable<Servico>, IEnumerable<ServicoViewModel>>(_clienteService.GetAllServicosOutPessoa(id));
        }

        public ClienteServicoViewModel AddServico(ClienteServicoViewModel clienteServicoViewModel)
        {
            var clienteServico = Mapper.Map<ClienteServicoViewModel, ClienteServico>(clienteServicoViewModel);

            BeginTransaction();

            var clienteServicoResult = _clienteService.AddServico(clienteServico);
            clienteServicoViewModel = Mapper.Map<ClienteServico, ClienteServicoViewModel>(clienteServicoResult);

            Commit();
            return clienteServicoViewModel;
        }

        public ClienteServicoViewModel GetClienteServicoById(Guid id)
        {
            return Mapper.Map<ClienteServico, ClienteServicoViewModel>(_clienteService.GetClienteServicoById(id));
        }

        public void RemoveClienteServico(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoveClienteServico(id);
            Commit();
        }

        public IEnumerable<RevendaViewModel> GetAllRevendas()
        {
            return Mapper.Map<IEnumerable<Revenda>, IEnumerable<RevendaViewModel>>(_clienteService.GetAllRevendas());
        }

        public IEnumerable<PessoaJuridicaViewModel> GetAllPessoaJuridicaDeRevendas()
        {
            return Mapper.Map<IEnumerable<PessoaJuridica>, IEnumerable<PessoaJuridicaViewModel>>(_clienteService.GetAllPessoaJuridicaDeRevendas());
        }

        public RevendaViewModel GetRevendaById(Guid id)
        {
            return Mapper.Map<Revenda, RevendaViewModel>(_clienteService.GetRevendaById(id));
        }

        public void RemoveRevenda(Guid pessoaId)
        {
            BeginTransaction();
            _clienteService.RemoveRevenda(pessoaId);
            Commit();
        }

        public void AddRevenda(Guid pessoaId, Guid revendaId)
        {
            BeginTransaction();
            _clienteService.AddRevenda(pessoaId, revendaId);
            Commit();
        }

        public IEnumerable<RegimeApuracaoViewModel> GetAllRegimeApuracao()
        {
            return Mapper.Map<IEnumerable<RegimeApuracao>, IEnumerable<RegimeApuracaoViewModel>>(_clienteService.GetAllRegimeApuracao());
        }

        public void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo)
        {
            BeginTransaction();

            var cliente = _clienteService.GetById(PessoaId);
            cliente.Pessoa.AnexoList.Add(AnexoUtil.GetEntityFromHttpPostedFileBase(Arquivo));
            _clienteService.Update(cliente);

            Commit();
        }

        public AnexoViewModel GetAnexoById(Guid id)
        {
            return Mapper.Map<Anexo, AnexoViewModel>(_clienteService.GetAnexoById(id));
        }

        public void RemoveAnexo(Guid id)
        {
            BeginTransaction();
            _clienteService.RemoveAnexo(id);
            Commit();
        }

        public DebitoViewModel GetDebitoById(Guid id)
        {
            return Mapper.Map<Debito, DebitoViewModel>(_clienteService.GetDebitoById(id));
        }

        public DebitoViewModel AdicionarDebito(DebitoViewModel debitoViewModel)
        {
            var debito = Mapper.Map<DebitoViewModel, Debito>(debitoViewModel);

            BeginTransaction();

            _clienteService.GerarBoletos(debito);
            var debitoReturn = _clienteService.AdicionarDebito(debito);
            debitoViewModel = Mapper.Map<Debito, DebitoViewModel>(debitoReturn);

            if (!debitoViewModel.ValidationResult.IsValid)
            {
                return debitoViewModel;
            }

            Commit();

            return debitoViewModel;
        }

        public DebitoViewModel AtualizarDebito(DebitoViewModel debitoViewModel)
        {
            var debito = Mapper.Map<DebitoViewModel, Debito>(debitoViewModel);

            BeginTransaction();
            var debitoReturn = _clienteService.AtualizarDebito(debito);
            debitoViewModel = Mapper.Map<Debito, DebitoViewModel>(debitoReturn);
            Commit();

            return debitoViewModel;
        }

        public IEnumerable<PessoaFisicaViewModel> GetAllPessoaFisica()
        {
            return Mapper.Map<IEnumerable<PessoaFisica>, IEnumerable<PessoaFisicaViewModel>>(_clienteService.GetAllPessoaFisica());
        }

        public IEnumerable<PessoaJuridicaViewModel> GetAllPessoaJuridica()
        {
            return Mapper.Map<IEnumerable<PessoaJuridica>, IEnumerable<PessoaJuridicaViewModel>>(_clienteService.GetAllPessoaJuridica());
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
