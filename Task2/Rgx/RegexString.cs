using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Rgx
{
    public static class RegexString
    {
        //(?<group>[a-zA-Z]*)\s(?<groupp>[0-9A-z]*)\s::=\s(?<content>(?:[0-9]*\s|\"[A-z]*\"))
        public static string SimpleDataRGX
        {
            get
            {
                return @"(?<group>[" + RgxComp.W +
                       @"]*)\s(?<groupp>[" + RgxComp.WaD +
                       @"]*)\s::=\s(?<content>(?:[" + RgxComp.D +
                       @"]*\s|\" + RgxComp.Quotation + RgxComp.W +
                       @"*\" + RgxComp.Quotation +
                       @"))";
            }
        }
        //(?<group>[a-zA-Z]*)\s::=\WSEQUENCE\s{\s(?<content>[0-9a-zA-z\s,]*)}
        public static string SEQDeclarationRGX
        {
            get
            {
                return @"(?<group>[" + RgxComp.W +
                       @"]*)\s::=\WSEQUENCE\s{\s(?<content>[" + RgxComp.WaD + 
                       @"\s,]*)}";
            }
        }
        //(?<name>[0-9a-zA-z]*)\W(?<type>[0-9a-zA-Z]*)\W::=\W{\W(?<data>[",0-9a-zA-z\s]*)\W}
        public static string SEQAssigmentRGX
        {
            get
            {
                return @"(?<name>[" + RgxComp.WaD +
                       @"]*)\W(?<type>[" + RgxComp.WaD +
                       @"]*)\W::=\W{\W(?<data>[," + RgxComp.Quotation + RgxComp.WaD +
                       @"\s]*)\W";
            }
        }
        public static string SEQDecContent
        {
            get
            {
                return "";
            }
        }
        public static string SEQAssContent {  get { return ""; } }
    }

}
