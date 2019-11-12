using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Logs
{
    public static class Logger
    {
        public static void Error(string s)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("data//log.txt",true))
            {
                DateTime dateTime = DateTime.Now;
                file.WriteLine(dateTime.ToShortTimeString() + " Error: "+ s);
            }
        }
        public static void Warn(string s)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("data//log.txt", true))
            {
                DateTime dateTime = DateTime.Now;
                file.WriteLine(dateTime.ToShortTimeString() + " Warn: " + s);
            }
        }
        public static void Info(string s)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("data//log.txt", true))
            {
                DateTime dateTime = DateTime.Now;
                file.WriteLine(dateTime.ToShortTimeString() + " Info: " + s);
            }
        }
    }
}
