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
    public class DebitoAppService : ApplicationService, IDebitoAppService
    {
        private readonly IDebitoService _debitoService;

        public DebitoAppService(IDebitoService debitoService, IUnitOfWork uow)
            :base (uow)
        {
            _debitoService = debitoService;
        }

        public DebitoViewModel Add(DebitoViewModel debitoViewModel)
        {
            var debito = Mapper.Map<DebitoViewModel, Debito>(debitoViewModel);

            BeginTransaction();

            _debitoService.GerarBoletoParaDebito(debito);
            var debitoReturn = _debitoService.Add(debito);
            debitoViewModel = Mapper.Map<Debito, DebitoViewModel>(debitoReturn);

            if (!debitoViewModel.ValidationResult.IsValid)
            {
                return debitoViewModel;
            }

            Commit();

            return debitoViewModel;
        }

        public DebitoViewModel GetById(Guid id)
        {
            return Mapper.Map<Debito, DebitoViewModel>(_debitoService.GetById(id));
        }

        public IEnumerable<DebitoViewModel> GetAll()
        {
            return Mapper.Map <IEnumerable<Debito>, IEnumerable<DebitoViewModel>>(_debitoService.GetAll());
        }

        public DebitoViewModel Update(DebitoViewModel debitoViewModel)
        {
            var debito = Mapper.Map<DebitoViewModel, Debito>(debitoViewModel);

            BeginTransaction();

            var debitoReturn = _debitoService.Update(debito);
            debitoViewModel = Mapper.Map<Debito, DebitoViewModel>(debitoReturn);

            Commit();

            return debitoViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _debitoService.Remove(id);
            Commit();
        }

        public IEnumerable<PessoaJuridicaViewModel> GetAllClientes()
        {
            return Mapper.Map<IEnumerable<PessoaJuridica>, IEnumerable<PessoaJuridicaViewModel>>(_debitoService.GetAllClientes());
        }

        public void Dispose()
        {
            _debitoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
