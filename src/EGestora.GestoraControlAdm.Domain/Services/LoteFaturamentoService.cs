using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.NfseWebServices;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class LoteFaturamentoService : ILoteFaturamentoService
    {
        private readonly ILoteFaturamentoRepository _loteFaturamentoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly INotaServicoNfseWebService _notaServicoNfseWebService;
        private readonly INotaServicoRepository _notaServicoRepository;

        public LoteFaturamentoService(
            ILoteFaturamentoRepository loteFaturamentoRepository,
            IClienteRepository clienteRepository,
            IEmpresaRepository empresaRepository,
            INotaServicoNfseWebService notaServicoNfseWebService,
            INotaServicoRepository notaServicoRepository)
        {
            _loteFaturamentoRepository = loteFaturamentoRepository;
            _clienteRepository = clienteRepository;
            _empresaRepository = empresaRepository;
            _notaServicoNfseWebService = notaServicoNfseWebService;
            _notaServicoRepository = notaServicoRepository;
        }

        public LoteFaturamento Add(LoteFaturamento loteFaturamento)
        {
            if (!loteFaturamento.IsValid())
            {
                return loteFaturamento;
            }

            if (loteFaturamento.DataFechamento != null)
            {
                loteFaturamento = GerarNotaServicos(loteFaturamento);

                if (!loteFaturamento.ValidationResult.IsValid)
                {
                    return loteFaturamento;
                }
            }

            return _loteFaturamentoRepository.Add(loteFaturamento);
        }

        public LoteFaturamento GetById(Guid id)
        {

            return _loteFaturamentoRepository.GetById(id);
        }

        public IEnumerable<LoteFaturamento> GetAll()
        {
            return _loteFaturamentoRepository.GetAll();
        }

        public LoteFaturamento Update(LoteFaturamento loteFaturamento)
        {
            return _loteFaturamentoRepository.Update(loteFaturamento);
        }

        public void Remove(Guid id)
        {
            _loteFaturamentoRepository.Remove(id);
        }

        public IEnumerable<Cliente> GetAllClienteSemNota()
        {
            return _clienteRepository.GetAllSemNota();
        }

        public IEnumerable<Cliente> GetAllClienteComNota()
        {
            return _clienteRepository.GetAllComNota();
        }

        public Cliente GetClienteById(Guid id)
        {
            return _clienteRepository.GetById(id);
        }

        public LoteFaturamento GerarNotaServicos(LoteFaturamento loteFaturamento)
        {
            var notaServicoList = new List<NotaServico>();

            foreach(var cliente in loteFaturamento.ClienteList)
            {
                var notaServico = new NotaServico()
                {
                    Aliquota = 1,
                    BaseCalculo = 1,
                    ClienteId = cliente.PessoaId,
                    Cliente = cliente,
                    DiscriminacaoServico = "discriminacao",
                    Emitir = true,
                    EmpresaId = _empresaRepository.GetEmpresaAtiva().PessoaId,
                    Empresa = _empresaRepository.GetEmpresaAtiva(),
                    IssRetido = false,
                    OutrasInformacoes = "outras informações",
                    ValorDeducoes = 1,
                    ValorISS = 1,
                    ValorLiquido = 1,
                    ValorTotal = 1
                };

                if (!notaServico.IsValid())
                {
                    loteFaturamento.ValidationResult.Add(
                        new ValidationError(
                            "A note de serviço referente ao cliente " + cliente.PessoaJuridica.RazaoSocial + " não é válida"
                        )
                    );

                    return loteFaturamento;
                }

                notaServico = _notaServicoNfseWebService.Gerar(notaServico);

                if (!notaServico.ValidationResult.IsValid)
                {
                    foreach (var erro in notaServico.ValidationResult.Erros)
                    {
                        loteFaturamento.ValidationResult.Add(new ValidationError("Problema na emissão da nota do cliente: " + cliente.PessoaJuridica.RazaoSocial + ". " + erro.Message));
                    }

                    return loteFaturamento;
                }

                notaServicoList.Add(notaServico);
            }

            foreach (var notaServico in notaServicoList)
            {
                _notaServicoRepository.Add(notaServico);
            }

            return loteFaturamento;
        }

        public void Dispose()
        {
            _loteFaturamentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
