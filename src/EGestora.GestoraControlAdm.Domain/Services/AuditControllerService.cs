using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.MailService;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.AuditControllers;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class AuditControllerService : IAuditControllerService
    {
        private readonly IAuditControllerRepository _auditControllerRepository;
        private readonly IAuditActionRepository _auditActionRepository;
        private readonly IAuditRepository _auditRepository;
        private readonly IEmailService _emailService;

        public AuditControllerService(
            IAuditControllerRepository auditControllerRepository,
            IAuditActionRepository auditActionRepository,
            IAuditRepository auditRepository,
            IEmailService emailService)
        {
            _auditControllerRepository = auditControllerRepository;
            _auditActionRepository = auditActionRepository;
            _auditRepository = auditRepository;
            _emailService = emailService;
        }

        public AuditController Add(AuditController auditController)
        {
            if (!auditController.IsValid())
            {
                return auditController;
            }

            auditController.ValidationResult = new AuditControllerEstaAptoParaCadastroValidation(_auditControllerRepository).Validate(auditController);
            if (!auditController.ValidationResult.IsValid)
            {
                return auditController;
            }

            return _auditControllerRepository.Add(auditController);
        }

        public AuditController GetById(Guid id)
        {
            return _auditControllerRepository.GetById(id);
        }

        public IEnumerable<AuditController> GetAll()
        {
            return _auditControllerRepository.GetAll();
        }

        public AuditController Update(AuditController auditController)
        {
            return _auditControllerRepository.Update(auditController);
        }

        public void Remove(Guid id)
        {
            _auditControllerRepository.Remove(id);
        }

        public AuditAction AddAction(AuditAction auditAction)
        {
            return _auditActionRepository.Add(auditAction);
        }

        public AuditAction UpdateAction(AuditAction auditAction)
        {
            return _auditActionRepository.Update(auditAction);
        }

        public AuditAction GetActionById(Guid id)
        {
            return _auditActionRepository.GetById(id);
        }

        public void RemoveAction(Guid id)
        {
            _auditActionRepository.Remove(id);
        }

        public IEnumerable<Audit> GetAllAudit()
        {
            return _auditRepository.GetAll();
        }

        public Audit GetAuditById(Guid id)
        {
            return _auditRepository.GetById(id);
        }

        public Audit EnviarEmail(Audit audit)
        {
            _emailService.AdicionarDestinatário("jotabram@gmail.com");
            _emailService.AdicionarRemetente("joao.brambilla@egestora.com.br");
            _emailService.AdicionarAssunto("Auditoria do sistema.");
            _emailService.AdicionarCorpo(
                "Usuário: " + audit.UserName + "\n" +
                "IP: " + audit.IPAddress + "\n" +
                "Área acessada: " + audit.AreaAccessed + "\n" +
                "Data do acesso: " + audit.CriadoEm + "\n"
            );
            if (!_emailService.Enviar())
            {
                audit.ValidationResult.Add(new ValidationError("Falha ao enviar e-mail."));
            }
            return audit;
        }

        public void Dispose()
        {
            _auditControllerRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
