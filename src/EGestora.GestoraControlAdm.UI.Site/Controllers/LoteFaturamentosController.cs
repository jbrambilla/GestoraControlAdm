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
    public class LoteFaturamentosController : Controller
    {
        private readonly ILoteFaturamentoAppService _loteFaturamentoAppService;

        public LoteFaturamentosController(ILoteFaturamentoAppService loteFaturamentoAppService)
        {
            _loteFaturamentoAppService = loteFaturamentoAppService;
        }

        // GET: LoteFaturamentos
        public ActionResult Index()
        {
            return View(_loteFaturamentoAppService.GetAll());
        }

        // GET: LoteFaturamentos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteFaturamentoViewModel loteFaturamentoViewModel = _loteFaturamentoAppService.GetById(id.Value);
            if (loteFaturamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(loteFaturamentoViewModel);
        }

        // GET: LoteFaturamentos/Create
        public ActionResult Create()
        {
            LoadViewBags();
            return View();
        }

        // POST: LoteFaturamentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoteFaturamentoViewModel loteFaturamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                loteFaturamentoViewModel = _loteFaturamentoAppService.Add(loteFaturamentoViewModel);

                if (!loteFaturamentoViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in loteFaturamentoViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    LoadViewBags();
                    return View(loteFaturamentoViewModel);
                }

                return RedirectToAction("Index");
            }
            LoadViewBags();
            return View(loteFaturamentoViewModel);
        }

        // GET: LoteFaturamentos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteFaturamentoViewModel loteFaturamentoViewModel = _loteFaturamentoAppService.GetById(id.Value);
            if (loteFaturamentoViewModel == null)
            {
                return HttpNotFound();
            }
            LoadViewBags();
            return View(loteFaturamentoViewModel);
        }

        // POST: LoteFaturamentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoteFaturamentoViewModel loteFaturamentoViewModel)
        {
            if (ModelState.IsValid)
            {
                _loteFaturamentoAppService.Update(loteFaturamentoViewModel);
                return RedirectToAction("Index");
            }
            LoadViewBags();
            return View(loteFaturamentoViewModel);
        }

        // GET: LoteFaturamentos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoteFaturamentoViewModel loteFaturamentoViewModel = _loteFaturamentoAppService.GetById(id.Value);
            if (loteFaturamentoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(loteFaturamentoViewModel);
        }

        // POST: LoteFaturamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _loteFaturamentoAppService.Remove(id);
            return RedirectToAction("Index");
        }

        private void LoadViewBags()
        {
            ViewBag.ClienteSemNotaList = _loteFaturamentoAppService.GetAllClienteSemNota();
            ViewBag.ClienteComNotaList = _loteFaturamentoAppService.GetAllClienteComNota();
        }

        public ActionResult ServicoDetails(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _loteFaturamentoAppService.GetClienteById(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ServicoDetails", clienteViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _loteFaturamentoAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
