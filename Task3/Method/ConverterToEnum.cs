using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;

namespace Task3.Method
{
    public static class ConverterToEnum
    {
        public static DataType ToSimpleDatatype(string hex)
        {
            bool corrected = int.TryParse(hex, out int result);
            if (!corrected) return DataType.UNKNOWN;
            return (DataType)result;
            //YourEnum foo = (YourEnum)Enum.Parse(typeof(YourEnum), yourString);
            //return DataType.UNKNOWN;
        }
    }
}
