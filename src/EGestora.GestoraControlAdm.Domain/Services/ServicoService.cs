using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
        {
            _servicoRepository = servicoRepository;
        }

        public Servico Add(Servico servico)
        {
            return _servicoRepository.Add(servico);
        }

        public Servico GetById(Guid id)
        {
            return _servicoRepository.GetById(id);
        }

        public IEnumerable<Servico> GetAll()
        {
            return _servicoRepository.GetAll();
        }

        public Servico Update(Servico servico)
        {
            return _servicoRepository.Update(servico);
        }

        public void Remove(Guid id)
        {
            _servicoRepository.Remove(id);
        }

        public void Dispose()
        {
            _servicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
