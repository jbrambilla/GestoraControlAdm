﻿using EGestora.GestoraControlAdm.AntiCorruption.BoletoNetLayer;
using EGestora.GestoraControlAdm.AntiCorruption.Cep;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Implementacao;
using EGestora.GestoraControlAdm.AntiCorruption.NfseWebService.Interfaces;
using EGestora.GestoraControlAdm.Application;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Domain.Interfaces.BoletoNet;
using EGestora.GestoraControlAdm.Domain.Interfaces.Cep;
using EGestora.GestoraControlAdm.Domain.Interfaces.MailService;
using EGestora.GestoraControlAdm.Domain.Interfaces.NfseWebServices;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Services;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Identity.Configuration;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Identity.Context;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Identity.Model;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using EGestora.GestoraControlAdm.Infra.Data.MailService;
using EGestora.GestoraControlAdm.Infra.Data.Repository;
using EGestora.GestoraControlAdm.Infra.Data.UoW;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

namespace EGestora.GestoraControlAdm.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            // App
            container.RegisterPerWebRequest<IPessoaAppService, PessoaAppService>();
            container.RegisterPerWebRequest<IClienteAppService, ClienteAppService>();
            container.RegisterPerWebRequest<IFornecedorAppService, FornecedorAppService>();
            container.RegisterPerWebRequest<IRevendaAppService, RevendaAppService>();
            container.RegisterPerWebRequest<ICnaeAppService, CnaeAppService>();
            container.RegisterPerWebRequest<IServicoAppService, ServicoAppService>();
            container.RegisterPerWebRequest<IEmpresaAppService, EmpresaAppService>();
            container.RegisterPerWebRequest<INotaServicoAppService, NotaServicoAppService>();
            container.RegisterPerWebRequest<ILoteFaturamentoAppService, LoteFaturamentoAppService>();
            container.RegisterPerWebRequest<IDebitoAppService, DebitoAppService>();
            container.RegisterPerWebRequest<ICodigoSegurancaAppService, CodigoSegurancaAppService>();
            container.RegisterPerWebRequest<IAuditControllerAppService, AuditControllerAppService>();

            // Domain
            container.RegisterPerWebRequest<IPessoaService, PessoaService>();
            container.RegisterPerWebRequest<IClienteService, ClienteService>();
            container.RegisterPerWebRequest<IFornecedorService, FornecedorService>();
            container.RegisterPerWebRequest<IRevendaService, RevendaService>();
            container.RegisterPerWebRequest<ICnaeService, CnaeService>();
            container.RegisterPerWebRequest<IServicoService, ServicoService>();
            container.RegisterPerWebRequest<IClienteServicoService, ClienteServicoService>();
            container.RegisterPerWebRequest<IEmpresaService, EmpresaService>();
            container.RegisterPerWebRequest<INotaServicoService, NotaServicoService>();
            container.RegisterPerWebRequest<ILoteFaturamentoService, LoteFaturamentoService>();
            container.RegisterPerWebRequest<IDebitoService, DebitoService>();
            container.RegisterPerWebRequest<ICodigoSegurancaService, CodigoSegurancaService>();
            container.RegisterPerWebRequest<IAuditControllerService, AuditControllerService>();

            // Infra Dados
            container.RegisterPerWebRequest<IClienteRepository, ClienteRepository>();
            container.RegisterPerWebRequest<IFornecedorRepository, FornecedorRepository>();
            container.RegisterPerWebRequest<IRevendaRepository, RevendaRepository>();
            container.RegisterPerWebRequest<IEnderecoRepository, EnderecoRepository>();
            container.RegisterPerWebRequest<IPessoaRepository, PessoaRepository>();
            container.RegisterPerWebRequest<IPessoaFisicaRepository, PessoaFisicaRepository>();
            container.RegisterPerWebRequest<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            container.RegisterPerWebRequest<ICnaeRepository, CnaeRepository>();
            container.RegisterPerWebRequest<IServicoRepository, ServicoRepository>();
            container.RegisterPerWebRequest<IClienteServicoRepository, ClienteServicoRepository>();
            container.RegisterPerWebRequest<IEmpresaRepository, EmpresaRepository>();
            container.RegisterPerWebRequest<IFuncionarioRepository, FuncionarioRepository>();
            container.RegisterPerWebRequest<IRegimeApuracaoRepository, RegimeApuracaoRepository>();
            container.RegisterPerWebRequest<IRegimeTributacaoRepository, RegimeTributacaoRepository>();
            container.RegisterPerWebRequest<INaturezaOperacaoRepository, NaturezaOperacaoRepository>();
            container.RegisterPerWebRequest<IEnquadramentoServicoRepository, EnquadramentoServicoRepository>();
            container.RegisterPerWebRequest<IAnexoRepository, AnexoRepository>();
            container.RegisterPerWebRequest<INotaServicoRepository, NotaServicoRepository>();
            container.RegisterPerWebRequest<ILoteFaturamentoRepository, LoteFaturamentoRepository>();
            container.RegisterPerWebRequest<IContatoRepository, ContatoRepository>();
            container.RegisterPerWebRequest<IDebitoRepository, DebitoRepository>();
            container.RegisterPerWebRequest<IBoletoRepository, BoletoRepository>();
            container.RegisterPerWebRequest<ICodigoSegurancaRepository, CodigoSegurancaRepository>();
            container.RegisterPerWebRequest<IUsuarioRepository, UsuarioRepository>();
            container.RegisterPerWebRequest<IAuditRepository, AuditRepository>();
            container.RegisterPerWebRequest<IAuditControllerRepository, AuditControllerRepository>();
            container.RegisterPerWebRequest<IAuditActionRepository, AuditActionRepository>();
            container.RegisterPerWebRequest<ITipoContatoRepository, TipoContatoRepository>();
            container.RegisterPerWebRequest<IRegimeImpostoRepository, RegimeImpostoRepository>();
            container.RegisterPerWebRequest<IProfissaoRepository, ProfissaoRepository>();
            container.RegisterPerWebRequest<ICargoRepository, CargoRepository>();
            container.RegisterPerWebRequest<IProprietarioRepository, ProprietarioRepository>();
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
            container.RegisterPerWebRequest<EGestoraContext>();

            // AntiCorruption
            container.RegisterPerWebRequest<INotaServicoNfseWebService, NotaServicoNfseWebService>();
            container.RegisterPerWebRequest<IContatoTomadorNfse, ContatoTomadorNfse>();
            container.RegisterPerWebRequest<ICredencialNfse, CredencialNfse>();
            container.RegisterPerWebRequest<IDadosServicoNfse, DadosServicoNfse>();
            container.RegisterPerWebRequest<IDadosTomadorNfse, DadosTomadorNfse>();
            container.RegisterPerWebRequest<IEnderecoTomadorNfse, EnderecoTomadorNfse>();
            container.RegisterPerWebRequest<IIdentificacaoPrestadorNfse, IdentificacaoPrestadorNfse>();
            container.RegisterPerWebRequest<IItensServicoNfse, ItensServicoNfse>();
            container.RegisterPerWebRequest<INovaNfse, NovaNfse>();
            container.RegisterPerWebRequest<IValoresServicoNfse, ValoresServicoNfse>();
            container.RegisterPerWebRequest<IBoletoNetService, BoletoNetService>();
            container.RegisterPerWebRequest<ICepService, CepService>();

            //Email
            container.RegisterPerWebRequest<IEmailService, EGestora.GestoraControlAdm.Infra.Data.MailService.EmailService>();

            //Identity
            container.RegisterPerWebRequest<ApplicationDbContext>();
            container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());
            container.RegisterPerWebRequest<ApplicationRoleManager>();
            container.RegisterPerWebRequest<ApplicationUserManager>();
            container.RegisterPerWebRequest<ApplicationSignInManager>();

        }
    }
}
