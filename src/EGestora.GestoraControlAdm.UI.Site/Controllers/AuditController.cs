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
using System.Reflection;

namespace EGestora.GestoraControlAdm.UI.Site.Controllers
{
    public class AuditController : Controller
    {
        private readonly IAuditControllerAppService _auditControllerAppService;

        public AuditController(IAuditControllerAppService auditControllerAppService)
        {
            _auditControllerAppService = auditControllerAppService;
        }

        // GET: Audits
        public ActionResult History()
        {
            return View(_auditControllerAppService.GetAllAudit());
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
            LoadViewBags();
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

                    LoadViewBags();
                    return View(auditControllerViewModel);
                }

                return RedirectToAction("Index");
            }

            LoadViewBags();
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

            LoadViewBags();
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

            LoadViewBags();
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

        [HttpGet]
        public ActionResult LoadActions(string controllerName)
        {
            Assembly asm = Assembly.GetAssembly(typeof(MvcApplication));

            var actionList = new SelectList(
                asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name }).Where(x => x.Controller == controllerName && !x.Action.Contains("Confirmed"))
                    .GroupBy(x => x.Action, x => x.Controller, (key, g) => new { Action = key }).ToList(), string.Empty, "Action");

            return Json(actionList, JsonRequestBehavior.AllowGet);
        }

        private void LoadViewBags()
        {
            Assembly asm = Assembly.GetAssembly(typeof(MvcApplication));

            ViewBag.ControllerList = new SelectList(
                asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name })
                    .OrderBy(x => x.Controller).GroupBy(x => x.Controller, x => x.Action, (key, g) => new { Controller = key }).ToList(), "Controller", "Controller");
        }



        //Actions

        public ActionResult ListarActionsNoIndex(Guid id)
        {
            var auditController = _auditControllerAppService.GetById(id);
            return PartialView("_ActionListIndex", auditController.AuditActionList);
        }

        public ActionResult ListarActions(Guid id)
        {
            var auditController = _auditControllerAppService.GetById(id);
            return PartialView("_ActionList", auditController.AuditActionList);
        }

        [Route("adicionar-action")]
        public ActionResult AdicionarAction(Guid id)
        {
            var auditController = _auditControllerAppService.GetById(id);

            ViewBag.AuditControllerId = auditController.AuditControllerId;

            RemoverActionsExistentesNoControllerEcarregarViewBag(auditController);
            
            return PartialView("_AdicionarAction");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdicionarAction(AuditActionViewModel auditActionViewModel)
        {
            if (ModelState.IsValid)
            {
                _auditControllerAppService.AddAction(auditActionViewModel);

                string url = Url.Action("ListarActions", "Audit", new { id = auditActionViewModel.AuditControllerId });
                return Json(new { success = true, url = url, replaceTarget = "action" });
            }

            return PartialView("_AdicionarAction", auditActionViewModel);
        }

        public ActionResult DeletarAction(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var auditActionViewModel = _auditControllerAppService.GetActionById(id.Value);
            if (auditActionViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeletarAction", auditActionViewModel);
        }

        // POST: Clientes/Delete/5

        [HttpPost, ActionName("DeletarAction")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletarActionConfirmed(Guid id)
        {
            var auditControllerId = _auditControllerAppService.GetActionById(id).AuditControllerId;
            _auditControllerAppService.RemoveAction(id);

            string url = Url.Action("ListarActions", "Audit", new { id = auditControllerId });
            return Json(new { success = true, url = url, replaceTarget = "action" });
        }

        public ActionResult DetailsAuditHistory(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var auditViewModel = _auditControllerAppService.GetAuditById(id.Value);
            if (auditViewModel == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsHistory", auditViewModel);
        }

        private void RemoverActionsExistentesNoControllerEcarregarViewBag(AuditControllerViewModel auditController)
        {
            var actionListSemActionsExistentes = new List<string>();

            Assembly asm = Assembly.GetAssembly(typeof(MvcApplication));

            var actionList = new SelectList(
                asm.GetTypes()
                    .Where(type => typeof(System.Web.Mvc.Controller).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true)
                    .Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name })
                    .Where(x => x.Controller == auditController.ControllerName && !x.Action.Contains("Confirmed"))
                    .GroupBy(x => x.Action, x => x.Controller, (key, g) => new { Action = key })
                    .ToList(), string.Empty, "Action");



            foreach (var action in actionList)
            {
                if (!auditController.AuditActionList.Any(ac => ac.ActionName == action.Text))
                {
                    actionListSemActionsExistentes.Add(action.Text);
                }
            }

            ViewBag.ActionList = new SelectList(actionListSemActionsExistentes);
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
