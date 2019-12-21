using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;

namespace Task2.Model
{
    public class Tag
    {
        public TagClass TClass { get; set; }
        public TagPC TPC { get; set; }
        public int Length { get; set; }
    }
}
