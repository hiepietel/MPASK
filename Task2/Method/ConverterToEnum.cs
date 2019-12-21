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
        public static SimpleDataType ToSimpleDatatype(string str)
        {
            switch (str)
            {
                case "INTEGER":
                    return SimpleDataType.INTEGER;
                case "BIT_STRING":
                    return SimpleDataType.BIT_STRING;
                case "OCTET STRING":
                    return SimpleDataType.OCTET_STRING;
                case "NULL":
                    return SimpleDataType.NULL;
                case "OBJECT IDENTIFIER":
                    return SimpleDataType.OBJECT_IDENTIFIER;
                default:
                    return SimpleDataType.UNKNOWN;
            }
        }
    }
}
