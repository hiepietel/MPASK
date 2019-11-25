using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    public class Sequence
    {
        public string Name { get; set; }
        public bool IsSequenceOf { get; set; }
        public string TempElements { get; set; }
        public List<ElementOfSequnce> ElementsOfSequnces { get; set; }
    }

    public class ElementOfSequnce
    {
        public string name { get; set; }
        public DataType Data { get; set; }
        public string Restrictions { get; set; }
    }
}
