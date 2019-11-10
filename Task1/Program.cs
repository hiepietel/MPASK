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
    static void Main()
    {
        //initData
        string mainFilePath = "RFC1213";
        List<Leaf> leafs = new List<Leaf>();
        List<DataType> dataTypes = new List<DataType>();
        List<LeafData> leafDatas = new List<LeafData>();

        //InitTree();
        Match imports = TaskMethods.MatchRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.ImportsRGX);
        string toImport = imports.Value.Replace("IMPORTS", "").RemoveSpecialCharacter().RemoveSpaces();
        MatchCollection importData = TaskMethods.CollectionRegex(toImport, RegexString.ImportSortedRGX, false);
        foreach (Match itemm in importData)
        {
            //List<string> datatypesToImport= itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',').T;
            string[] items = itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',');
            string from = itemm.Groups[2].Value.RemoveSpecialCharacter();
        }

        //MatchCollection leafsRGX = Regex.Matches(TaskMethods.ReadFile("data/FC1155SMI.txt"), RegexString.DataRGX, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        MatchCollection leafsRGX = TaskMethods.CollectionRegex("data/"+mainFilePath.ReturnFilePath(), RegexString.DataRGX);
        leafs = LeafParser.DoTree(leafsRGX);


        //MatchCollection matchesData = Regex.Matches(TaskMethods.ReadFile("data/FC1155SMI.txt"), dataTypeRGXverOne, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        MatchCollection matchesData = TaskMethods.CollectionRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.DataTypeRGX);
        dataTypes = DataTypeParser.DoTree(matchesData);


        //MatchCollection matches = Regex.Matches(TaskMethods.ReadFile("data/MIB.txt"), rgxPro, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        MatchCollection matches = TaskMethods.CollectionRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.DataRGX);
        leafDatas = LeafDataParser.DoTree(matches);

        //List <LeafData> listOfLeafs = new List<LeafData>();
        Console.ReadKey();
    }

}