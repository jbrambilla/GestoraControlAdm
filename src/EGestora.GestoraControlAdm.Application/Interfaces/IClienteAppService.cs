﻿using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Web;

namespace EGestora.GestoraControlAdm.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        ClienteViewModel Add(ClienteViewModel clienteEnderecoViewModel);
        ClienteViewModel GetById(Guid id);
        ClienteViewModel GetByCnpj(string cnpj);
        ClienteViewModel GetByCpf(string cpf);
        IEnumerable<ClienteViewModel> GetAll();
        ClienteViewModel Update(ClienteViewModel clienteViewModel);
        void Remove(Guid id);

        EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        ContatoViewModel AddContato(ContatoViewModel contatoViewModel);
        ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel);
        ContatoViewModel GetContatoById(Guid id);
        void RemoveContato(Guid id);

        IEnumerable<ServicoViewModel> GetAllServicos();
        IEnumerable<ServicoViewModel> GetAllServicosOutPessoa(Guid id);
        ClienteServicoViewModel AddServico(ClienteServicoViewModel clienteServicoViewModel);

        ClienteServicoViewModel GetClienteServicoById(Guid id);
        void RemoveClienteServico(Guid id);

        IEnumerable<RevendaViewModel> GetAllRevendas();
        IEnumerable<PessoaJuridicaViewModel> GetAllPessoaJuridicaDeRevendas();
        RevendaViewModel GetRevendaById(Guid id);
        void RemoveRevenda(Guid pessoaId);
        void AddRevenda(Guid pessoaId, Guid revendaId);

        IEnumerable<RegimeApuracaoViewModel> GetAllRegimeApuracao();

        void AddAnexo(Guid PessoaId, HttpPostedFileBase Arquivo);
        AnexoViewModel GetAnexoById(Guid id);
        void RemoveAnexo(Guid id);

        DebitoViewModel GetDebitoById(Guid id);
        DebitoViewModel AdicionarDebito(DebitoViewModel debitoViewModel);
        DebitoViewModel AtualizarDebito(DebitoViewModel debitoViewModel);

        IEnumerable<PessoaFisicaViewModel> GetAllPessoaFisica();
        IEnumerable<PessoaJuridicaViewModel> GetAllPessoaJuridica();
    }
}
