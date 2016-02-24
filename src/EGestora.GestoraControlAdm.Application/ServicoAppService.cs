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
    public class ServicoAppService : ApplicationService, IServicoAppService
    {
        private readonly IServicoService _servicoService;

        public ServicoAppService(IServicoService servicoService, IUnitOfWork uow)
            : base (uow)
        {
            _servicoService = servicoService;
        }

        public ServicoViewModel Add(ServicoViewModel servicoViewModel)
        {
            var servico = Mapper.Map<ServicoViewModel, Servico>(servicoViewModel);

            BeginTransaction();

            var servicoResult = _servicoService.Add(servico);
            servicoViewModel = Mapper.Map<Servico, ServicoViewModel>(servicoResult);

            Commit();

            return servicoViewModel;
        }

        public ServicoViewModel GetById(Guid id)
        {
            return Mapper.Map<Servico, ServicoViewModel>(_servicoService.GetById(id));
        }

        public IEnumerable<ServicoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Servico>, IEnumerable<ServicoViewModel>>(_servicoService.GetAll());
        }

        public ServicoViewModel Update(ServicoViewModel servicoViewModel)
        {
            var servico = Mapper.Map<ServicoViewModel, Servico>(servicoViewModel);

            BeginTransaction();

            var servicoResult = _servicoService.Update(servico);
            servicoViewModel = Mapper.Map<Servico, ServicoViewModel>(servicoResult);

            Commit();

            return servicoViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _servicoService.Remove(id);
            Commit();
        }

        public void Dispose()
        {
            _servicoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
