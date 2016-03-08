using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.NfseWebServices;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class NotaServicoService : INotaServicoService
    {
        private readonly INotaServicoRepository _notaServicoRepository;
        private readonly INotaServicoNfseWebService _notaServicoNfseWebService;

        public NotaServicoService(INotaServicoRepository notaServicoRepository, INotaServicoNfseWebService notaServicoNfseWebService)
        {
            _notaServicoRepository = notaServicoRepository;
            _notaServicoNfseWebService = notaServicoNfseWebService;
        }

        public NotaServico Add(NotaServico notaServico)
        {
            if (!notaServico.IsValid())
            {
                return notaServico;
            }

            notaServico = _notaServicoNfseWebService.Gerar(notaServico);

            if (notaServico.ValidationResult.Erros.Any())
            {
                return notaServico;
            }

            return _notaServicoRepository.Add(notaServico);
        }

        public NotaServico GetById(Guid id)
        {
            return _notaServicoRepository.GetById(id);
        }

        public IEnumerable<NotaServico> GetAll()
        {
            return _notaServicoRepository.GetAll();
        }

        public NotaServico Update(NotaServico notaServico)
        {
            return _notaServicoRepository.Update(notaServico);
        }

        public void Remove(Guid id)
        {
            _notaServicoRepository.Remove(id);
        }

        public void Dispose()
        {
            _notaServicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
