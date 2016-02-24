using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class ClienteServicoService : IClienteServicoService
    {
        private readonly IClienteServicoRepository _clienteServicoRepository;

        public ClienteServicoService(IClienteServicoRepository clienteServicoRepository)
        {
            _clienteServicoRepository = clienteServicoRepository;
        }

        public ClienteServico Add(ClienteServico clienteServico)
        {
            return _clienteServicoRepository.Add(clienteServico);
        }

        public ClienteServico GetById(Guid id)
        {
            return _clienteServicoRepository.GetById(id);
        }

        public IEnumerable<ClienteServico> GetAll()
        {
            return _clienteServicoRepository.GetAll();
        }

        public ClienteServico Update(ClienteServico clienteServico)
        {
            return _clienteServicoRepository.Update(clienteServico);
        }

        public void Remove(Guid id)
        {
            _clienteServicoRepository.Remove(id);
        }

        public void Dispose()
        {
            _clienteServicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
