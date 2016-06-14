using ERPS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPRS.Service.Attribute
{
    public class SCache : ICacheStorage
    {
        public void Add(string key, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public T Retrieve<T>(string key)
        {
            throw new NotImplementedException();
        }

        public string GetKey(string DataStructName, string TypeName, string id)
        {
            throw new NotImplementedException();
        }
    }
}
