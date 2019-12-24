using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Method;
using Task2.Enums;
using Task2.Model;

namespace Task2.Method
{
    public static class Coder
    {

        public static Tag CodeTag(string type)
        {

            var simpleDataType = ConverterToEnum.ToSimpleDatatype(type);
            if(simpleDataType != DataType.UNKNOWN)
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
        public static ConstructedData CodeConstructedData(ConstructedDataSchema constructedDataSchema, List<string> data)
        {
            ConstructedData constructedData = new ConstructedData() {};

            foreach(KeyValuePair<string, string> keyValuePair in constructedDataSchema.Objects)
            {
                Tag tag = CodeTag(keyValuePair.Key);
                SimpleData simpleData = CodeSimpleData(data.First(), tag);
                data.RemoveAt(0);
                constructedData.Objects.Add(simpleData);
            }
            return constructedData;
        }
        public static SimpleData CodeViaOID(string value, Tag tag, LeafNode leafNode)
        {

            return null;
        }
        public static SimpleData CodeSimpleData(string value, Tag tag)
        {
            SimpleData LData = new SimpleData() { Value = value };
            string hexValue = "";
            
            var simpleDataType = tag.TagNumber;
            switch (simpleDataType)
            {
                case (int)DataType.INTEGER:
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
                    break;
                case (int)DataType.OCTET_STRING:
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
                    break;
                case (int)DataType.NULL:
                    try
                    {
                        int length = hexValue.Length;
                        LData.LengthAmount = length;
                        LData.ValueHex = hexValue;
                    }
                    catch
                    {

                    }
                    break;
                case (int)DataType.BIT_STRING:
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
                    break;
            };
            return LData;
        }
    }
}
