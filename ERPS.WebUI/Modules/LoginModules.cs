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
            //HttpApplication httpApplication = (HttpApplication)sender;
            //if (httpApplication.Session["MSUserDTO"] == null&&!httpApplication.Request.Path.Equals("/MSUser/Login"))
            //{
            //    //httpApplication.Response.Redirect("\\/MSUser\\/Login");
            //    //httpApplication.Response.Redirect("/MSUser/Login");
            //    httpApplication.Response.Redirect("\\MSUser\\Login");
            //}
        }
    }
}