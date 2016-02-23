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
    public class CnaesController : Controller
    {
        private readonly ICnaeAppService _cnaeAppService;

        public CnaesController(ICnaeAppService cnaeAppService)
        {
            _cnaeAppService = cnaeAppService;
        }

        // GET: Cnaes
        public ActionResult Index()
        {
            return View(_cnaeAppService.GetAll());
        }

        // GET: Cnaes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CnaeViewModel cnaeViewModel = _cnaeAppService.GetById(id.Value);
            if (cnaeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cnaeViewModel);
        }

        // GET: Cnaes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cnaes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CnaeViewModel cnaeViewModel)
        {
            if (ModelState.IsValid)
            {
                _cnaeAppService.Add(cnaeViewModel);
                return RedirectToAction("Index");
            }

            return View(cnaeViewModel);
        }

        // GET: Cnaes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CnaeViewModel cnaeViewModel = _cnaeAppService.GetById(id.Value);
            if (cnaeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cnaeViewModel);
        }

        // POST: Cnaes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CnaeViewModel cnaeViewModel)
        {
            if (ModelState.IsValid)
            {
                _cnaeAppService.Update(cnaeViewModel);
                return RedirectToAction("Index");
            }
            return View(cnaeViewModel);
        }

        // GET: Cnaes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CnaeViewModel cnaeViewModel = _cnaeAppService.GetById(id.Value);
            if (cnaeViewModel == null)
            {
                return HttpNotFound();
            }
            return View(cnaeViewModel);
        }

        // POST: Cnaes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _cnaeAppService.Remove(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cnaeAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
