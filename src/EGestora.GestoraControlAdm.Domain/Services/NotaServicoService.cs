using EGestora.GestoraControlAdm.Domain.Entities;
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

        public NotaServicoService(
            INotaServicoRepository notaServicoRepository,
            INotaServicoNfseWebService notaServicoNfseWebService,
            IClienteRepository clienteRepository,
            IEmpresaRepository empresaRepository,
            IDebitoRepository debitoRepository,
            IEmailService emailService)
        {
            _notaServicoRepository = notaServicoRepository;
            _notaServicoNfseWebService = notaServicoNfseWebService;
            _clienteRepository = clienteRepository;
            _empresaRepository = empresaRepository;
            _debitoRepository = debitoRepository;
            _emailService = emailService;
        }

        public NotaServico Add(NotaServico notaServico)
        {
            if (!notaServico.IsValid())
            {
                return notaServico;
            }

            if (!EmitirNotaFiscal(notaServico))
            {
                return notaServico;
            }

            if (!EnviarEmail(notaServico))
            {
                return notaServico;
            }

            return _notaServicoRepository.Add(notaServico);
        }

        private bool EnviarEmail(NotaServico notaServico)
        {
            _emailService.AdicionarDestinatário("jotabram@gmail.com");
            _emailService.AdicionarRemetente("joao.brambilla@egestora.com.br");
            _emailService.AdicionarAssunto("assunto teste");
            _emailService.AdicionarCorpo("teste body");
            if (!_emailService.Enviar())
            {
                notaServico.ValidationResult.Add(new ValidationError("Erro no envio de e-mail"));
                return false;
            }
            return true;
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

        private bool EmitirNotaFiscal(NotaServico notaServico)
        {
            if (notaServico.Emitir)
            {
                notaServico.Cliente = _clienteRepository.GetById(notaServico.ClienteId);
                notaServico.Empresa = _empresaRepository.GetById(notaServico.EmpresaId);
                notaServico = _notaServicoNfseWebService.Gerar(notaServico);

                return notaServico.ValidationResult.IsValid;
            }

            return true;
        }

        public void Dispose()
        {
            _notaServicoRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
