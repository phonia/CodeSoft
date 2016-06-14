using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPS.WebUI.Interceptor
{
    public class CacheInterceptor : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return this.GetType().GetInterfaces();
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);
            /**
             * 缓存的处理方式：
             * 1、调用方法前查看缓存数据
             * 2、方法调用完成后必须更新缓存数据
             * 3、更新缓存的方式分为两种，一种是查询数据时向缓存写入数据，另一种是数据发生变化时将缓存内旧数据删除
             * 4、若如此做，数据的curd都必须要调用aop方法
             **/

            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}