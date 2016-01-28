using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERP.Infrastructure
{
    public class ExceptionInterceptor:IInterceptionBehavior
    {
        //private ILog _log = null;
        //public ExceptionInterceptor(ILog log)
        //{
        //    this._log = log;
        //}
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn msg = null;
            try
            {
                msg = getNext()(input, getNext);

                if (msg.Exception != null)
                {
                    //_log.WriteLog(msg.Exception.StackTrace);
                    //_log.WriteLog(msg.Exception.Message);
                    msg.Exception = null;
                    msg.ReturnValue = Activator.CreateInstance(input.MethodBase.DeclaringType.GetMethod(input.MethodBase.Name).ReturnType);
                }
            }
            catch (Exception ex)
            {
                //_log.WriteLog(ex.StackTrace);
                //_log.WriteLog(ex.Message);
                msg = input.CreateExceptionMethodReturn(null);
                msg.ReturnValue = Activator.CreateInstance(input.MethodBase.DeclaringType.GetMethod(input.MethodBase.Name).ReturnType);
            }

            return msg;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
