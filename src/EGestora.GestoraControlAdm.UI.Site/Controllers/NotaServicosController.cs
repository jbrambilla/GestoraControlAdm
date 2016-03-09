using EGestora.GestoraControlAdm.Application.Interfaces;
using EGestora.GestoraControlAdm.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class NotaServicosController : Controller
    {
        private readonly INotaServicoAppService _notaServicoAppService;

        public NotaServicosController(INotaServicoAppService notaServicoAppService)
        {
            _notaServicoAppService = notaServicoAppService;
        }

        // GET: Cnaes
        public ActionResult Index()
        {
            return View(_notaServicoAppService.GetAll());
        }

        // GET: Cnaes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaServicoViewModel notaServicoViewModel = _notaServicoAppService.GetById(id.Value);
            if (notaServicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notaServicoViewModel);
        }

        // GET: Cnaes/Create
        public ActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        // POST: Cnaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NotaServicoViewModel notaServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                notaServicoViewModel = _notaServicoAppService.Add(notaServicoViewModel);
                if (!notaServicoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in notaServicoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    LoadViewBags();
                    return View(notaServicoViewModel);
                }

                if (notaServicoViewModel.Emitir)
                {
                    return View("EmitirNota", notaServicoViewModel);
                }

                return RedirectToAction("Index");
            }

            LoadViewBags();
            return View(notaServicoViewModel);
        }

        // GET: Cnaes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaServicoViewModel notaServicoViewModel = _notaServicoAppService.GetById(id.Value);
            if (notaServicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notaServicoViewModel);
        }

        // POST: Cnaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NotaServicoViewModel notaServicoViewModel)
        {
            if (ModelState.IsValid)
            {
                _notaServicoAppService.Update(notaServicoViewModel);
                return RedirectToAction("Index");
            }
            return View(notaServicoViewModel);
        }

        // GET: Cnaes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotaServicoViewModel notaServicoViewModel = _notaServicoAppService.GetById(id.Value);
            if (notaServicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(notaServicoViewModel);
        }

        // POST: Cnaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _notaServicoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            var empresaList = new List<PessoaJuridicaViewModel>();
            empresaList.Add(_notaServicoAppService.GetEmpresaAtiva().PessoaJuridica);

            ViewBag.ClienteList = new SelectList(_notaServicoAppService.GetAllClientes().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
            ViewBag.Empresa = new SelectList(empresaList, "PessoaId", "RazaoSocial");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notaServicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
