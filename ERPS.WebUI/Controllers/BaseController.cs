using ERPS.Infrastructure;
using Infrastructure;
using Microsoft.Practices.Unity;
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

        //[Dependency]
        //public ILog Log { get; set; }

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

        public JsonResult DomainServiceError()
        {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            ModelState.Keys.Where(it => ModelState[it].Errors.Count > 0).ToList()
                .ForEach(it => ModelState[it].Errors.ToList().ForEach(node =>
                    sb.Append(node.ErrorMessage + " ")));
            return Json(new
            {
                Success = false,
                Message = sb.ToString()
            }, JsonRequestBehavior.AllowGet);
            //return Content(
            //    _json.Serialize(
            //    new { 
            //        Success=false,
            //        Message=sb.ToString()
            //    }
            //    )
            //    , "text/html;charset=UTF-8");
        }

        public JsonResult CustomCheckedResult(String message,bool success)
        {
            return Json(new
            {
                Success = success,
                Message = message
            }, JsonRequestBehavior.AllowGet);
        }
    }
}