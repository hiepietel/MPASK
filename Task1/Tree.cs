using System.Collections.Generic;
using System;
using Task1.Model;
using Task1.Enums;
using Task1.Method;

public class LeafNode
{
    public LeafNode()
    {
        Children = new List<LeafNode>();
    }
    public string Name { get; set; }
    public int Index { get; set; }
#nullable enable
    public LeafData? LeafData { get; set; }
    public List<LeafNode> Children { get; set; }
    public LeafNode? SearchByOID(string OID, LeafNode leafNode)
    {
        string[] indexStr = OID.Split('.');
        foreach (string index in indexStr)
        {
            bool searched = false;
            foreach (LeafNode child in leafNode.Children)
            {
                if (child.Index == Int32.Parse(index))
                {
                    searched = true;
                    leafNode = child;
                }
            }
            if (!searched) return null;

        }
        return leafNode;

    }

    public LeafNode SearchNode(string name, LeafNode startLeaf)
    {
        if (startLeaf.Name == name)
        {
            return startLeaf;
        }
        foreach (LeafNode child in startLeaf.Children)
        {

            if (child.Name == name)
            {
                return child;
            }
            else
            {
                startLeaf = SearchNode(name, child);
                if (startLeaf != null)
                {
                    return startLeaf;
                }
            }

        }

        return null;
    }
    public void PrintTree(LeafNode master, int level = 0)
    {
        for (int i = 0; i < level; i++)
        {
            Console.Write(" | ");
        }
        //dataleaf is
        Console.ForegroundColor = TaskMethods.ReturnConsoleColor(master);
        Console.WriteLine(" " + master.Index + " " + master.Name);
        Console.ForegroundColor = ConsoleColor.White;
        level++;
        foreach (LeafNode child in master.Children)
        {

            PrintTree(child, level);
        }
        level--;
    }
    public List<LeafNode> ListOfSequences(LeafNode master)
    {
        List<LeafNode> list = new List<LeafNode>();
        list = SearchSequence(master, list);
        return list;
    }
    private List<LeafNode> SearchSequence(LeafNode master, List<LeafNode> leafNodes)
    {
        foreach (LeafNode child in master.Children)
        {
            if (child.LeafData != null)
                if (child.LeafData.SequenceObjectType != null)
                    if (child.LeafData.SequenceObjectType.IsSequenceOf)
                        leafNodes.Add(child);

            leafNodes = SearchSequence(child, leafNodes);
        }
        return leafNodes;
    }


}
