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

        public NotaServicoDebitoViewModel Add(NotaServicoDebitoViewModel notaServicoDebitoViewModel)
        {
            var notaServico = Mapper.Map<NotaServicoDebitoViewModel, NotaServico>(notaServicoDebitoViewModel);
            var debito = Mapper.Map<NotaServicoDebitoViewModel, Debito>(notaServicoDebitoViewModel);
            notaServico.Cliente = _notaServicoService.ObterClientePorId(notaServico.ClienteId);
            notaServico.Empresa = _notaServicoService.GetEmpresaAtiva();

            BeginTransaction();

            var notaServicoReturn = _notaServicoService.Add(notaServico);
            notaServicoDebitoViewModel = Mapper.Map<NotaServico, NotaServicoDebitoViewModel>(notaServicoReturn);

            if (!notaServicoDebitoViewModel.ValidationResult.IsValid)
            {
                return notaServicoDebitoViewModel;
            }

            _notaServicoService.GerarBoletoParaDebito(debito);
            var debitoReturn = _notaServicoService.AddDebito(debito);
            
            if (!debitoReturn.ValidationResult.IsValid)
            {
                notaServicoDebitoViewModel.ValidationResult = debitoReturn.ValidationResult;
                return notaServicoDebitoViewModel;
            }

            Commit();

            return notaServicoDebitoViewModel;
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

        public ClienteViewModel ObterClientePorId(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_notaServicoService.ObterClientePorId(id));
        }

        public bool EnviarEmail(NotaServicoDebitoViewModel notaServicoViewModel)
        {
            return _notaServicoService.EnviarEmail(Mapper.Map<NotaServicoDebitoViewModel, NotaServico>(notaServicoViewModel));
        }

        public void Dispose()
        {
            _notaServicoService.Dispose();
            GC.SuppressFinalize(this);
        }




    }
}
