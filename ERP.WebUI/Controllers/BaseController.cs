using ERP.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ERP.WebUI.Controllers
{
    public class BaseController:Controller
    {
        protected ServiceFactory _serviceFactory = new ServiceFactory();
        protected JavaScriptSerializer _json = new JavaScriptSerializer();

        protected override void OnException(ExceptionContext filterContext)
        {
            //base.OnException(filterContext);
            var exception = filterContext.Exception;
            if (exception is DomainException)
            {
                ModelState.AddModelError("", exception.Message);
                filterContext.ExceptionHandled = true;
                //var actionName = RouteData.GetRequiredString("action");
                //ActionInvoker.InvokeAction(filterContext.Controller.ControllerContext, actionName);
                ActionInvoker.InvokeAction(filterContext.Controller.ControllerContext, "DomainError");
            }
        }

        public ActionResult DomainError()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            //ModelState.Keys.ToList().ForEach(it => sb.Append(ModelState[it].Errors.Count > 0 ? ModelState[it].Errors[0].ErrorMessage + " " : " "));
            ModelState.Keys.Where(it => ModelState[it].Errors.Count > 0).ToList()
                .ForEach(it => ModelState[it].Errors.ToList().ForEach(node =>
                    sb.Append(node.ErrorMessage + " ")));
            return Content(_json.Serialize(
                new
                {
                    Success = false,
                    Message = sb.ToString()
                }),
                "text/html;charset=UTF-8");
        }
    }
}