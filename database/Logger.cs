using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class Logger
    {
        private static Logger instance;

        private Logger()
        {
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void Log(string msg)
        {
            File.AppendAllText("log.txt", $"{DateTime.Now} - {msg}");
        }
    }
}

