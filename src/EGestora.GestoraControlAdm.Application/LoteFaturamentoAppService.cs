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
    public class LoteFaturamentoAppService : ApplicationService, ILoteFaturamentoAppService
    {
        private readonly ILoteFaturamentoService _loteFaturamentoService;

        public LoteFaturamentoAppService(ILoteFaturamentoService loteFaturamentoService, IUnitOfWork uow)
            :base(uow)
        {
            _loteFaturamentoService = loteFaturamentoService;
        }

        public LoteFaturamentoViewModel Add(LoteFaturamentoViewModel loteFaturamentoViewModel)
        {
            var loteFaturamento = Mapper.Map<LoteFaturamentoViewModel, LoteFaturamento>(loteFaturamentoViewModel);

            BeginTransaction();

            var LoteFaturamentoReturn = _loteFaturamentoService.Add(loteFaturamento);
            loteFaturamentoViewModel = Mapper.Map<LoteFaturamento, LoteFaturamentoViewModel>(LoteFaturamentoReturn);

            if (!loteFaturamentoViewModel.ValidationResult.IsValid)
            {
                return loteFaturamentoViewModel;
            }

            Commit();

            return loteFaturamentoViewModel;
        }

        public LoteFaturamentoViewModel GetById(Guid id)
        {
            return Mapper.Map<LoteFaturamento, LoteFaturamentoViewModel>(_loteFaturamentoService.GetById(id));
        }

        public IEnumerable<LoteFaturamentoViewModel> GetAll()
        {
            return Mapper.Map < IEnumerable<LoteFaturamento>, IEnumerable<LoteFaturamentoViewModel>>(_loteFaturamentoService.GetAll());
        }

        public LoteFaturamentoViewModel Update(LoteFaturamentoViewModel loteFaturamentoViewModel)
        {
            var loteFaturamento = Mapper.Map<LoteFaturamentoViewModel, LoteFaturamento>(loteFaturamentoViewModel);

            BeginTransaction();

            var loteFaturamentoReturn = _loteFaturamentoService.Update(loteFaturamento);
            loteFaturamentoViewModel = Mapper.Map<LoteFaturamento, LoteFaturamentoViewModel>(loteFaturamentoReturn);

            Commit();

            return loteFaturamentoViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _loteFaturamentoService.Remove(id);
            Commit();
        }

        public IEnumerable<ClienteViewModel> GetAllClienteSemNota()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_loteFaturamentoService.GetAllClienteSemNota());
        }

        public IEnumerable<ClienteViewModel> GetAllClienteComNota()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_loteFaturamentoService.GetAllClienteComNota());
        }

        public ClienteViewModel GetClienteById(Guid id)
        {
            return Mapper.Map<Cliente, ClienteViewModel>(_loteFaturamentoService.GetClienteById(id));
        }

        public void Dispose()
        {
            _loteFaturamentoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
