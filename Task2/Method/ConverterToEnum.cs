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
                case "Counter":
                case "COUNTER":
                case "TimeTicks":
                case "Gauge":
                case "GAUGE":
                    return DataType.INTEGER;
                case "BIT STRING":
                case "BIT_STRING":
                    return DataType.BIT_STRING;
                case "OCTET STRING":
                case "OCTET_STRING":
                case "DisplayString":
                case "PhysAddress":
                    return DataType.OCTET_STRING;
                case "NULL":
                    return DataType.NULL;
                case "OBJECT IDENTIFIER":
                case "OBJECT_IDENTIFIER":
                    return DataType.OBJECT_IDENTIFIER;
                case "SEQUENCE":
                    return DataType.SEQUENCE;
                default:
                    return DataType.UNKNOWN;
            }
        }
    }
}
