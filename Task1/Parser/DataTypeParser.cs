using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Method;
using Task1.Model;
using Task1.Rgx;

namespace Task1.Parser
{
    public static class DataTypeParser
    {
        public static List<DataType> ReturnTree(string filepath, List<DataType> dataTypes)
        {
            MatchCollection matchesData = TaskMethods.CollectionRegex("data/" + filepath.ReturnFilePath(), RgxString.DataTypeRGX);
            // MatchCollection matchesData = TaskMethods.CollectionRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.DataTypeRGX);
            List<DataType> list = DoTree(matchesData, dataTypes);
            return dataTypes;
        }
        public static List<DataType> DoTree(MatchCollection collection, List<DataType> dataTypes)
        {
            foreach (Match match in collection)
            {
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                string type = match.Groups[2].Value.RemoveSpecialCharacter();
                string typeId = match.Groups[3].Value.RemoveSpecialCharacter();
                string visibility = match.Groups[4].Value.RemoveSpecialCharacter();
                string datatype = match.Groups[5].Value.RemoveSpecialCharacter();
                string size = match.Groups[6].Value.RemoveSpecialCharacter();

                var dataType = new DataType()
                {
                    Id = 0,
                    Name = name,
                    Type = ConverterToEnum.ToType(type),
                    TypeIndex = int.Parse(typeId),
                    Visibility = ConverterToEnum.ToVisibility(visibility),
                    Datatype = ConverterToEnum.ToDatatype(datatype),
                    Size = size
                };
                dataTypes.Add(dataType);

            }
            return dataTypes;
        }
    }
}
