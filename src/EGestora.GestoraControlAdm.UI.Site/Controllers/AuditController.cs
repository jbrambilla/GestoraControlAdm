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
    public class AuditController : Controller
    {
        private readonly IAuditControllerAppService _auditControllerAppService;

        public AuditController(IAuditControllerAppService auditControllerAppService)
        {
            _auditControllerAppService = auditControllerAppService;
        }

        // GET: AuditControllers
        public ActionResult Index()
        {
            return View(_auditControllerAppService.GetAll());
        }

        // GET: AuditControllers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditControllerViewModel auditControllerViewModel = _auditControllerAppService.GetById(id.Value);
            if (auditControllerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(auditControllerViewModel);
        }

        // GET: AuditControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuditControllers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuditControllerViewModel auditControllerViewModel)
        {
            if (ModelState.IsValid)
            {
                auditControllerViewModel = _auditControllerAppService.Add(auditControllerViewModel);

                if (!auditControllerViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in auditControllerViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return View(auditControllerViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(auditControllerViewModel);
        }

        // GET: AuditControllers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditControllerViewModel auditControllerViewModel = _auditControllerAppService.GetById(id.Value);
            if (auditControllerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(auditControllerViewModel);
        }

        // POST: AuditControllers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuditControllerViewModel auditControllerViewModel)
        {
            if (ModelState.IsValid)
            {
                _auditControllerAppService.Update(auditControllerViewModel);
                return RedirectToAction("Index");
            }
            return View(auditControllerViewModel);
        }

        // GET: AuditControllers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuditControllerViewModel auditControllerViewModel = _auditControllerAppService.GetById(id.Value);
            if (auditControllerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(auditControllerViewModel);
        }

        // POST: AuditControllers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _auditControllerAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _auditControllerAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
