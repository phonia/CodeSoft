using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ERPS.WebUI.Modules
{
    public class LoginModules : IHttpModule
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
            if (httpApplication.Request.Path.ToLower().Contains(".css")
                || httpApplication.Request.Path.ToLower().Contains(".js")
                ||httpApplication.Request.Path.ToLower().Contains(".png")
                ||httpApplication.Request.Path.ToLower().Contains(".")) return;
            if (httpApplication.Session["User"] == null
                && !httpApplication.Request.Path.Equals("/User/Login"))
            {
                //httpApplication.Response.Redirect("\\/User\\/Login");
                //httpApplication.Response.Redirect("/User/Login");
                httpApplication.Response.Redirect("\\User\\Login");
            }
        }
    }
}