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
    public class CnaeAppService : ApplicationService, ICnaeAppService
    {
        private readonly ICnaeService _cnaeService;

        public CnaeAppService(ICnaeService cnaeService, IUnitOfWork uow)
            : base(uow)
        {
            _cnaeService = cnaeService;
        }

        public CnaeViewModel Add(CnaeViewModel cnaeViewModel)
        {
            var cnae = Mapper.Map<CnaeViewModel, Cnae>(cnaeViewModel);

            BeginTransaction();

            var cnaeResult = _cnaeService.Add(cnae);
            cnaeViewModel = Mapper.Map<Cnae, CnaeViewModel>(cnaeResult);

            Commit();

            return cnaeViewModel;
        }

        public CnaeViewModel GetById(Guid id)
        {
            return Mapper.Map<Cnae, CnaeViewModel>(_cnaeService.GetById(id));
        }

        public IEnumerable<CnaeViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Cnae>, IEnumerable<CnaeViewModel>>(_cnaeService.GetAll());
        }

        public CnaeViewModel Update(CnaeViewModel cnaeViewModel)
        {
            var cnae = Mapper.Map<CnaeViewModel, Cnae>(cnaeViewModel);

            BeginTransaction();

            var cnaeResult = _cnaeService.Add(cnae);
            cnaeViewModel = Mapper.Map<Cnae, CnaeViewModel>(cnaeResult);

            Commit();

            return cnaeViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _cnaeService.Remove(id);
            Commit();
        }

        public void Dispose()
        {
            _cnaeService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
