using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Web.Mvc;

namespace EGestora.GestoraControlAdm.Infra.CrossCutting.MvcFilters
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
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

            EGestoraContext context = new EGestoraContext();
            context.Audit.Add(audit);
            context.SaveChanges();

            base.OnActionExecuted(filterContext);
        }
    }
}
