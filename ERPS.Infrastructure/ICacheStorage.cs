using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERPS.Infrastructure
{
    public interface ICacheStorage
    {
        void Add(String key, Object value);
        void Remove(String key);
        T Retrieve<T>(String key);
        String GetKey(String DataStructName, String TypeName, String id);
    }
}
