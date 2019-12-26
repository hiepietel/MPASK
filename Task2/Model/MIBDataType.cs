using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Type = Enums.Type;


namespace Task2.Model
{
    public class MIBDataType
    {
        public Type MibType { get; set; }
        public Visibility MibVisibility { get; set; }
        public int Index { get; set; }

        public static implicit operator MIBDataType(KeyValuePair<string, MIBDataType> v)
        {
            throw new NotImplementedException();
        }
    }
}
