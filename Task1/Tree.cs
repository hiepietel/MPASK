using System.Collections.Generic;
using System;
public class LeafNode
{
    public LeafNode()
    {
        Children = new List<LeafNode>();
    }
    public string Name { get; set; }
    public  int Index { get; set; }
    public List<LeafNode> Children { get; set; }
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
        
        Console.WriteLine(" "+master.Index+ " " + master.Name);
        level++;
        foreach (LeafNode child in master.Children)
        {

                PrintTree(child, level);
        }
        level--;
    }

}
