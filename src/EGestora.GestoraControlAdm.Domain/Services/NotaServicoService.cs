﻿using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.NfseWebServices;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using System;
using System.Linq;
using System.Collections.Generic;
using EGestora.GestoraControlAdm.Domain.Interfaces.MailService;
using System.Threading.Tasks;
using System.IO;
using DomainValidation.Validation;
using EGestora.GestoraControlAdm.Domain.Interfaces.BoletoNet;

namespace EGestora.GestoraControlAdm.Domain.Services
{
    public class NotaServicoService : INotaServicoService
    {
        private readonly INotaServicoRepository _notaServicoRepository;
        private readonly INotaServicoNfseWebService _notaServicoNfseWebService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IDebitoRepository _debitoRepository;
        private readonly IEmailService _emailService;
        private readonly IBoletoNetService _boletoNetService;

        public NotaServicoService(
            INotaServicoRepository notaServicoRepository,
            INotaServicoNfseWebService notaServicoNfseWebService,
            IClienteRepository clienteRepository,
            IEmpresaRepository empresaRepository,
            IDebitoRepository debitoRepository,
            IEmailService emailService,
            IBoletoNetService boletoNetService)
        {
            _notaServicoRepository = notaServicoRepository;
            _notaServicoNfseWebService = notaServicoNfseWebService;
            _clienteRepository = clienteRepository;
            _empresaRepository = empresaRepository;
            _debitoRepository = debitoRepository;
            _emailService = emailService;
            _boletoNetService = boletoNetService;
        }

        public NotaServico Add(NotaServico notaServico)
        {
            if (!notaServico.IsValid())
            {
                return notaServico;
            }

            notaServico = EmitirNotaFiscal(notaServico);
            if (!notaServico.ValidationResult.IsValid)
            {
                return notaServico;
            }

            notaServico = EnviarEmail(notaServico);
            if (!notaServico.ValidationResult.IsValid)
            {
                return notaServico;
            }

            return _notaServicoRepository.Add(notaServico);
        }

        public NotaServico GetById(Guid id)
        {
            return _notaServicoRepository.GetById(id);
        }

        public IEnumerable<NotaServico> GetAll()
        {
            return _notaServicoRepository.GetAll();
        }

        public NotaServico Update(NotaServico notaServico)
        {
            if (!notaServico.IsValid())
            {
                return notaServico;
            }

            return _notaServicoRepository.Update(notaServico);
        }

        public void Remove(Guid id)
        {
            _notaServicoRepository.Remove(id);
        }


        public IEnumerable<PessoaJuridica> GetAllClientes()
        {
            return _clienteRepository.GetAllPessoaJuridica();
        }

        public Empresa GetEmpresaAtiva()
        {
            return _empresaRepository.GetEmpresaAtiva();
        }

        public Cliente ObterClientePorId(Guid id)
        {
            return _clienteRepository.GetById(id);
        }

        public Debito AddDebito(Debito debito)
        {
            if (!debito.IsValid())
            {
                return debito;
            }

            return _debitoRepository.Add(debito);
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

        private NotaServico EmitirNotaFiscal(NotaServico notaServico)
        {
            if (!notaServico.Emitir)
            {
                return notaServico;
            }

            notaServico.Cliente = _clienteRepository.GetById(notaServico.ClienteId);
            notaServico.Empresa = _empresaRepository.GetById(notaServico.EmpresaId);
            return _notaServicoNfseWebService.Gerar(notaServico);
        }

        private NotaServico EnviarEmail(NotaServico notaServico)
        {
            if (!notaServico.EnviarEmail)
            {
                return notaServico;
            }

            var cliente = _clienteRepository.GetById(notaServico.ClienteId);
            var boleto = cliente.ObterUltimoDebitoAtivo().ObterProximoBoletoQueVaiVencer();


            _emailService.AdicionarDestinatário("jotabram@gmail.com");
            //_emailService.AdicionarDestinatário(cliente.Email);
            _emailService.AdicionarRemetente("joao.brambilla@egestora.com.br");
            _emailService.AdicionarAssunto("assunto teste");
            _emailService.AdicionarCorpo("teste body");
            _emailService.AdicionarAnexo(notaServico.PdfNfse, "NotaServico.pdf");
            _emailService.AdicionarAnexo(_boletoNetService.GetBytes(boleto), "Boleto.pdf");

            if (!_emailService.Enviar())
            {
                notaServico.ValidationResult.Add(new ValidationError("Erro ao enviar e-mail."));
            }
            return notaServico;
        }

        public void Dispose()
        {
            _notaServicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
