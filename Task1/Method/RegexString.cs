using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Method
{
    public static class RegexString
    {
        public static string LeafDataRGX { get { return "(?<name>\\w*)\\s*OBJECT-TYPE\\s*SYNTAX(?<syntax>.*?)ACCESS(?<access>.*?)STATUS(?<status>.*?)DESCRIPTION\\s*\"(?<description>.*?)\"\\s*::=\\s{\\s(?<op>[a-zA-Z0-9]*)\\s*(?<index>[0-9]*)\\s*}"; } } 
        public static string DataTypeRGX { get { return "(?<TypeName>\\w*\\s*)::=\\s*\\[(?<APP>\\s*\\w*\\s*)(?<typeID>\\d+)\\s*\\]\\s*(?<typeTYPE>\\w+)\\s+(?<parentType>\\w+\\s*\\w*)\\s*(?<restrictions>\\(?.*?\\)\\)?)"; } }
        public static string LeafRGX { get { return "\\s*(?<restrictions>[0-9a-zA-Z-]*)\\s*OBJECT\\sIDENTIFIER\\s::=\\s{\\s(?<res>[^}]*)}"; } }
        public static string ImportsRGX { get { return "IMPORTS[A-z,\\-\\s\\w]*;"; } }
        public static string ImportSortedRGX { get { return "(?<datas>[A-z-,\\s]*) FROM (?<from>[0-9A-z-]*)"; } }

    }
}
