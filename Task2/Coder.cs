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
        public static LengthValueData CodeData(string value, Tag tag)
        {
            LengthValueData LData = new LengthValueData() { Value = value };
            string hexValue = "";
            if (tag.TagNumber == (int)SimpleDataType.INTEGER)
            {
                try
                {
                    int newValue = Convert.ToInt32(value);
                    hexValue = Convert.ToString(newValue, 16);
                    int length = hexValue.Length;
                    LData.LengthAmount = length;
                    LData.ValueHex = hexValue;
                    LData.LType = length < 2 ? LengthType.ShortForm : LengthType.ShortForm;
                }
                catch
                {
                    //Console.WriteLine("C");
                    //return null;
                }
            }
            else if(tag.TagNumber == (int)SimpleDataType.OCTET_STRING)
            {
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes(value);
                    foreach (byte bt in bytes)
                    {
                        hexValue += Convert.ToString(bt, 16);
                    }
                    int length = hexValue.Length;
                    LData.LengthAmount = length;
                    LData.ValueHex = hexValue;
                    //hexValue = Convert.ToString(bytes);
                    //string strValue = Encoding.ASCII.GetString(value);

                    // byte[] octets = Encoding.ASCII.GetBytes(value);
                }
                catch
                {
                   
                }
            }
            else if(tag.TagNumber == (int)SimpleDataType.NULL)
            {
                try
                {
                    int length = hexValue.Length;
                    LData.LengthAmount = length;
                    LData.ValueHex = hexValue;
                }
                catch
                {

                }
            }
            else if(tag.TagNumber == (int)SimpleDataType.BIT_STRING)
            {
                try
                {
                    int byteCount = Encoding.ASCII.GetByteCount(value);
                    if (byteCount == 1)
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(value);
                        byte bitString = bytes[0];
                        hexValue = Convert.ToString(bitString, 16);
                        int length = hexValue.Length;
                        LData.LengthAmount = length;
                        LData.ValueHex = hexValue;
                        LData.LType = length < 2 ? LengthType.ShortForm : LengthType.ShortForm;
                    }
                }
                catch
                {

                }
            }
            //if(int.Parse(hexValue) < 128)
            //{
                
            //}
            //else if(int.Parse(hexValue) >= 128)
            //{
            //    LData.LType = LengthType.LongForm;
            //}

            return LData;
           // int hexValue = Convert.ToInt32(value, 16);
        }
    }
}
