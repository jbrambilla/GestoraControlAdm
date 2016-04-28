using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            EGestoraContext context = new EGestoraContext();
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            bool hasPostAttribute = filterContext.ActionDescriptor
                    .GetCustomAttributes(typeof(HttpPostAttribute), false)
                    .Any();

            if (VerificacaoParaAuditar(context, controller, action) && hasPostAttribute)
            {
                var request = filterContext.HttpContext.Request;
                // Generate an audit
                Audit audit = new Audit()
                {
                    // Your Audit Identifier     
                    AuditId = Guid.NewGuid(),
                    // Our Username (if available)
                    UserName = (request.IsAuthenticated) ? filterContext.HttpContext.User.Identity.Name : "Anonymous",
                    // The IP Address of the Request
                    IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress,
                    // The URL that was accessed
                    AreaAccessed = request.RawUrl
                };

                context.Audit.Add(audit);
                context.SaveChanges();
            }

            base.OnActionExecuted(filterContext);
        }

        private bool VerificacaoParaAuditar(EGestoraContext context, string controller, string action)
        {
            var auditController = context.AuditControllers.Where(a => a.ControllerName.Replace("Controller", "") == controller).FirstOrDefault();
            if (auditController == null)
            {
                return false;
            }

            if (auditController.AuditActionList.Count <= 0)
            {
                return true;
            }

            if (!auditController.AuditActionList.Any(a => a.ActionName == action))
            {
                return false;
            }

            return true;
        }
    }
}
