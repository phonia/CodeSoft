using Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EPRS.Service.Log
{
    public class SLog:ILog
    {
        public String LogPath { get; set; }

        private static readonly object _lockObject = new object();

        public void WriteLog(string message)
        {
            String path = "";
            lock (_lockObject)
            {
                FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    sw.WriteLine(String.Format("yyyy-MM-dd hh:mm:ss ",System.DateTime.Now)+message);
                }
                if (fileStream != null) fileStream.Close();
            }
        }
    }
}
