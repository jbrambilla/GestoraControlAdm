﻿using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly ICnaeRepository _cnaeRepository;

        public EmpresaService(
            IEmpresaRepository empresaRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository, 
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            ICnaeRepository cnaeRepository)
        {
            _empresaRepository = empresaRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _cnaeRepository = cnaeRepository;
        }

        public Empresa Add(Empresa empresa)
        {
            if (!empresa.IsValid())
            {
                return empresa;
            }

            empresa.ValidationResult = new PessoaEstaAptaParaCadastroValidation<Empresa>(_empresaRepository).Validate(empresa);
            if (!empresa.ValidationResult.IsValid)
            {
                return empresa;
            }

            return _empresaRepository.Add(empresa);
        }

        public Empresa GetById(Guid id)
        {
            return _empresaRepository.GetById(id);
        }

        public Empresa GetByCnpj(string cnpj)
        {
            return _empresaRepository.GetByCnpj(cnpj);
        }

        public Empresa GetByCpf(string cpf)
        {
            return _empresaRepository.GetByCpf(cpf);
        }

        public IEnumerable<Empresa> GetAll()
        {
            return _empresaRepository.GetAll();
        }

        public Empresa Update(Empresa empresa)
        {
            UpdatePessoaFisica(empresa.PessoaFisica);
            UpdatePessoaJuridica(empresa.PessoaJuridica);
            return _empresaRepository.Update(empresa);
        }

        public void Remove(Guid id)
        {
            _empresaRepository.Remove(id);
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
            var cliente = _empresaRepository.GetById(pessoaId);
            var cnae = _cnaeRepository.GetById(id);
            cliente.CnaeList.Add(cnae);
        }

        public void RemoveCnae(Guid id, Guid pessoaId)
        {
            var cliente = _empresaRepository.GetById(pessoaId);
            var cnae = _cnaeRepository.GetById(id);
            cliente.CnaeList.Remove(cnae);
        }

        public IEnumerable<Cnae> GetAllCnaeOutPessoa(Guid id)
        {
            var cliente = _empresaRepository.GetById(id);
            var allCnaes = _cnaeRepository.GetAll();

            return allCnaes.Except(cliente.CnaeList);
        }

        public void Dispose()
        {
            _empresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
