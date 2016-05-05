using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using EGestora.GestoraControlAdm.Domain.Validations.Empresas;
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
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IRegimeApuracaoRepository _regimeApuracaoRepository;
        private readonly IRegimeTributacaoRepository _regimeTributacaoRepository;
        private readonly INaturezaOperacaoRepository _naturezaOperacaoRepository;
        private readonly IEnquadramentoServicoRepository _enquadramentoServicoRepository;
        private readonly IAnexoRepository _anexoRepository;
        private readonly IContatoRepository _contatoRepository;

        public EmpresaService(
            IEmpresaRepository empresaRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository, 
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            ICnaeRepository cnaeRepository,
            IFuncionarioRepository funcionarioRepository,
            IRegimeApuracaoRepository regimeApuracaoRepository,
            IRegimeTributacaoRepository regimeTributacaoRepository,
            INaturezaOperacaoRepository naturezaOperacaoRepository,
            IEnquadramentoServicoRepository enquadramentoServicoRepository,
            IAnexoRepository anexoRepository,
            IContatoRepository contatoRepository)
        {
            _empresaRepository = empresaRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _cnaeRepository = cnaeRepository;
            _funcionarioRepository = funcionarioRepository;
            _regimeApuracaoRepository = regimeApuracaoRepository;
            _regimeTributacaoRepository = regimeTributacaoRepository;
            _naturezaOperacaoRepository = naturezaOperacaoRepository;
            _enquadramentoServicoRepository = enquadramentoServicoRepository;
            _anexoRepository = anexoRepository;
            _contatoRepository = contatoRepository;
        }

        public Empresa Add(Empresa empresa)
        {
            if (!empresa.IsValid())
            {
                return empresa;
            }

            empresa.ValidationResult = new EmpresaEstaAptaParaCadastroValidation(_empresaRepository).Validate(empresa);
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

        public Empresa GetEmpresaAtiva()
        {
            return _empresaRepository.GetEmpresaAtiva();
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
            var empresa = _empresaRepository.GetById(pessoaId);

            if (empresa.CnaeId == id)
            {
                return false;
            }

            var cnae = _cnaeRepository.GetById(id);
            empresa.CnaeList.Add(cnae);
            return true;
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

        public Funcionario AddFuncionario(Funcionario funcionario)
        {
            if (!funcionario.IsValid())
            {
                return funcionario;
            }

            return _funcionarioRepository.Add(funcionario);
        }

        public Funcionario UpdateFuncionario(Funcionario funcionario)
        {
            UpdatePessoaFisica(funcionario.PessoaFisica);
            UpdatePessoaJuridica(funcionario.PessoaJuridica);
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

        public IEnumerable<RegimeApuracao> GetAllRegimeApuracao()
        {
            return _regimeApuracaoRepository.GetAll();
        }

        public IEnumerable<NaturezaOperacao> GetAllNaturezaOperacao()
        {
            return _naturezaOperacaoRepository.GetAll();
        }

        public IEnumerable<RegimeTributacao> GetAllRegimeTributacao()
        {
            return _regimeTributacaoRepository.GetAll();
        }

        public IEnumerable<EnquadramentoServico> GetAllEnquadramentoServico()
        {
            return _enquadramentoServicoRepository.GetAll();
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
            _empresaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
