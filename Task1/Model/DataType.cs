using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Enums;

namespace Task1.Model
{
    public class DataType
    {
        public string Name { get; set; }
        public VISIBILITY Visibility { get; set; }
        public KEYWORD Keyword { get; set; }
        public string MotherType { get; set; }
    }
}
