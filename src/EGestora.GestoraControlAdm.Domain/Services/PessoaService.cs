using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Enderecos;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        private readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IContatoRepository _contatoRepository;

        public PessoaService(
            IPessoaRepository pessoaRepository,
            IPessoaFisicaRepository pessoaFisicaRepository,
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            IEnderecoRepository enderecoRepository,
            IContatoRepository contatoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _enderecoRepository = enderecoRepository;
            _contatoRepository = contatoRepository;
        }

        public Pessoa Add(Pessoa pessoa)
        {
            if (!pessoa.IsValid())
            {
                return pessoa;
            }

            pessoa.ValidationResult = new PessoaEstaAptaParaCadastroValidation(_pessoaRepository).Validate(pessoa);
            if (!pessoa.ValidationResult.IsValid)
            {
                return pessoa;
            }

            return _pessoaRepository.Add(pessoa);
        }

        public Pessoa GetById(Guid id)
        {
            return _pessoaRepository.GetById(id);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll();
        }

        public Pessoa Update(Pessoa pessoa)
        {
            UpdatePessoaFisica(pessoa.PessoaFisica);
            UpdatePessoaJuridica(pessoa.PessoaJuridica);
            return _pessoaRepository.Update(pessoa);
        }

        public void Remove(Guid id)
        {
            _pessoaRepository.Remove(id);
        }

        public Endereco AddEndereco(Endereco endereco)
        {
            endereco.ValidationResult = new EnderecoEstaAptoParaCadastroValidation(_enderecoRepository).Validate(endereco);
            if (!endereco.ValidationResult.IsValid)
            {
                return endereco;
            }

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

        public void Dispose()
        {
            _pessoaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
