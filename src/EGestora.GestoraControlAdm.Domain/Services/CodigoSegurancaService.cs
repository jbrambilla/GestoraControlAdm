using EGestora.GestoraControlAdm.Domain.Entities;
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

        public CodigoSegurancaService(ICodigoSegurancaRepository codigoSegurancaRepository, IClienteRepository clienteRepository)
        {
            _codigoSegurancaRepository = codigoSegurancaRepository;
            _clienteRepository = clienteRepository;
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

        public IEnumerable<PessoaJuridica> GetAllClientes()
        {
            return _clienteRepository.GetAllPessoaJuridica();
        }

        public void Dispose()
        {
            _codigoSegurancaRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
