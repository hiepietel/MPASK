using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;

namespace Task2.Model
{
    public class ConstructedData
    {
        public string Name { get; set; }
        public DataType ConDataType { get; set; }

        public List<SimpleData> Objects{ get; set; }

        public ConstructedData()
        {
            Objects = new List<SimpleData>();
        }
    }
}
