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
        public static LeafNode ReturnTree(string filepath, LeafNode leafs)
        {
            MatchCollection leafsRGX = TaskMethods.CollectionRegex("data/" + filepath.ReturnFilePath(), RegexString.LeafRGX);
            LeafNode list = DoTree(leafsRGX, leafs);
            return list;
        }
        public static LeafNode DoTree(MatchCollection collection, LeafNode leafs)
        {
            foreach (Match match in collection)
            {
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                string[] positions = match.Groups[2].Value.RemoveSpecialCharacter().Split(' ');
                string parentName = positions[0];
                //string[] data = positions[1].Split('(');
                //int index = Int32.Parse(data[1].Remove(data[1].IndexOf(')')));
                int index = Int32.Parse(positions[1]);
                LeafNode master = leafs.SearchNode(parentName, leafs);

                LeafNode newLeaf = new LeafNode()
                {
                    Name = name,
                    Index = index,
                    LeafData =null
                    
                };
                master.Children.Add(newLeaf);

            }
            return leafs;
        }
        public static LeafNode InitNodeTRee()
        {
            LeafNode RootNode = new LeafNode()
            {
                Name = "Root-Node"

            };
            LeafNode ccitt = new LeafNode()
            {
                Name = "ccitt",
                Index =0
            };
            LeafNode iso = new LeafNode()
            {
                Name = "iso",
                Index = 1
            };
            LeafNode joint = new LeafNode()
            {
                Name = "joint",
                Index = 2
            };
            RootNode.Children.Add(ccitt);
            RootNode.Children.Add(iso);
            RootNode.Children.Add(joint);

            return RootNode;
        }
    }
}
