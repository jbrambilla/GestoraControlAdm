using EGestora.GestoraControlAdm.Domain.Entities;
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

        public FornecedorService(
            IFornecedorRepository fornecedorRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository, 
            IPessoaJuridicaRepository pessoaJuridicaRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
        }

        public Fornecedor Add(Fornecedor fornecedor)
        {
            if (!fornecedor.IsValid())
            {
                return fornecedor;
            }
            fornecedor.ValidationResult = new PessoaEstaAptaParaCadastroValidation<Fornecedor>(_fornecedorRepository).Validate(fornecedor);
            if (!fornecedor.ValidationResult.IsValid)
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
            _fornecedorRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
