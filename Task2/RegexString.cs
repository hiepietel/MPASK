using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class RegexString
    {
        //(?<group>[a-zA-Z]*)\s(?<groupp>[0-9A-z]*)\s::=\s(?<content>(?:[0-9]*\s|\"[A-z]*\"))
        public static string SimpleDataRGX { get { return "(?<group>[a-zA-Z]*)\\s(?<groupp>[0-9A-z]*)\\s::=\\s(?<content>(?:[0-9]*\\s|\"[A-z]*\"))"; } }
        public static string SEQdeclarationRGX { get { return @"(?<group>[a-zA-Z]*)\s::=\WSEQUENCE\s{\s(?<content>[0-9a-zA-z\s,]*)}"; } }
        //public static string SEQdeclarationRGX { get { return @"(?<group>[a-zA-Z]*)\s::=\WSEQUENCE\s{\s(?<content>[0-9a-zA-z\s,]*)}"; } }

    }
}
