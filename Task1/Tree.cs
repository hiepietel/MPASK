using System.Collections.Generic;
using System;
using Task1.Model;
using Task1.Enums;

public class LeafNode
{
    public LeafNode()
    {
        Children = new List<LeafNode>();
    }
    public string Name { get; set; }
    public  int Index { get; set; }
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
                if (child.Index ==Int32.Parse(index))
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
        Console.ForegroundColor = returnConsoleColor(master);
        Console.WriteLine(" "+master.Index+ " " + master.Name);
        Console.ForegroundColor = ConsoleColor.White;
        level++;
        foreach (LeafNode child in master.Children)
        {

                PrintTree(child, level);
        }
        level--;
    }
    public ConsoleColor returnConsoleColor(LeafNode master)
    {
        //white - normal
        //Cyan - is dataleaf
        //DarkMagenta - leaf data and datatype

        ConsoleColor color = ConsoleColor.White;
        if (master.LeafData != null)
        {
            color = ConsoleColor.Cyan;
        }
        //is datatype
        try
        {
            if (master.LeafData.ClassicDataType!= null)
            {
                color = ConsoleColor.Blue;
                if(master.LeafData.ClassicDataType == DATATYPE.UNKNOWN)
                {
                    color = ConsoleColor.DarkYellow;
                }
            }
        }
        catch(Exception ex)
        {

        }
        try
        {
            if (master.LeafData.ImportedObjectType != null)
            {
                color = ConsoleColor.DarkMagenta;
            }
        }
        catch (Exception ex)
        {

        }
        try
        {
            if (master.LeafData.SequenceObjectType != null)
            {
                if (master.LeafData.SequenceObjectType.IsSequenceOf)
                {
                    color = ConsoleColor.DarkRed;
                }
                else
                {
                    color = ConsoleColor.Green;
                }
            }
        }
        catch(Exception ex)
        {

        }
        return color;
    }

}
