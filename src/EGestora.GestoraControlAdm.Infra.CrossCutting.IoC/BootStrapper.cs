using EGestora.GestoraControlAdm.Application;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Domain.Interfaces.Service;
using EGestora.GestoraControlAdm.Domain.Services;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using EGestora.GestoraControlAdm.Infra.Data.Interfaces;
using EGestora.GestoraControlAdm.Infra.Data.Repository;
using EGestora.GestoraControlAdm.Infra.Data.UoW;
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
            container.RegisterPerWebRequest<IClienteAppService, ClienteAppService>();
            container.RegisterPerWebRequest<IFornecedorAppService, FornecedorAppService>();
            container.RegisterPerWebRequest<IRevendaAppService, RevendaAppService>();
            container.RegisterPerWebRequest<ICnaeAppService, CnaeAppService>();
            container.RegisterPerWebRequest<IServicoAppService, ServicoAppService>();

            // Domain
            container.RegisterPerWebRequest<IClienteService, ClienteService>();
            container.RegisterPerWebRequest<IFornecedorService, FornecedorService>();
            container.RegisterPerWebRequest<IRevendaService, RevendaService>();
            container.RegisterPerWebRequest<ICnaeService, CnaeService>();
            container.RegisterPerWebRequest<IServicoService, ServicoService>();
            container.RegisterPerWebRequest<IClienteServicoService, ClienteServicoService>();

            // Infra Dados
            container.RegisterPerWebRequest<IClienteRepository, ClienteRepository>();
            container.RegisterPerWebRequest<IFornecedorRepository, FornecedorRepository>();
            container.RegisterPerWebRequest<IRevendaRepository, RevendaRepository>();
            container.RegisterPerWebRequest<IEnderecoRepository, EnderecoRepository>();
            container.RegisterPerWebRequest<IPessoaFisicaRepository, PessoaFisicaRepository>();
            container.RegisterPerWebRequest<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
            container.RegisterPerWebRequest<ICnaeRepository, CnaeRepository>();
            container.RegisterPerWebRequest<IServicoRepository, ServicoRepository>();
            container.RegisterPerWebRequest<IClienteServicoRepository, ClienteServicoRepository>();
            container.RegisterPerWebRequest<IUnitOfWork, UnitOfWork>();
            container.RegisterPerWebRequest<EGestoraContext>();
        }
    }
}
