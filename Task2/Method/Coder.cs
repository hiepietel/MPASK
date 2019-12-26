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
        public static Tag CodeTagFromDic(string type, Dictionary<string, MIBDataType> datas)
        {
            KeyValuePair<string, MIBDataType> keyValuePair = datas.FirstOrDefault(t => t.Key.ToLower() == type.ToLower());
            MIBDataType datatype = keyValuePair;
            var simpleDataType = ConverterToEnum.ToSimpleDatatype(type);
            return new Tag();
        }
        public static Tag CodeTag(string type)
        {

            var simpleDataType = ConverterToEnum.ToSimpleDatatype(type);
            if (simpleDataType != DataType.UNKNOWN)
            {
                Tag tag = new Tag()
                {
                    TagNumber = (int)simpleDataType,
                    TClass = TagClass.universal
                };
                if (tag.TagNumber < 10)
                {
                    tag.TPC = TagPC.Primitive;

                }
                else
                {
                    tag.TPC = TagPC.Constructed;
                }
                
                return tag;
            }
            return new Tag() { TPC = TagPC.Constructed };
        }
        public static ConstructedData CodeConstructedData(ConstructedDataSchema constructedDataSchema, List<string> data)
        {
            ConstructedData constructedData = new ConstructedData() {};

            foreach(KeyValuePair<string, string> keyValuePair in constructedDataSchema.Objects)
            {
                Tag tag = CodeTag(keyValuePair.Value);
                SimpleData simpleData = CodeSimpleData(data.First(), tag);
                data.RemoveAt(0);
                constructedData.Objects.Add(tag, simpleData);
            }
            return constructedData;
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
                        hexValue = newValue < 128 ? hexValue : "00" + hexValue;
                        int length = hexValue.Length;
                        LData.LengthAmount = length/2;
                        LData.ValueHex = hexValue;
                        LData.LType = newValue < 128 ? LengthType.ShortForm : LengthType.ShortForm;
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
                        LData.LType = LengthType.LongForm;
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
                        LData.LType = LengthType.ShortForm;
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
                            LData.LType = LengthType.ShortForm;
                        }
                    }
                    catch
                    {


                    }
                    break;
                case (int)DataType.OBJECT_IDENTIFIER:
                    try
                    {
                        string[] data = value.Split('.');
                        if(data.Length > 1)
                        {
                            string first = Convert.ToString(int.Parse(data[0]) * 40 + int.Parse(data[1]), 16);
                            hexValue += first;
                            List<string> listData = data.ToList();
                            listData.RemoveAt(0);
                            listData.RemoveAt(0);
                            if(listData.Count > 0)
                            {
                                foreach(string single in listData)
                                {
                                    int singleInt = int.Parse(single);
                                    hexValue += singleInt.IntToHex(2);
                                }
                            }
                            int length = hexValue.Length / 2;
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
