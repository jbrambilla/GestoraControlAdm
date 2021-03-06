﻿using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly IAnexoRepository _anexoRepository;
        private readonly IContatoRepository _contatoRepository;

        public FornecedorService(
            IFornecedorRepository fornecedorRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository,
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            IAnexoRepository anexoRepository,
            IContatoRepository contatoRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _anexoRepository = anexoRepository;
            _contatoRepository = contatoRepository;
        }

        public Fornecedor Add(Fornecedor fornecedor)
        {
            if (!fornecedor.IsValid())
            {
                return fornecedor;
            }

            return _fornecedorRepository.Add(fornecedor);
        }

        public Fornecedor GetById(Guid id)
        {
            return _fornecedorRepository.GetById(id);
        }

        public Fornecedor GetByCnpj(string cnpj)
        {
            return _fornecedorRepository.GetByCnpj(cnpj);
        }

        public Fornecedor GetByCpf(string cpf)
        {
            return _fornecedorRepository.GetByCpf(cpf);
        }

        public IEnumerable<Fornecedor> GetAll()
        {
            return _fornecedorRepository.GetAll();
        }

        public Fornecedor Update(Fornecedor fornecedor)
        {
            UpdatePessoaFisica(fornecedor.PessoaFisica);
            UpdatePessoaJuridica(fornecedor.PessoaJuridica);
            return _fornecedorRepository.Update(fornecedor);
        }

        public void Remove(Guid id)
        {
            _fornecedorRepository.Remove(id);
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

        public Contato AddContato(Contato contato)
        {
            return _contatoRepository.Add(contato);
        }

        public Contato UpdateContato(Contato contato)
        {
            return _contatoRepository.Update(contato);
        }

        public Contato GetContatoById(Guid id)
        {
            return _contatoRepository.GetById(id);
        }

        public void RemoveContato(Guid id)
        {
            _contatoRepository.Remove(id);
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
            _fornecedorRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
