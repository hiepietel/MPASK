using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task1.Model;

namespace Task1.Method
{
    public static class LeafParser
    {
        public static List<Leaf> ReturnTree(string filepath, List<Leaf> leafs)
        {
            MatchCollection leafsRGX = TaskMethods.CollectionRegex("data/" + filepath.ReturnFilePath(), RegexString.LeafRGX);
            List<Leaf> list = DoTree(leafsRGX, leafs);
            return list;
        }
        public static List<Leaf> DoTree(MatchCollection collection, List<Leaf> leafs)
        {
            foreach (Match match in collection)
            {
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                string[] positions = match.Groups[2].Value.RemoveSpecialCharacter().Split(' '); ;

                string parentName = positions[0];
                string parentLeaf = leafs.Find(x => x.Name == parentName).Name;
                string parentOID = leafs.Find(x => x.Name == parentName).OID;

                for (int i = 1; i < positions.Length - 1; i++)
                {
                    parentLeaf = leafs.Find(x => x.Name == parentName).Name;
                    string[] data = positions[i].Split('(');
                    string nameLeaf = "";
                    int indexLeaf = 0;
                    if (data.Length > 1)
                    {
                        nameLeaf = data[0];
                        
                        indexLeaf = Int32.Parse(data[1].Remove(data[1].IndexOf(')')));
                        parentOID = parentOID + "." + indexLeaf.ToString();
                        
                        Leaf newLeaf2 = new Leaf()
                        {
                            Id = 0,
                            Name = nameLeaf,
                            Index = indexLeaf,
                            ParentName = parentLeaf,
                            OID = parentOID

                        };
                        parentLeaf = nameLeaf;
                        leafs.Add(newLeaf2);
                    }


                }
                
                Leaf newLeaf = new Leaf()
                {
                    Id = 0,
                    Name = name,
                    Index = Int32.Parse(positions[positions.Length - 1]),
                    ParentName = parentLeaf,
                    OID = parentOID + "." + positions[positions.Length - 1]

                };
                leafs.Add(newLeaf);
            }
            return leafs;
        }
        public static List<Leaf> InitTree()
        {
            List<Leaf> listOfLeafs = new List<Leaf>();
            Leaf RootNode = new Leaf()
            {
                Id = 0,
                Name = "Root-Node",
                ParentName = "null",
                Index = 0,
                OID="0"
            };
            listOfLeafs.Add(RootNode);
            Leaf ccitt = new Leaf()
            {
                Id = 1,
                Name = "ccitt",
                ParentName = "Root-Node",
                Index = 0,
                OID= "1"
            };
            listOfLeafs.Add(ccitt);
            Leaf iso = new Leaf()
            {
                Id = 2,
                Name = "iso",
                ParentName = "Root-Node",
                Index = 1,
                OID = "1"
            };
            listOfLeafs.Add(iso);
            Leaf joint = new Leaf()
            {
                Id = 3,
                Name = "joint",
                ParentName = "Root-Node",
                Index = 2,
                OID = "2"
            };
            listOfLeafs.Add(joint);
            return listOfLeafs;
        }
    }
}
