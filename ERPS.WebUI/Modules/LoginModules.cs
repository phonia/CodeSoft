using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPS.WebUI.Modules
{
    public class LoginModules:IHttpModule
    {
        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += context_PreRequestHandlerExecute;
        }

        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication httpApplication = (HttpApplication)sender;
            if (httpApplication.Session["User"] == null && !httpApplication.Request.Path.Equals("/User/Login"))
            {
                //httpApplication.Response.Redirect("\\/User\\/Login");
                //httpApplication.Response.Redirect("/User/Login");
                httpApplication.Response.Redirect("\\User\\Login");
            }
        }
    }
}