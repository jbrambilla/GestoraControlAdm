﻿using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class RevendaService : IRevendaService
    {
        private readonly IRevendaRepository _revendaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly IAnexoRepository _anexoRepository;

        public RevendaService(
            IRevendaRepository revendaRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository, 
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            IAnexoRepository anexoRepository)
        {
            _revendaRepository = revendaRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _anexoRepository = anexoRepository;
        }

        public Revenda Add(Revenda revenda)
        {
            if (!revenda.IsValid())
            {
                return revenda;
            }

            revenda.ValidationResult = new PessoaEstaAptaParaCadastroValidation<Revenda>(_revendaRepository).Validate(revenda);
            if (!revenda.ValidationResult.IsValid)
            {
                return revenda;
            }

            return _revendaRepository.Add(revenda);
        }

        public Revenda GetById(Guid id)
        {
            return _revendaRepository.GetById(id);
        }

        public Revenda GetByCnpj(string cnpj)
        {
            return _revendaRepository.GetByCnpj(cnpj);
        }

        public Revenda GetByCpf(string cpf)
        {
            return _revendaRepository.GetByCpf(cpf);
        }

        public IEnumerable<Revenda> GetAll()
        {
            return _revendaRepository.GetAll();
        }

        public Revenda Update(Revenda revenda)
        {
            UpdatePessoaFisica(revenda.PessoaFisica);
            UpdatePessoaJuridica(revenda.PessoaJuridica);
            return _revendaRepository.Update(revenda);
        }

        public void Remove(Guid id)
        {
            _revendaRepository.Remove(id);
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

        public Anexo GetAnexoById(Guid id)
        {
            return _anexoRepository.GetById(id);
        }

        public void RemoveAnexo(Guid id)
        {
            _anexoRepository.Remove(id);
        }

        public void Dispose()
        {
            _revendaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
