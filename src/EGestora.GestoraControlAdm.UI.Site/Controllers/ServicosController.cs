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
    public class ServicosController : Controller
    {
        private readonly IServicoAppService _servicoAppService;

        public ServicosController(IServicoAppService servicoAppService)
        {
            _servicoAppService = servicoAppService;
        }

        // GET: Servicos
        public ActionResult Index()
        {
            return View(_servicoAppService.GetAll());
        }

        // GET: Servicos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicoViewModel servicoViewModel = _servicoAppService.GetById(id.Value);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
        }

        // GET: Servicos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServicoViewModel servicoViewModel)
        {
            if (ModelState.IsValid)
            {
                _servicoAppService.Add(servicoViewModel);
                return RedirectToAction("Index");
            }

            return View(servicoViewModel);
        }

        // GET: Servicos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicoViewModel servicoViewModel = _servicoAppService.GetById(id.Value);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServicoViewModel servicoViewModel)
        {
            if (ModelState.IsValid)
            {
                _servicoAppService.Update(servicoViewModel);
                return RedirectToAction("Index");
            }
            return View(servicoViewModel);
        }

        // GET: Servicos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicoViewModel servicoViewModel = _servicoAppService.GetById(id.Value);
            if (servicoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(servicoViewModel);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _servicoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _servicoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
