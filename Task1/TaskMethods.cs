using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Enums;

namespace Task1
{
    public static class TaskMethods
    {   
        public static string RemoveSpecialCharacter(this string str){
            return str.Trim().Replace("\r", "").Replace("\n", "");
        }
        public static string ReadFile(string source)
        {
            string toReturn = "";
            try
            {
                using (StreamReader sr = new StreamReader(source))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line.Contains("--"))
                        {
                            int pos = line.IndexOf("--");
                            line = line.Remove(pos, line.Length - pos);
                        }
                        toReturn += line;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return toReturn;
        }
        public static STATUS ToStatus(string str)
        {
            switch (str)
            {
                case "current":
                    return STATUS.current;
                case "mandatory":
                    return STATUS.mandatory;
                case "deprecated":
                    return STATUS.deprecated;
                default:
                    return STATUS.unknown;
            }
        }
        public static ACCESS ToAccess(string str)
        {
            switch (str)
            {
                case "read-only":
                    return ACCESS.read_only;
                case "read_write":
                    return ACCESS.read_write;
                case "not-accessible":
                    return ACCESS.not_accessible;
                default:
                    return ACCESS.unknown;
            }
        }
        public static KEYWORD ToKeyword(string str)
        {
            switch (str)
            {
                case "IMPLICIT"
                    return KEYWORD.IMPLICIT;
                case "EXPLICIT":
                    return KEYWORD.EXPLICIT;
                default:
                    return KEYWORD.UNKNOWN;
            }
        }
        public static VISIBILITY ToVisibility(string str)
        {
            switch (str)
            {
                case "APPLICATION":
                    return VISIBILITY.APPLICATION;
                default:
                    return VISIBILITY.UNKNOWN;
            }
        }
    }
}
