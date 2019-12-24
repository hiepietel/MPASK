using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;

namespace Task2.Model
{
    public class ConstructedDataSchema
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public Dictionary<string, string> Objects { get; set; }

    }
}
