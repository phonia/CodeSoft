using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPS.WebUI.Controllers
{
    public class CustomJsonResult:JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context);
        }
    }
}