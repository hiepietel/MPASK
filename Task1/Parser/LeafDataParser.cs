using Task1.Model;
using Task1.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1.Parser
{
    public static class LeafDataParser
    {
        public static List<LeafData> ReturnTree(string filepath, List<LeafData> leafs)
        {
            MatchCollection matches = Methods.CollectionRegex("data/" + filepath.ReturnFilePath(), RegexString.LeafDataRGX);
            leafs = DoTree(matches);
            return leafs;
        }
        public static List<LeafData> DoTree(MatchCollection collection)
        {
            List<LeafData> listOfLeafs = new List<LeafData>();
            foreach (Match match in collection)
            {
                 try
                {
                    string name = match.Groups[1].Value.RemoveSpecialCharacter();
                    string syntax = match.Groups[2].Value.RemoveSpecialCharacter();
                    string access = match.Groups[3].Value.RemoveSpecialCharacter();
                    string status = match.Groups[4].Value.RemoveSpecialCharacter();

                    //Descirption
                    string desc = match.Groups[5].Value.RemoveSpecialCharacter().RemoveSpaces();
                    string parentName = match.Groups[6].Value.RemoveSpecialCharacter();
                    int index = Int32.Parse(match.Groups[7].Value.RemoveSpecialCharacter());

                    LeafData leaf = new LeafData()
                    {
                        ObjectType = name,
                        Status = ConverterToEnum.ToStatus(status),
                        Access = ConverterToEnum.ToAccess(access),
                        Description = desc, 
                        ParentName = parentName,
                        Index = index

                    };
                    listOfLeafs.Add(leaf);
                }
                catch (Exception ex)
                {
                    Logger.Error("Cannot add new leaf data: " + ex);
                    throw;
                }

            }
            return listOfLeafs;
        }
    }
}
