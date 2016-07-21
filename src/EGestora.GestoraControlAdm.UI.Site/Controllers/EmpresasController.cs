using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EGestora.GestoraControlAdm.Application.ViewModels;
using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Infra.CrossCutting.Utils;
using EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters.FilePath;

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly IEmpresaAppService _empresaAppService;
        private readonly IPessoaAppService _pessoaAppService;

        public EmpresasController(IEmpresaAppService empresaAppService, IPessoaAppService pessoaAppService)
        {
            _empresaAppService = empresaAppService;
            _pessoaAppService = pessoaAppService;
        }

        // GET: Empresas
        public ActionResult Index()
        {
            var empresas = _empresaAppService.GetAll();
            if (empresas.Any(e => e.Pessoa.Ativo))
            {
                return RedirectToAction("Details", new { id = empresas.First(e => e.Pessoa.Ativo).EmpresaId });
            }
            return View();
        }

        // GET: Empresas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresaViewModel = _empresaAppService.GetById(id.Value);
            if (empresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(empresaViewModel);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            loadViewBags();
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel empresaViewModel)
        {
            if (ModelState.IsValid)
            {
                empresaViewModel = _empresaAppService.Add(empresaViewModel);

                //if (!empresaEnderecoViewModel.ValidationResult.IsValid)
                //{
                //    foreach (var erro in empresaEnderecoViewModel.ValidationResult.Erros)
                //    {
                //        ModelState.AddModelError(string.Empty, erro.Message);
                //    }
                //    loadViewBags();
                //    return View(empresaEnderecoViewModel);
                //}

                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(empresaViewModel);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresaViewModel = _empresaAppService.GetById(id.Value);
            if (empresaViewModel == null)
            {
                return HttpNotFound();
            }
            loadViewBags();
            return View(empresaViewModel);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpresaViewModel empresaViewModel)
        {
            if (ModelState.IsValid)
            {
                _empresaAppService.Update(empresaViewModel);
                return RedirectToAction("Index");
            }
            loadViewBags();
            return View(empresaViewModel);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresaViewModel empresaViewModel = _empresaAppService.GetById(id.Value);
            if (empresaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(empresaViewModel);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _empresaAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _empresaAppService.Dispose();
            }
            base.Dispose(disposing);
        }

        public void loadViewBags()
        {
            ViewBag.RegimeApuracaoList = new SelectList(_empresaAppService.GetAllRegimeApuracao().OrderBy(c => c.Codigo), "RegimeApuracaoId", "Display");
            ViewBag.RegimeTributacaoList = new SelectList(_empresaAppService.GetAllRegimeTributacao().OrderBy(c => c.Codigo), "RegimeTributacaoId", "Display");
            ViewBag.NaturezaOperacaoList = new SelectList(_empresaAppService.GetAllNaturezaOperacao().OrderBy(c => c.Codigo), "NaturezaOperacaoId", "Display");
            ViewBag.EnquadramentoServicoList = new SelectList(_empresaAppService.GetAllEnquadramentoServico().OrderBy(c => c.Codigo), "EnquadramentoServicoId", "Display");
            ViewBag.PessoaJuridicaList = new SelectList(_pessoaAppService.GetAllPessoaJuridica().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
            ViewBag.PessoaFisicaList = new SelectList(_pessoaAppService.GetAllPessoaFisica().OrderBy(c => c.Nome), "PessoaId", "Nome");

        }
    }
}
