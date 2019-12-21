using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Method;
using Task2.Enums;
using Task2.Model;

namespace Task2
{
    public static class Coder
    {
        public static Tag CodeTag(string type)
        {

            var simpleDataType = ConverterToEnum.ToSimpleDatatype(type);
            if(simpleDataType != SimpleDataType.UNKNOWN)
            {
                Tag tag = new Tag()
                {
                    TPC = TagPC.Primitive,
                    TClass =TagClass.universal,
                    Length = (int)simpleDataType
                };
                return tag;
            }
            return null;
        }
    }
}
