using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Method
{
    public static class RegexString
    {
        //(?<name>[0-9a-zA-z ]*)\sOBJECT-TYPE\s*SYNTAX\W(?<syntax>[a-zA-z ]*)\W(?:\s*|(?<rest>[0-9a-zA-Z()\s.]*)|(?<enum>\{[0-9a-zA-z\(\)\,\.\-\s]*\}))\W*ACCESS\W*(?<access>[a-zA-Z-]*)\s*STATUS\W*(?<status>[a-zA-z]*)\s*DESCRIPTION\s*\"(?<description>[^\"]*)\"\s*(?:\s*|INDEX\s*{\s(?<indexx>[^}]*)}\s*)::=\s{\s(?<op>[a-zA-Z0-9]*)\s*(?<index>[0-9]*)\s
        public static string LeafDataRGX { get { return "(?<name>[0-9a-zA-z ]*)\\sOBJECT-TYPE\\s*SYNTAX\\W(?<syntax>[a-zA-z ]*)\\W(?:\\s*|(?<rest>[0-9a-zA-Z()\\s.]*)|(?<enum>\\{[0-9a-zA-z\\(\\)\\,\\.\\-\\s]*\\}))\\W*ACCESS\\W*(?<access>[a-zA-Z-]*)\\s*STATUS\\W*(?<status>[a-zA-z]*)\\s*DESCRIPTION\\s*\"(?<description>[^\"]*)\"\\s*(?:\\s*|INDEX\\s*{\\s(?<indexx>[^}]*)}\\s*)::=\\s{\\s(?<op>[a-zA-Z0-9]*)\\s*(?<index>[0-9]*)\\s"; } } 
        public static string DataTypeRGX { get { return @"(?<TypeName>\w*\s*)::=\s*\[(?<APP>\s*\w*\s*)(?<typeID>\d+)\s*\]\s*(?<typeTYPE>[A-Z]*)\s(?<parentType>[a-zA-Z ]*)(?:\s|\((?<restrictions>[0-9a-zA-z.() ]*)\))"; } }
        public static string LeafRGX { get { return @"\s*(?<restrictions>[0-9a-zA-Z-]*)\s*OBJECT\sIDENTIFIER\s::=\s{\s(?<res>[^}]*)}"; } }
        /// <summary>
        /// org(3)
        /// </summary>
        public static string LeafMany { get { return @"(?<name>[a-zA-Z]*)\((?<index>[0-9]*)\)"; } } 
        public static string ImportsRGX { get { return @"IMPORTS[A-z,\-\s\w]*;"; } }
        public static string ImportSortedRGX { get { return @"(?<datas>[A-z-,\s]*) FROM (?<from>[0-9A-z-]*)"; } }
        //(?<sequnce>[a-zA-z]*)\W::=\s*SEQUENCE\W{\s*(?<main>[a-zA-Z,.\w\s()]*)\s*}
        public static string ImportSEQUENCE { get { return @"(?<sequnce>[a-zA-z]*)\W::=\s*SEQUENCE\W{\s*(?<main>[a-zA-Z,.\w\s()]*)\s*}"; } }
        public static string ImportRestricion { get { return @"(?:|[A-Z]*\()(?<min>[0-9]*)\.\.(?<max>[0-9]*)(?:|\))"; } }
        public static string ImportEnum { get { return @"(?<name>[0-9A-z\-]*)\((?<index>[0-9]*)\)"; } }


    }
}
