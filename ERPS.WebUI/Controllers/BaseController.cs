using ERPS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ERPS.WebUI.Controllers
{
    public class BaseController:Controller
    {

        protected JavaScriptSerializer _json = new JavaScriptSerializer();

        protected override void OnException(ExceptionContext filterContext)
        {
            var excepton = filterContext.Exception;
            if (excepton is DomainServiceException)
            {
                ModelState.AddModelError("DomainServiceError", excepton.Message);
                filterContext.ExceptionHandled = true;
                ActionInvoker.InvokeAction(filterContext.Controller.ControllerContext, "DomainServiceError");
            }
        }

        public ActionResult DomainServiceError()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            ModelState.Keys.Where(it => ModelState[it].Errors.Count > 0).ToList()
                .ForEach(it => ModelState[it].Errors.ToList().ForEach(node =>
                    sb.Append(node.ErrorMessage + " ")));
            return Content(
                _json.Serialize(
                new { 
                    Success=false,
                    Message=sb.ToString()
                }
                )
                , "text/html;charset=UTF-8");
        }
    }
}