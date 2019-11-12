using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Parser
{
    public static class FileString
    {
        public static string ReturnFilePath(this string filePath)
        {
            switch (filePath)
            {
                case "RFC1155-SMI":
                    return "FC1155SMI.txt";
                case "RFC-1212":
                    return "RFC1212-MIB.txt";
                case "RFC1213":
                    return "RFC1213-MIB.txt";
                case "RFC1158-MIB":
                    return "RFC1158-MIB.txt";
                default:
                    return "";
            }
        }
    }
}
