﻿using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly ICnaeRepository _cnaeRepository;

        public ClienteService(
            IClienteRepository clienteRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository, 
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            ICnaeRepository cnaeRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _cnaeRepository = cnaeRepository;
        }

        public Cliente Add(Cliente cliente)
        {
            if (!cliente.IsValid())
            {
                return cliente;
            }

            cliente.ValidationResult = new PessoaEstaAptaParaCadastroValidation<Cliente>(_clienteRepository).Validate(cliente);
            if (!cliente.ValidationResult.IsValid)
            {
                return cliente;
            }

            return _clienteRepository.Add(cliente);
        }

        public Cliente GetById(Guid id)
        {
            return _clienteRepository.GetById(id);
        }

        public Cliente GetByCnpj(string cnpj)
        {
            return _clienteRepository.GetByCnpj(cnpj);
        }

        public Cliente GetByCpf(string cpf)
        {
            return _clienteRepository.GetByCpf(cpf);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }

        public Cliente Update(Cliente cliente)
        {
            UpdatePessoaFisica(cliente.PessoaFisica);
            UpdatePessoaJuridica(cliente.PessoaJuridica);
            return _clienteRepository.Update(cliente);
        }

        public void Remove(Guid id)
        {
            _clienteRepository.Remove(id);
        }

        public Endereco AddEndereco(Endereco endereco)
        {
            return _enderecoRepository.Add(endereco);
        }

        public Endereco UpdateEndereco(Endereco endereco)
        {
            return _enderecoRepository.Update(endereco);
        }

        public Endereco GetEnderecoById(Guid id)
        {
            return _enderecoRepository.GetById(id);
        }

        public void RemoveEndereco(Guid id)
        {
            _enderecoRepository.Remove(id);
        }

        public PessoaFisica UpdatePessoaFisica(PessoaFisica pessoaFisica)
        {
            if (pessoaFisica == null)
            {
                return null;
            }
            return _pessoaFisicaRepository.Update(pessoaFisica);
        }

        public PessoaJuridica UpdatePessoaJuridica(PessoaJuridica pessoaJuridica)
        {
            if (pessoaJuridica == null)
            {
                return null;
            }
            return _pessoaJuridicaRepository.Update(pessoaJuridica);
        }

        public IEnumerable<Cnae> GetAllCnae()
        {
            return _cnaeRepository.GetAll();
        }

        public Cnae GetCnaeById(Guid id)
        {
            return _cnaeRepository.GetById(id);
        }

        public void AddCnae(Guid id, Guid pessoaId)
        {
            var cliente = _clienteRepository.GetById(pessoaId);
            var cnae = _cnaeRepository.GetById(id);
            cliente.CnaeList.Add(cnae);
        }

        public void RemoveCnae(Guid id, Guid pessoaId)
        {
            var cliente = _clienteRepository.GetById(pessoaId);
            var cnae = _cnaeRepository.GetById(id);
            cliente.CnaeList.Remove(cnae);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
