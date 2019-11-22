using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Method
{
    public static class RegexString
    {
        //(?<name>[a-zA-z ]*)\sOBJECT-TYPE\s*SYNTAX\W(?<syntax>[a-zA-z ]*)\W(?<rest>.*?)\s*ACCESS\W(?<access>.*?)\s*STATUS\W(?<status>.*?)\s*DESCRIPTION\s*\"(?<description>.*?)(\s*|INDEX\s*{\W(?<indexx>[a-zA-z,\s\w]*)})\w*\s*::=\s{\s(?<op>[a-zA-Z0-9]*)\s*(?<index>[0-9]*)\s*}
        public static string LeafDataRGX { get { return "(?<name>\\w*)\\s*OBJECT-TYPE\\s*SYNTAX(?<syntax>.*?)ACCESS(?<access>.*?)STATUS(?<status>.*?)DESCRIPTION\\s*\"(?<description>.*?)\"\\s*::=\\s{\\s(?<op>[a-zA-Z0-9]*)\\s*(?<index>[0-9]*)\\s*}"; } } 
        public static string DataTypeRGX { get { return @"(?<TypeName>\w*\s*)::=\s*\[(?<APP>\s*\w*\s*)(?<typeID>\d+)\s*\]\s*(?<typeTYPE>[A-Z]*)\s+(?<parentType>[a-zA-Z\s]*)\s+(\s|(?<restrictions>[0-9a-zA-z.() ]*))\s"; } }
        public static string LeafRGX { get { return @"\s*(?<restrictions>[0-9a-zA-Z-]*)\s*OBJECT\sIDENTIFIER\s::=\s{\s(?<res>[^}]*)}"; } }
        public static string ImportsRGX { get { return @"IMPORTS[A-z,\-\s\w]*;"; } }
        public static string ImportSortedRGX { get { return @"(?<datas>[A-z-,\s]*) FROM (?<from>[0-9A-z-]*)"; } }
        //(?<sequnce>[a-zA-z]*)\W::=\s*SEQUENCE\W{\s*(?<main>[a-zA-Z,.\w\s()]*)\s*}
        public static string ImportSEQUENCE { get { return @"(?<sequnce>[a-zA-z]*)\W::=\s*SEQUENCE\W{\s*(?<main>[a-zA-Z,.\w\s()]*)\s*}"; } }

    }
}
