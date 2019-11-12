using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Enums;

namespace Task1.Model
{
    public class LeafData
    {
        public int Id { get; set; }

        public string ObjectType { get; set; }
        public string Description { get; set; }
        public ACCESS Access { get; set; }
        public STATUS Status { get; set; }
        public string ParentName { get; set; }
        public int Index { get; set; }
    }
}
