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
                    TagNumber = (int)simpleDataType
                };
                return tag;
            }
            return null;
        }
        public static LengthData CodeData(string value, Tag tag)
        {
            LengthData LData = new LengthData();
            string hexValue = "";
            if (tag.TagNumber == (int)SimpleDataType.INTEGER)
            {
                try
                {
                    int newValue = Convert.ToInt32(value);
                    hexValue = Convert.ToString(newValue, 16);
                    int length = hexValue.Length/2;
                }
                catch
                {
                    //Console.WriteLine("C");
                    //return null;
                }
            }
            if(int.Parse(hexValue) < 128)
            {
                LData.LType = LengthType.ShortForm;
            }
            else if(int.Parse(hexValue) >= 128)
            {
                LData.LType = LengthType.LongForm;
            }

            return LData;
           // int hexValue = Convert.ToInt32(value, 16);
        }
    }
}
