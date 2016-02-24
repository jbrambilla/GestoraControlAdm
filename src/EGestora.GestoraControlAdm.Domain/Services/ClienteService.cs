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

        public ClienteService(
            IClienteRepository clienteRepository, 
            IEnderecoRepository enderecoRepository, 
            IPessoaFisicaRepository pessoaFisicaRepository, 
            IPessoaJuridicaRepository pessoaJuridicaRepository,
            ICnaeRepository cnaeRepository,
            IServicoRepository servicoRepository,
            IClienteServicoRepository clienteServicoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _cnaeRepository = cnaeRepository;
            _servicoRepository = servicoRepository;
            _clienteServicoRepository = clienteServicoRepository;
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

        public void AddServico(Guid pessoaId, Guid servicoId)
        {
            var cliente = _clienteRepository.GetById(pessoaId);
            var servico = _servicoRepository.GetById(servicoId);

            var ClienteServico = new ClienteServico();
            ClienteServico.Servico = servico;
            ClienteServico.Cliente = cliente;

            _clienteServicoRepository.Add(ClienteServico);
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

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
