using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Task2.Enums;

namespace Task2.Method
{
    public static class Validator
    {

        public static bool Validate(Restricion restricion, string type, string value)
        {
            DataType dataType = ConverterToEnum.ToSimpleDatatype(type);
            if (dataType == DataType.INTEGER)
            {
                int valueInt = int.Parse(value);
                if ((valueInt > restricion.Min) && (valueInt < restricion.Max))
                {
                    return true;
                }
            }
            else if (dataType == DataType.OCTET_STRING || dataType == DataType.BIT_STRING)
            {
                int length = value.Length;
                if (length <= restricion.Max)
                {
                    return true;
                }
            }
            else if (dataType == DataType.NULL && value == "") return true;
            else if (dataType == DataType.OBJECT_IDENTIFIER) return true;
            if(dataType == DataType.UNKNOWN)
            {

            }


            return false;
        }
        public static bool IsOID(this string oid)
        {
            int empty =0;
            string[] datas = oid.Split('.');
            foreach(string data in datas)
            {
                if (!int.TryParse(data, out empty)) return false;
            }
            return true;
        }
    }
}
