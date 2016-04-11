using AutoMapper;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Application
{
    public class CodigoSegurancaAppService : ApplicationService, ICodigoSegurancaAppService
    {
        private readonly ICodigoSegurancaService _codigoSegurancaService;

        public CodigoSegurancaAppService(ICodigoSegurancaService codigoSegurancaService, IUnitOfWork uow)
            :base (uow)
        {
            _codigoSegurancaService = codigoSegurancaService;
        }

        public CodigoSegurancaViewModel Add(CodigoSegurancaViewModel codigoSegurancaViewModel)
        {
            var clientesParaGerarCodigo = codigoSegurancaViewModel.Gerar.Where(c => !c.Equals("false")).ToList();
            
            BeginTransaction();

            foreach (var ClienteId in clientesParaGerarCodigo)
            {
                var codigoSeguranca = Mapper.Map<CodigoSegurancaViewModel, CodigoSeguranca>(codigoSegurancaViewModel);
                codigoSeguranca.CodigoSegurancaId = Guid.NewGuid();
                codigoSeguranca.ClienteId = Guid.Parse(ClienteId);

                var codigoSegurancaReturn = _codigoSegurancaService.Add(codigoSeguranca);

                codigoSegurancaViewModel = Mapper.Map<CodigoSeguranca, CodigoSegurancaViewModel>(codigoSegurancaReturn);

                if (!codigoSegurancaViewModel.ValidationResult.IsValid)
                {
                    return codigoSegurancaViewModel;
                }
            }
            
            Commit();

            return codigoSegurancaViewModel;
        }

        public CodigoSegurancaViewModel GetById(Guid id)
        {
            return Mapper.Map<CodigoSeguranca, CodigoSegurancaViewModel>(_codigoSegurancaService.GetById(id));
        }

        public IEnumerable<CodigoSegurancaViewModel> GetAll()
        {
            return Mapper.Map < IEnumerable<CodigoSeguranca>, IEnumerable<CodigoSegurancaViewModel>>(_codigoSegurancaService.GetAll());
        }

        public CodigoSegurancaViewModel Update(CodigoSegurancaViewModel codigoSegurancaViewModel)
        {
            var codigoSeguranca = Mapper.Map<CodigoSegurancaViewModel, CodigoSeguranca>(codigoSegurancaViewModel);

            BeginTransaction();

            var codigoSegurancaReturn = _codigoSegurancaService.Update(codigoSeguranca);
            codigoSegurancaViewModel = Mapper.Map<CodigoSeguranca, CodigoSegurancaViewModel>(codigoSegurancaReturn);

            Commit();

            return codigoSegurancaViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _codigoSegurancaService.Remove(id);
            Commit();
        }

        public IEnumerable<ClienteViewModel> GetAllClientes()
        {
            return Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_codigoSegurancaService.GetAllClientes());
        }

        public void Dispose()
        {
            _codigoSegurancaService.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
