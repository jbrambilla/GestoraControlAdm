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

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class DebitosController : Controller
    {
        private readonly IDebitoAppService _debitoAppService;

        public DebitosController(IDebitoAppService debitoAppService)
        {
            _debitoAppService = debitoAppService;
        }

        // GET: Debitos
        public ActionResult Index()
        {
            return View(_debitoAppService.GetAll());
        }

        // GET: Debitos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoViewModel debitoViewModel = _debitoAppService.GetById(id.Value);
            if (debitoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(debitoViewModel);
        }

        // GET: Debitos/Create
        public ActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        // POST: Debitos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DebitoViewModel debitoViewModel)
        {
            if (ModelState.IsValid)
            {
                debitoViewModel = _debitoAppService.Add(debitoViewModel);

                if (!debitoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in debitoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    LoadViewBags();
                    return View(debitoViewModel);
                }

                return RedirectToAction("Index");
            }
            LoadViewBags();
            return View(debitoViewModel);
        }

        // GET: Debitos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoViewModel debitoViewModel = _debitoAppService.GetById(id.Value);
            if (debitoViewModel == null)
            {
                return HttpNotFound();
            }
            LoadViewBags();
            return View(debitoViewModel);
        }

        // POST: Debitos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DebitoViewModel debitoViewModel)
        {
            if (ModelState.IsValid)
            {
                _debitoAppService.Update(debitoViewModel);
                return RedirectToAction("Index");
            }
            LoadViewBags();
            return View(debitoViewModel);
        }

        // GET: Debitos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoViewModel debitoViewModel = _debitoAppService.GetById(id.Value);
            if (debitoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(debitoViewModel);
        }

        // POST: Debitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _debitoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult BoletoHtml(Guid id, DateTime trava)
        {
            var boleto = _debitoAppService.GetBoletoById(id);
            ViewBag.Boleto = _debitoAppService.GetBoletoHtml(boleto);

            //aqui será gerado o código da trava

            return View();
        }

        public void LoadViewBags()
        {
            ViewBag.ClienteList = new SelectList(_debitoAppService.GetAllClientes().OrderBy(c => c.RazaoSocial), "PessoaId", "RazaoSocial");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _debitoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
