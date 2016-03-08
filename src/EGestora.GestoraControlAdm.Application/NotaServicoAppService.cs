using AutoMapper;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application
{
    public class NotaServicoAppService : ApplicationService, INotaServicoAppService
    {
        private readonly INotaServicoService _notaServicoService;

        public NotaServicoAppService(INotaServicoService notaServicoService, IUnitOfWork uow)
            : base(uow)
        {
            _notaServicoService = notaServicoService;
        }

        public NotaServicoViewModel Add(NotaServicoViewModel notaServicoViewModel)
        {
            var notaServico = Mapper.Map<NotaServicoViewModel, NotaServico>(notaServicoViewModel);

            BeginTransaction();

            var notaServicoReturn = _notaServicoService.Add(notaServico);
            notaServicoViewModel = Mapper.Map<NotaServico, NotaServicoViewModel>(notaServicoReturn);

            if (!notaServicoViewModel.ValidationResult.IsValid)
            {
                return notaServicoViewModel;
            }

            Commit();

            return notaServicoViewModel;
        }

        public NotaServicoViewModel GetById(Guid id)
        {
            return Mapper.Map<NotaServico, NotaServicoViewModel>(_notaServicoService.GetById(id));
        }

        public IEnumerable<NotaServicoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<NotaServico>, IEnumerable<NotaServicoViewModel>>(_notaServicoService.GetAll());
        }

        public NotaServicoViewModel Update(NotaServicoViewModel notaServicoViewModel)
        {
            var notaServico = Mapper.Map<NotaServicoViewModel, NotaServico>(notaServicoViewModel);

            BeginTransaction();

            var notaServicoReturn = _notaServicoService.Update(notaServico);
            notaServicoViewModel = Mapper.Map<NotaServico, NotaServicoViewModel>(notaServicoReturn);

            Commit();

            return notaServicoViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _notaServicoService.Remove(id);
            Commit();
        }

        public IEnumerable<PessoaJuridicaViewModel> GetAllClientes()
        {
            return Mapper.Map<IEnumerable<PessoaJuridica>, IEnumerable<PessoaJuridicaViewModel>>(_notaServicoService.GetAllClientes());
        }

        public EmpresaViewModel GetEmpresaAtiva()
        {
            return Mapper.Map<Empresa, EmpresaViewModel>(_notaServicoService.GetEmpresaAtiva());
        }

        public void Dispose()
        {
            _notaServicoService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
