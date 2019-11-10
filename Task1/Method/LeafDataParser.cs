using Model.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task1.Method
{
    public static class LeafDataParser
    {
        public static List<LeafData> DoTree(MatchCollection collection)
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
                    ObjectType = name,
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
