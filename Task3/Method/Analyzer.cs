using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Enums;
using Task3.Model;

namespace Task3.Method
{
    public static class Analyzer
    {
        public static void AnalyzeVariableBindings(VariableBinding variableBindings)
        {
            DataType dataTypeTag = ConverterToEnum.ToSimpleDatatype(variableBindings.TagData);
            int dataLength = ToLength(variableBindings.LengthData);
            string data = AnalyzeData(dataTypeTag, variableBindings.Data);

            DataType dataTypeOID = ConverterToEnum.ToSimpleDatatype(variableBindings.TagOID);
            int dataOID = ToLength(variableBindings.LengthOID);
            string oid = ConverterToOID.ToOID(variableBindings.OID);
            
            AnalyzedVB analyzedVB = new AnalyzedVB()
            {
                TagData = dataTypeTag,
                LengthData = dataLength,
                Data = data,
                TagOID = dataTypeOID,
                LengthOID = dataOID,
                OID = oid
            };
            ConsoleInfo.AnalyzedVariableBindings(analyzedVB);
            ConsoleInfo.Dots();    

        }
        public static string AnalyzeData(DataType datatype, string hex) {
            int intData = (int)datatype;
            switch (intData)
            {
                //TODO octet_string
                case (int)DataType.Timeticks:
                case (int)DataType.INTEGER:
                    int num = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                    return num.ToString();
                default:
                    return "";
            }
            return "";
        }
        public static int ToLength(string hex)
        {
            string temp = hex.ElementAt(0).ToString() + hex.ElementAt(1).ToString();
            return int.Parse(temp, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
