
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Enums;
using Task1.Method;
using Task1.Model;
using Task1.Rgx;

namespace Task1.Parser
{
    public static class LeafDataParser
    {
        public static LeafNode ReturnTree(string filepath, LeafNode leafs, List<DataType> dataTypes)
        {
            MatchCollection LeafDataRGX = TaskMethods.CollectionRegex("data/" + filepath.ReturnFilePath(), RgxString.LeafDataRGX);
            leafs = DoTree(LeafDataRGX, leafs, dataTypes, filepath);
            return leafs;
        }
        public static int? returnDataType(string syntax, List<DataType> dataTypes)
        {
            try
            {
                int? indexOfDataType = dataTypes.Where(x => x.Name == syntax).FirstOrDefault().Id;
                return indexOfDataType;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public static LeafNode DoTree(MatchCollection collection, LeafNode leafs, List<DataType> dataTypes, string filepath)
        {
            foreach (Match match in collection)
            {
                //To LeafData
                #nullable enable
                Sequence? sequence = null;
                string syntax = match.Groups[2].Value.RemoveSpecialCharacter();
                int? objectType = null;
                DATATYPE? classicDataType = ConverterToEnum.ToDatatype(syntax);
                if (classicDataType == DATATYPE.UNKNOWN)
                {
                    objectType = returnDataType(syntax, dataTypes);
                    if (objectType == null)
                    {
                        sequence = SequenceParser.ReturnSequence(filepath, syntax);
                    }
                    if (sequence != null || objectType != null)
                    {
                        classicDataType = null;
                    }
              
                }
                string restricion = match.Groups[3].Value.RemoveSpecialCharacter();
                Restricion res = RestricionParser.ReturnRestricion(restricion);
                string enumm = match.Groups[4].Value.RemoveSpecialCharacter();
                Dictionary<int, string> enumDict = EnumParser.ReturnEnum(enumm);
                if(res == null && enumDict != null)
                {
                    res = RestricionParser.ReturnRestricionFromEnum(enumDict);
                }
                string access = match.Groups[5].Value.RemoveSpecialCharacter();
                string status = match.Groups[6].Value.RemoveSpecialCharacter();
                string description = match.Groups[7].Value.RemoveSpecialCharacter().RemoveSpaces();
                string indexx = match.Groups[8].Value.RemoveSpecialCharacter();
                string[] indexTab = indexx.Split(',');
                //string restricion = match.Groups[8].Value.RemoveSpecialCharacter();
                LeafData leafData = new LeafData()
                {
                    Index = indexTab,
                    Restrictions = restricion,
                    DTRestricion = res,
                    DTEnum = enumDict,
                    ClassicDataType = classicDataType,
                    ImportedObjectType = objectType,
                    SequenceObjectType = sequence,
                    Status = ConverterToEnum.ToStatus(status),
                    Access = ConverterToEnum.ToAccess(access),
                    Description = description
                };
                //To tree
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                string parentName = match.Groups[9].Value.RemoveSpecialCharacter();
                int index = Int32.Parse(match.Groups[10].Value.RemoveSpecialCharacter());

                LeafNode master = leafs.SearchNode(parentName, leafs);

                LeafNode newLeaf = new LeafNode()
                {
                    Name = name,
                    Index = index,
                    LeafData = leafData
                };

                master.Children.Add(newLeaf);

            }
            return leafs;
        }

        public static List<LeafData> DoTree1(MatchCollection collection)
        {
            List<LeafData> listOfLeafs = new List<LeafData>();
            foreach (Match match in collection)
            {
                
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                string syntax = match.Groups[2].Value.RemoveSpecialCharacter();
                string access = match.Groups[3].Value.RemoveSpecialCharacter();
                string status = match.Groups[4].Value.RemoveSpecialCharacter();

                //Descirption
                string desc = match.Groups[5].Value.RemoveSpecialCharacter();
                do
                {
                    desc = desc.Replace("  ", " ");

                } while (desc.Contains("  "));

                LeafData leaf = new LeafData()
                {
                    //ObjectType = name,
                    Status = ConverterToEnum.ToStatus(status),
                    Access = ConverterToEnum.ToAccess(access),
                    Description = desc

                };
                listOfLeafs.Add(leaf);

            }
            return listOfLeafs;
        }
    }
}
