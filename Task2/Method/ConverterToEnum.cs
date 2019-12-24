using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Enums;

namespace Task2.Method
{
    public static class ConverterToEnum
    {
        public static DataType ToSimpleDatatype(string str)
        {
            switch (str)
            {
                case "INTEGER":
                    return DataType.INTEGER;
                case "BIT STRING":
                    return DataType.BIT_STRING;
                case "OCTET STRING":
                    return DataType.OCTET_STRING;
                case "NULL":
                    return DataType.NULL;
                case "OBJECT IDENTIFIER":
                    return DataType.OBJECT_IDENTIFIER;
                default:
                    return DataType.UNKNOWN;
            }
        }
    }
}
