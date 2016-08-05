using EPRS.Service;
using ERPS.Models;
using Infrastructure;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPS.WebUI.Interceptor
{
    public class UserPermissonValidateInterceptor : IInterceptionBehavior
    {
        //[Dependency]
        //public IUserService UserService { get; set; }
        [Dependency]
        public IActionPermissionRepository ActionPermissionRepository { get; set; }
        [Dependency]
        public IPositionRepository PositionRepository { get; set; }
        [Dependency]
        public IUnitOfWork UnitOfWork { get; set; }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            
            //根据调用类名以及方法名判断与用户信息判断是否具有权限

            //String className = input.MethodBase.DeclaringType.Name;
            //Attribute[] attrs = (Attribute[])input.MethodBase.GetCustomAttributes(false);
            //if (attrs == null || attrs.Length <= 0) return getNext()(input, getNext);
            //foreach (var node in attrs)
            //{
            //    //
            //}
            //if (MSUserDTO == null) return getNext()(input, getNext); 

            //if ((MSUserDTO!=null&&!String.IsNullOrWhiteSpace(MSUserDTO.Name)&&MSUserDTO.Name.Equals(Constant.DefautlUserName))
            //    || (input.MethodBase.DeclaringType.Name.Equals("IMSUserService") && input.MethodBase.Name.Equals("Login")))
            //{
            if ( HttpContext.Current.Request.Path.Equals("/User/Login")
                || HttpContext.Current.Request.Path.Contains("Home")
                ||Authority())
            {
                return getNext()(input, getNext);
            }
            else
            {
                throw new UserPermissonException("用户" + ((SUserDTO)HttpContext.Current.Session["User"]).LoginName + "没有权限！");
            }
        }

        bool Authority()
        {
            PositionRepository.UnitOfWork = UnitOfWork;
            ActionPermissionRepository.UnitOfWork = UnitOfWork;
            SUserDTO user=(SUserDTO)HttpContext.Current.Session["User"];
            String url = HttpContext.Current.Request.Path;
            if (PositionRepository.GetAll().Where(it => it.Id == user.PositionId && it.Department.Code == "1").FirstOrDefault() != null)
                return true;
            var p= PositionRepository.GetAll().Where(it => it.Id == user.PositionId).First();
            var ap = ActionPermissionRepository.GetAll().Where(it => it.Url.Equals(url)).First();
            if (p.ControlPower.Split(',').ToList().Contains(ap.Id.ToString()))
                return true;
            return false;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}