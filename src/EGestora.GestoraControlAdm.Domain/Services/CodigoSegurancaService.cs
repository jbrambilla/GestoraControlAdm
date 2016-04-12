using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.MailService;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Validations.CodigoSegurancas;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class CodigoSegurancaService : ICodigoSegurancaService
    {
        private readonly ICodigoSegurancaRepository _codigoSegurancaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmailService _emailService;

        public CodigoSegurancaService(
            ICodigoSegurancaRepository codigoSegurancaRepository,
            IClienteRepository clienteRepository,
            IEmailService emailService)
        {
            _codigoSegurancaRepository = codigoSegurancaRepository;
            _clienteRepository = clienteRepository;
            _emailService = emailService;
        }

        public CodigoSeguranca Add(CodigoSeguranca codigoSeguranca)
        {
            if (!codigoSeguranca.IsValid())
            {
                return codigoSeguranca;
            }

            codigoSeguranca.Cliente = _clienteRepository.GetById(codigoSeguranca.ClienteId);
            _codigoSegurancaRepository.GerarCodigo(codigoSeguranca);
            codigoSeguranca.ValidationResult = new CodigoSegurancaEstaAptoParaCadastroValidation(_codigoSegurancaRepository).Validate(codigoSeguranca);
            if (!codigoSeguranca.ValidationResult.IsValid)
            {
                return codigoSeguranca;
            }

            if (!EnviarEmail(codigoSeguranca))
            {
                return codigoSeguranca;
            }

            return _codigoSegurancaRepository.Add(codigoSeguranca);
        }

        public CodigoSeguranca GetById(Guid id)
        {
            return _codigoSegurancaRepository.GetById(id);
        }

        public IEnumerable<CodigoSeguranca> GetAll()
        {
            return _codigoSegurancaRepository.GetAll();
        }

        public CodigoSeguranca Update(CodigoSeguranca codigoSeguranca)
        {
            return _codigoSegurancaRepository.Update(codigoSeguranca);
        }

        public void Remove(Guid id)
        {
            _codigoSegurancaRepository.Remove(id);
        }

        public IEnumerable<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAll();
        }

        public bool EnviarEmail(CodigoSeguranca codigoSeguranca)
        {
            if (!codigoSeguranca.EnviarEmail)
            {
                return true;
            }
            //var cliente = codigoSeguranca.Cliente;

            _emailService.AdicionarDestinatário("jotabram@gmail.com");
            //_emailService.AdicionarDestinatário(cliente.Email);
            _emailService.AdicionarRemetente("joao.brambilla@egestora.com.br");
            _emailService.AdicionarAssunto("Código de Segurança EGestora");
            _emailService.AdicionarCorpo(codigoSeguranca.Codigo);
            if (!_emailService.Enviar())
            {
                codigoSeguranca.ValidationResult.Add(new ValidationError("Falha ao enviar e-mail."));
                return false;
            }
            return true;
        }

        public void Dispose()
        {
            _codigoSegurancaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
