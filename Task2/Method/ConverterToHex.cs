using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Model;
using Task2.Enums;

namespace Task2.Method
{
    public static class ConverterToHex
    {
        public static string IntToHex(this int dec, int size = -1)
        {
            string strHex = dec.ToString("X");
            if (size > 0)
                while (strHex.Length < size)
                {
                    strHex = "0" + strHex;
                }
            return strHex;
        }
        public static string BinToHex(this string bin, int size =-1 )
        {
            string strHex = Convert.ToInt32(bin, 2).ToString("X");
            if(size > 0)
                while (strHex.Length < size)
                {
                    strHex = "0" + strHex;
                }
            return strHex;

        }
        public static string TagHex(Tag tag)
        {
            string tClass = Convert.ToByte(tag.TClass).ToString("X2");
            tClass = tClass.Remove(0, tClass.Length - 2);
            string tPC  = Convert.ToByte(tag.TClass).ToString("X1");
            tPC= tPC.Remove(0, tPC.Length - 1);
            string tNumber = Convert.ToString(Convert.ToByte(tag.TagNumber),2);
            while(tNumber.Length < 5)
            {
                tNumber = "0" + tNumber;
            }
            return (tClass + tPC + tNumber).BinToHex(2);
        }
        public static string SimpleDataHex(Tag tag, SimpleData simpleData)
        {
            string hexStr = TagHex(tag);
            //add length
            string length = simpleData.LengthAmount.IntToHex(2);
            hexStr += length;
            //end of length 
            if(tag.TagNumber != (int)DataType.NULL)
                hexStr += simpleData.ValueHex;
            
            return hexStr;
        }
    }
}
