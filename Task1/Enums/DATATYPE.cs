using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Enums
{
    public enum DATATYPE
    {
        UNKNOWN,
        BOOLEAN = 1,
        INTEGER= 2,
        BIT_STRING = 3,
        OCTET_STRING =4,
        NULL = 5,
        DISPLAY_STRING,
        OBJECT_IDENTIFIER = 6 ,
        ObjectDescriptor = 7,
        EXTERNAL = 8,
        REAL = 9,
        ENUMERATED = 10, 
        EMBEDDED_PDV = 11,
        UTF8String = 12,
        //Added to task2
        IPADDRESS = 32,
        COUNTER = 33,
        GAUGE = 34,
        PHYSADDRESS, 
        NETWORKADDRESS

    }
}
