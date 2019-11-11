using Model.Task1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Task1;
using Task1.Method;
using Task1.Model;

class Program
{
    static List<Leaf> leafs = new List<Leaf>();
    static List<string> importedFiles = new List<string>();

    static void Import(string mainFilePath)
    {
        Match imports = TaskMethods.MatchRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.ImportsRGX);
        string toImport = imports.Value.Replace("IMPORTS", "").RemoveSpecialCharacter().RemoveSpaces();
        MatchCollection importData = TaskMethods.CollectionRegex(toImport, RegexString.ImportSortedRGX, false);
        foreach (Match itemm in importData)
        {
            //List<string> datatypesToImport= itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',').T;
            string[] items = itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',');
            string from = itemm.Groups[2].Value.RemoveSpecialCharacter();
            
            
            if (!importedFiles.Contains(from))
            {
                importedFiles.Add(from);
                leafs = LeafParser.ReturnTree(from, leafs);
                Import(from);
            }
            
        }
    }
    static void Main()
    {
        ////initData
        string mainFilePath = "RFC1213";
        //leafs = LeafParser.InitTree();
        ////ImportFromFiles
        //Import(mainFilePath);
        ////Add main file 
        //importedFiles.Add(mainFilePath);
        //leafs = LeafParser.ReturnTree(mainFilePath, leafs);



        //MatchCollection matchesData = Regex.Matches(TaskMethods.ReadFile("data/FC1155SMI.txt"), dataTypeRGXverOne, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        MatchCollection matchesData = TaskMethods.CollectionRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.DataTypeRGX);
        var dataTypes = DataTypeParser.DoTree(matchesData);


        //MatchCollection matches = Regex.Matches(TaskMethods.ReadFile("data/MIB.txt"), rgxPro, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        MatchCollection matches = TaskMethods.CollectionRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.LeafDataRGX);
        var leafDatas = LeafDataParser.DoTree(matches);

        //List <LeafData> listOfLeafs = new List<LeafData>();
        foreach (var item in leafs)
        {
            Console.WriteLine(item.OID + " " +item.Name);
        }
        Console.ReadKey();
    }

}