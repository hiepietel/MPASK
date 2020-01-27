using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.Model
{
    public class AnalyzedVB
    {
        public DataType TagOID { get;set;}
        public int LengthOID { get; set; }
        public string OID { get; set; }
        public DataType TagData { get; set; }
        public int LengthData { get; set; }
        public string Data { get; set; }
    }
}
