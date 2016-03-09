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
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public NotaServicoService(
            INotaServicoRepository notaServicoRepository,
            INotaServicoNfseWebService notaServicoNfseWebService,
            IClienteRepository clienteRepository,
            IEmpresaRepository empresaRepository)
        {
            _notaServicoRepository = notaServicoRepository;
            _notaServicoNfseWebService = notaServicoNfseWebService;
            _clienteRepository = clienteRepository;
            _empresaRepository = empresaRepository;
        }

        public NotaServico Add(NotaServico notaServico)
        {
            if (!notaServico.IsValid())
            {
                return notaServico;
            }

            if (notaServico.Emitir)
            {
                notaServico.Cliente = _clienteRepository.GetById(notaServico.ClienteId);
                notaServico.Empresa = _empresaRepository.GetById(notaServico.EmpresaId);
                notaServico = _notaServicoNfseWebService.Gerar(notaServico);

                if (!notaServico.ValidationResult.IsValid)
                {
                    return notaServico;
                }
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


        public IEnumerable<PessoaJuridica> GetAllClientes()
        {
            return _clienteRepository.GetAllPessoaJuridica();
        }

        public Empresa GetEmpresaAtiva()
        {
            return _empresaRepository.GetEmpresaAtiva();
        }

        public void Dispose()
        {
            _notaServicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
