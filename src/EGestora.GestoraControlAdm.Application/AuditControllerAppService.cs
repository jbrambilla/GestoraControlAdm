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
    public class AuditControllerAppService : ApplicationService, IAuditControllerAppService
    {
        private readonly IAuditControllerService _auditControllerService;

        public AuditControllerAppService(IAuditControllerService auditControllerService, IUnitOfWork uow)
            :base (uow)
        {
            _auditControllerService = auditControllerService;
        }

        public AuditControllerViewModel Add(AuditControllerViewModel auditControllerViewModel)
        {
            var auditController = Mapper.Map<AuditControllerViewModel, AuditController>(auditControllerViewModel);
            var auditActionNameList = auditControllerViewModel.ActionNameList;

            BeginTransaction();

            foreach (var actionName in auditActionNameList)
            {
                auditController.AuditActionList.Add(new AuditAction() { ActionName = actionName, AuditControllerId = auditController.AuditControllerId });
            }

            var auditControllerReturn = _auditControllerService.Add(auditController);
            auditControllerViewModel = Mapper.Map<AuditController, AuditControllerViewModel>(auditControllerReturn);

            if (!auditControllerViewModel.ValidationResult.IsValid)
            {
                return auditControllerViewModel;
            }

            Commit();

            return auditControllerViewModel;
        }

        public AuditControllerViewModel GetById(Guid id)
        {
            return Mapper.Map<AuditController, AuditControllerViewModel>(_auditControllerService.GetById(id));
        }

        public IEnumerable<AuditControllerViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<AuditController>, IEnumerable<AuditControllerViewModel>>(_auditControllerService.GetAll());
        }

        public AuditControllerViewModel Update(AuditControllerViewModel auditControllerViewModel)
        {
            var auditController = Mapper.Map<AuditControllerViewModel, AuditController>(auditControllerViewModel);

            BeginTransaction();

            var auditControllerReturn = _auditControllerService.Update(auditController);
            auditControllerViewModel = Mapper.Map<AuditController, AuditControllerViewModel>(auditControllerReturn);

            //if (!auditControllerViewModel.ValidationResult.IsValid)
            //{
            //    return auditControllerViewModel;
            //}

            Commit();

            return auditControllerViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _auditControllerService.Remove(id);
            Commit();
        }

        public AuditActionViewModel AddAction(AuditActionViewModel auditActionViewModel)
        {
            var auditAction = Mapper.Map<AuditActionViewModel, AuditAction>(auditActionViewModel);

            BeginTransaction();

            var auditActionReturn = _auditControllerService.AddAction(auditAction);
            auditActionViewModel = Mapper.Map<AuditAction, AuditActionViewModel>(auditActionReturn);

            Commit();

            return auditActionViewModel;
        }

        public AuditActionViewModel UpdateAction(AuditActionViewModel auditActionViewModel)
        {
            var auditAction = Mapper.Map<AuditActionViewModel, AuditAction>(auditActionViewModel);

            BeginTransaction();

            var auditActionReturn = _auditControllerService.UpdateAction(auditAction);
            auditActionViewModel = Mapper.Map<AuditAction, AuditActionViewModel>(auditActionReturn);

            Commit();

            return auditActionViewModel;
        }

        public AuditActionViewModel GetActionById(Guid id)
        {
            return Mapper.Map<AuditAction, AuditActionViewModel>(_auditControllerService.GetActionById(id));
        }

        public void RemoveAction(Guid id)
        {
            BeginTransaction();
            _auditControllerService.RemoveAction(id);
            Commit();
        }

        public void Dispose()
        {
            _auditControllerService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
