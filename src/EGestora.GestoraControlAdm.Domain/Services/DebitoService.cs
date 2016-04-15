using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.BoletoNet;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class DebitoService : IDebitoService
    {
        private readonly IDebitoRepository _debitoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IBoletoNetService _boletoNetService;
        private readonly IBoletoRepository _boletoRepository;

        public DebitoService(
            IDebitoRepository debitoRepository,
            IClienteRepository clienteRepository,
            IBoletoNetService boletoNetService,
            IBoletoRepository boletoRepository)
        {
            _debitoRepository = debitoRepository;
            _clienteRepository = clienteRepository;
            _boletoNetService = boletoNetService;
            _boletoRepository = boletoRepository;
        }

        public Debito Add(Debito debito)
        {
            if (!debito.IsValid())
            {
                return debito;
            }

            return _debitoRepository.Add(debito);
        }

        public Debito GetById(Guid id)
        {
            return _debitoRepository.GetById(id);
        }

        public IEnumerable<Debito> GetAll()
        {
            return _debitoRepository.GetAll();
        }

        public Debito Update(Debito debito)
        {
            return _debitoRepository.Update(debito);
        }

        public void Remove(Guid id)
        {
            _debitoRepository.Remove(id);
        }

        public IEnumerable<PessoaJuridica> GetAllClientes()
        {
            return _clienteRepository.GetAllPessoaJuridica();
        }

        public void GerarBoletoParaDebito(Debito debito)
        {
            var vencimento = debito.Vencimento;
            vencimento = vencimento.AddDays(-30);
            foreach (var valorParcela in debito.ValorParcelaList)
            {
                vencimento = vencimento.AddDays(30);
                var boleto = new Boleto()
                {
                    Valor = valorParcela,
                    Vencimento = vencimento
                };
                debito.BoletoList.Add(boleto);
            }
        }

        public string GetBoletoHtml(Boleto boleto)
        {
            return _boletoNetService.GetHtml(boleto);
        }

        public byte[] GetBoletoBytes(Boleto boleto)
        {
            return _boletoNetService.GetBytes(boleto);
        }

        public Boleto GetBoletoById(Guid id)
        {
            return _boletoRepository.GetById(id);
        }

        public int GetTotalRecords()
        {
            return _debitoRepository.GetTotalRecords();
        }

        public IEnumerable<Debito> GetAllToGrid(int skip, int take)
        {
            return _debitoRepository.GetAllToGrid(skip, take);
        }

        public void GerarBoletos(Debito debito)
        {
            _debitoRepository.GerarBoletos(debito);
        }

        public void Dispose()
        {
            _debitoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
