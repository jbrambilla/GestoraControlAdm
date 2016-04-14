using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.Pessoas;
using System;
using System.Linq;
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
        private readonly IServicoRepository _servicoRepository;
        private readonly IClienteServicoRepository _clienteServicoRepository;
        private readonly IRevendaRepository _revendaRepository;
        private readonly IRegimeApuracaoRepository _regimeApuracaoRepository;
        private readonly IAnexoRepository _anexoRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly IDebitoRepository _debitoRepository;

        public ClienteService(
            IClienteRepository clienteRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository, 
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            ICnaeRepository cnaeRepository,
            IServicoRepository servicoRepository,
            IClienteServicoRepository clienteServicoRepository,
            IRevendaRepository revendaRepository,
            IRegimeApuracaoRepository regimeApuracaoRepository,
            IAnexoRepository anexoRepository,
            IContatoRepository contatoRepository,
            IDebitoRepository debitoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _cnaeRepository = cnaeRepository;
            _servicoRepository = servicoRepository;
            _clienteServicoRepository = clienteServicoRepository;
            _revendaRepository = revendaRepository;
            _regimeApuracaoRepository = regimeApuracaoRepository;
            _anexoRepository = anexoRepository;
            _contatoRepository = contatoRepository;
            _debitoRepository = debitoRepository;
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

        public IEnumerable<Cnae> GetAllCnaeOutPessoa(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);
            var allCnaes = _cnaeRepository.GetAll();

            return allCnaes.Except(cliente.CnaeList);
        }

        public Servico GetServicoById(Guid id)
        {
            return _servicoRepository.GetById(id);
        }

        public IEnumerable<Servico> GetAllServicos()
        {
            return _servicoRepository.GetAll();
        }

        public IEnumerable<Servico> GetAllServicosOutPessoa(Guid id)
        {
            var cliente = _clienteRepository.GetById(id);
            var clienteServicoList = GetAllServicosDoCliente(cliente);
            var allServicos = _servicoRepository.GetAll();

            return allServicos.Except(clienteServicoList);
        }

        public ClienteServico AddServico(ClienteServico clienteServico)
        {
            return _clienteServicoRepository.Add(clienteServico);
        }

        private IEnumerable<Servico> GetAllServicosDoCliente(Cliente cliente)
        {
            var clienteServicoList = new List<Servico>();

            foreach (var clienteServico in cliente.ClienteServicoList)
            {
                clienteServicoList.Add(clienteServico.Servico);
            }

            return clienteServicoList;
        }

        public ClienteServico GetClienteServicoById(Guid id)
        {
            return _clienteServicoRepository.GetById(id);
        }

        public void RemoveClienteServico(Guid id)
        {
            _clienteServicoRepository.Remove(id);
        }

        public IEnumerable<Revenda> GetAllRevendas()
        {
            return _revendaRepository.GetAll();
        }

        public IEnumerable<PessoaJuridica> GetAllPessoaJuridicaDeRevendas()
        {
            return _revendaRepository.GetAllPessoaJuridica();
        }

        public Revenda GetRevendaById(Guid id)
        {
            return _revendaRepository.GetById(id);
        }

        public void RemoveRevenda(Guid pessoaId)
        {
            var cliente = _clienteRepository.GetById(pessoaId);
            cliente.Revenda = null;
            cliente.RevendaId = null;
            _clienteRepository.Update(cliente);
        }

        public void AddRevenda(Guid pessoaId, Guid revendaId)
        {
            var cliente = _clienteRepository.GetById(pessoaId);
            cliente.RevendaId = revendaId;
            _clienteRepository.Update(cliente);
        }

        public IEnumerable<RegimeApuracao> GetAllRegimeApuracao()
        {
            return _regimeApuracaoRepository.GetAll();
        }

        public Anexo GetAnexoById(Guid id)
        {
            return _anexoRepository.GetById(id);
        }

        public void RemoveAnexo(Guid id)
        {
            _anexoRepository.Remove(id);
        }

        public Debito GetDebitoById(Guid id)
        {
            return _debitoRepository.GetById(id);
        }

        public void BaixarDebito(Guid id, DateTime DataBaixa)
        {
            _debitoRepository.Baixar(id, DataBaixa);
        }

        public Debito AdicionarDebito(Debito debito)
        {
            if (!debito.IsValid())
            {
                return debito;
            }

            return _debitoRepository.Add(debito);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
