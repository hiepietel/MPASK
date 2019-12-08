using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Rgx
{
    public static class RgxComp
    {
        //Word and Digit
        public static string WaD { get { return D + W; } }
        public static string W { get { return "A-z"; } }
        public static string D { get { return "0-9"; } }
        public static string Quotation { get { return "\""; } }
    }
}
