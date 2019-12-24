using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;

namespace Task2.Model
{
    public class LengthValueData
    {
        public LengthType LType { get; set; }
        public int LengthAmount { get; set; }
        public string ValueHex { get; set; }
        public object Value { get; set; }
    }
}
