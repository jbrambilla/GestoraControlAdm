using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Enderecos;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Linq;
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
        private readonly ITipoContatoRepository _tipoContatoRepository;
        private readonly IAnexoRepository _anexoRepository;
        private readonly ICnaeRepository _cnaeRepository;
        private readonly IRegimeImpostoRepository _regimeImpostoRepository;
        private readonly IProfissaoRepository _profissaoRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public PessoaService(
            IPessoaRepository pessoaRepository,
            IPessoaFisicaRepository pessoaFisicaRepository,
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            IEnderecoRepository enderecoRepository,
            IContatoRepository contatoRepository,
            ITipoContatoRepository tipoContatoRepository,
            IAnexoRepository anexoRepository,
            ICnaeRepository cnaeRepository,
            IRegimeImpostoRepository regimeImpostoRepository,
            IProfissaoRepository profissaoRepository,
            IFuncionarioRepository funcionarioRepository,
            ICargoRepository cargoRepository,
            IProprietarioRepository proprietarioRepository)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _enderecoRepository = enderecoRepository;
            _contatoRepository = contatoRepository;
            _tipoContatoRepository = tipoContatoRepository;
            _anexoRepository = anexoRepository;
            _cnaeRepository = cnaeRepository;
            _regimeImpostoRepository = regimeImpostoRepository;
            _profissaoRepository = profissaoRepository;
            _funcionarioRepository = funcionarioRepository;
            _cargoRepository = cargoRepository;
            _proprietarioRepository = proprietarioRepository;
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

        public IEnumerable<TipoContato> GetAllTipoContatos()
        {
            return _tipoContatoRepository.GetAll();
        }

        public Anexo GetAnexoById(Guid id)
        {
            return _anexoRepository.GetById(id);
        }

        public void RemoveAnexo(Guid id)
        {
            _anexoRepository.Remove(id);
        }

        public IEnumerable<Cnae> GetAllCnae()
        {
            return _cnaeRepository.GetAll();
        }

        public Cnae GetCnaeById(Guid id)
        {
            return _cnaeRepository.GetById(id);
        }

        public bool AddCnae(Guid id, Guid pessoaId)
        {
            var pessoa = _pessoaRepository.GetById(pessoaId);

            if (pessoa.PessoaJuridica.CnaeId == id)
            {
                return false;
            }

            var cnae = _cnaeRepository.GetById(id);
            pessoa.PessoaJuridica.CnaeList.Add(cnae);
            return true;
        }

        public void RemoveCnae(Guid id, Guid pessoaId)
        {
            var pessoa = _pessoaRepository.GetById(pessoaId);
            var cnae = _cnaeRepository.GetById(id);
            pessoa.PessoaJuridica.CnaeList.Remove(cnae);
        }

        public IEnumerable<Cnae> GetAllCnaeOutPessoa(Guid id)
        {
            var pessoa = _pessoaRepository.GetById(id);
            var allCnaes = _cnaeRepository.GetAll();

            return allCnaes.Except(pessoa.PessoaJuridica.CnaeList);
        }

        public IEnumerable<RegimeImposto> GetAllRegimeImpostos()
        {
            return _regimeImpostoRepository.GetAll();
        }

        public IEnumerable<Profissao> GetAllProfissoes()
        {
            return _profissaoRepository.GetAll();
        }

        public Funcionario AddFuncionario(Funcionario funcionario)
        {
            return _funcionarioRepository.Add(funcionario);
        }

        public Funcionario UpdateFuncionario(Funcionario funcionario)
        {
            return _funcionarioRepository.Update(funcionario);
        }

        public Funcionario GetFuncionarioById(Guid id)
        {
            return _funcionarioRepository.GetById(id);
        }

        public void RemoveFuncionario(Guid id)
        {
            _funcionarioRepository.Remove(id);
        }

        public Proprietario AddProprietario(Proprietario proprietario)
        {
            return _proprietarioRepository.Add(proprietario);
        }

        public Proprietario UpdateProprietario(Proprietario proprietario)
        {
            return _proprietarioRepository.Update(proprietario);
        }

        public Proprietario GetProprietarioById(Guid id)
        {
            return _proprietarioRepository.GetById(id);
        }

        public void RemoveProprietario(Guid id)
        {
            _proprietarioRepository.Remove(id);
        }

        public IEnumerable<PessoaFisica> GetAllPessoaFisica()
        {
            return _pessoaFisicaRepository.GetAll();
        }

        public IEnumerable<PessoaJuridica> GetAllPessoaJuridica()
        {
            return _pessoaJuridicaRepository.GetAll();
        }

        public IEnumerable<Cargo> GetAllCargo()
        {
            return _cargoRepository.GetAll();
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
