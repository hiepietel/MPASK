
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Model;

namespace Task1.Method
{
    public static class LeafDataParser
    {
        public static LeafNode DoTree(MatchCollection collection, LeafNode leafs)
        {
            foreach (Match match in collection)
            {
                //To LeafData
                string syntax = match.Groups[2].Value.RemoveSpecialCharacter();
                string restricion = match.Groups[3].Value.RemoveSpecialCharacter();
                string access = match.Groups[4].Value.RemoveSpecialCharacter();
                string status = match.Groups[5].Value.RemoveSpecialCharacter();
                string description = match.Groups[6].Value.RemoveSpecialCharacter().RemoveSpaces();
                string indexx = match.Groups[7].Value.RemoveSpecialCharacter();
                string[] indexTab = indexx.Split(',');
                //string restricion = match.Groups[8].Value.RemoveSpecialCharacter();
                LeafData leafData = new LeafData()
                {
                    Index = indexTab,
                    Restrictions = restricion,
                    Syntax = syntax,
                    Status = ConverterToEnum.ToStatus(status),
                    Access = ConverterToEnum.ToAccess(access),
                    Description = description
                };
                //To tree
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                string parentName = match.Groups[8].Value.RemoveSpecialCharacter();
                int index = Int32.Parse(match.Groups[9].Value.RemoveSpecialCharacter());

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
