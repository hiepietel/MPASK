using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Enums;
using Enums;
using Type = Enums.Type;

namespace Task1.Method
{
    public static class ConverterToEnum
    {
        public static STATUS ToStatus(string str)
        {
            switch (str)
            {
                case "current":
                    return STATUS.current;
                case "mandatory":
                    return STATUS.mandatory;
                case "deprecated":
                    return STATUS.deprecated;
                case "obsolete":
                    return STATUS.obsolete;
                case "optional":
                    return STATUS.optional;
                default:
                    return STATUS.unknown;
            }
        }
        public static ACCESS ToAccess(string str)
        {
            switch (str)
            {
                case "read-only":
                    return ACCESS.read_only;
                case "read-write":
                    return ACCESS.read_write;
                case "not-accessible":
                    return ACCESS.not_accessible;
                default:
                    return ACCESS.unknown;
            }
        }
        public static Visibility ToVisibility(string str)
        {
            switch (str)
            {
                case "IMPLICIT":
                    return Visibility.IMPLICIT;
                case "EXPLICIT":
                    return Visibility.EXPLICIT;
                default:
                    return Visibility.UNKNOWN;
            }
        }
        public static Type ToType(string str)
        {
            switch (str)
            {
                case "APPLICATION":
                    return Type.APPLICATION;
                default:
                    return Type.UNKNOWN;
            }
        }
        public static DATATYPE ToDatatype(string str)
        {
            switch (str)
            {
                case "OCTET STRING":
                    return DATATYPE.OCTET_STRING;
                case "INTEGER":
                    return DATATYPE.INTEGER;                   
                case "OBJECT IDENTIFIER":
                    return DATATYPE.OBJECT_IDENTIFIER;                
                case "PhysAddress":
                    return DATATYPE.PHYSADDRESS;                
                case "DisplayString":
                    return DATATYPE.DISPLAY_STRING;                
                case "NetworkAddress":
                    return DATATYPE.DISPLAY_STRING;
                case "IpAddress":
                    return DATATYPE.IPADDRESS;
                case "Counter":
                    return DATATYPE.COUNTER;
                case "Gauge":
                    return DATATYPE.GAUGE;
                default:
                    return DATATYPE.UNKNOWN;
            }
        }
    }
}
