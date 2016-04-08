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
    public class CodigoSegurancasController : Controller
    {
        private readonly ICodigoSegurancaAppService _codigoSegurancaAppService;

        public CodigoSegurancasController(ICodigoSegurancaAppService codigoSegurancaAppService)
        {
            _codigoSegurancaAppService = codigoSegurancaAppService;
        }

        // GET: CodigoSegurancas
        public ActionResult Index()
        {
            return View(_codigoSegurancaAppService.GetAll());
        }

        // GET: CodigoSegurancas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoSegurancaViewModel codigoSegurancaViewModel = _codigoSegurancaAppService.GetById(id.Value);
            if (codigoSegurancaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(codigoSegurancaViewModel);
        }

        // GET: CodigoSegurancas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CodigoSegurancas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CodigoSegurancaViewModel codigoSegurancaViewModel)
        {
            if (ModelState.IsValid)
            {
                codigoSegurancaViewModel = _codigoSegurancaAppService.Add(codigoSegurancaViewModel);

                if (!codigoSegurancaViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in codigoSegurancaViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(codigoSegurancaViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(codigoSegurancaViewModel);
        }

        // GET: CodigoSegurancas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoSegurancaViewModel codigoSegurancaViewModel = _codigoSegurancaAppService.GetById(id.Value);
            if (codigoSegurancaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(codigoSegurancaViewModel);
        }

        // POST: CodigoSegurancas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CodigoSegurancaViewModel codigoSegurancaViewModel)
        {
            if (ModelState.IsValid)
            {
                _codigoSegurancaAppService.Update(codigoSegurancaViewModel);
                return RedirectToAction("Index");
            }
            return View(codigoSegurancaViewModel);
        }

        // GET: CodigoSegurancas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CodigoSegurancaViewModel codigoSegurancaViewModel = _codigoSegurancaAppService.GetById(id.Value);
            if (codigoSegurancaViewModel == null)
            {
                return HttpNotFound();
            }
            return View(codigoSegurancaViewModel);
        }

        // POST: CodigoSegurancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _codigoSegurancaAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _codigoSegurancaAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
