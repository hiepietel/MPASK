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
    public static class LeafParser
    {
        public static LeafNode ReturnTree(string filepath, LeafNode leafs)
        {
            MatchCollection leafsRGX = TaskMethods.CollectionRegex("data/" + filepath.ReturnFilePath(), RgxString.LeafRGX );
            leafs = DoTree(leafsRGX, leafs);
            return leafs;
        }
        public static LeafNode DoTree(MatchCollection collection, LeafNode leafs)
        {
            foreach (Match match in collection)
            {
                string name = match.Groups[1].Value.RemoveSpecialCharacter();
                if (name == "") 
                    Console.WriteLine("empty");
                string pos = match.Groups[2].Value.RemoveSpecialCharacter();
                string[] poss = pos.Split(' ');
                string parentName = poss[0];
                for (int i = 1; i < poss.Length-1; i++)
                {
                    Match extraLeaf = TaskMethods.MatchRegex(poss[i], RgxString.LeafMany, false);
                    string singleName = extraLeaf.Groups[1].Value.RemoveSpecialCharacter();
                    int singlePos = Int32.Parse(extraLeaf.Groups[2].Value.RemoveSpecialCharacter());
                    LeafNode singleMaster = leafs.SearchNode(parentName, leafs);
                    LeafNode singleLeaf = new LeafNode()
                    {
                        Name = singleName,
                        Index = singlePos,
                        LeafData = null

                    };
                    singleMaster.Children.Add(singleLeaf);
                    parentName = singleName;
                }
                
               
                int index = Int32.Parse(poss[poss.Length-1]);
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
