using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Model;

namespace Task1.Method
{
    public static class DataTypeParser
    {
        public static List<DataType> DoTree(MatchCollection collection)
        {
            List<DataType> dataTypes = new List<DataType>();
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
