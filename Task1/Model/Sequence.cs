using Model;
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
        public string Name { get; set; }
        public string Data { get; set; }
        public Restricion? Restrictions { get; set; }
    }
}
