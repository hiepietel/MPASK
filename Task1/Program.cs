using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Task1;
using Task1.Method;
using Task1.Model;
using Task1.Parser;

class Program
{
    static void Main()
    {
        MIBreader mibreader = new MIBreader();
        mibreader.Import();
        mibreader.leafs.PrintTree(mibreader.leafs);
        LeafNode? searched = mibreader.leafs.SearchByOID("1.3.6.1", mibreader.leafs);
        Console.ReadKey();
    }

}