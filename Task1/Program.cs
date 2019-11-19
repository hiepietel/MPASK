using Task1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Task1.Logs;
using Task1.Parser;


class Program
{
    static List<Leaf> leafs = new List<Leaf>();
    static List<string> importedFiles = new List<string>();
    static List<DataType> dataTypes = new List<DataType>();
    //DataTypeParser.DoTree(matchesData);

    static void Import(string mainFilePath)
    {
        Match imports = Methods.MatchRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.ImportsRGX);
        string toImport = imports.Value.Replace("IMPORTS", "").RemoveSpecialCharacter().RemoveSpaces();
        MatchCollection importData = Methods.CollectionRegex(toImport, RegexString.ImportSortedRGX, false);
        foreach (Match itemm in importData)
        {
            //List<string> datatypesToImport= itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',').T;
            string[] items = itemm.Groups[1].Value.RemoveSpecialCharacter().Split(',');
            string from = itemm.Groups[2].Value.RemoveSpecialCharacter();


            if (!importedFiles.Contains(from))
            {
                importedFiles.Add(from);
                leafs = LeafParser.ReturnTree(from, leafs);
                dataTypes = DataTypeParser.ReturnTree(from, dataTypes);
                Logger.Info("Imported from file: " + from);
                Import(from);
            }

        }
    }
    static void Main()
    {
        Logger.Info("init Program");
        //initData
        string mainFilePath = "RFC1213";
        leafs = LeafParser.InitTree();
        //ImportFromFiles
        Import(mainFilePath);
        //Add main file 
        importedFiles.Add(mainFilePath);
        leafs = LeafParser.ReturnTree(mainFilePath, leafs);
        dataTypes = DataTypeParser.ReturnTree(mainFilePath, dataTypes);


        //MatchCollection matches = Regex.Matches(TaskMethods.ReadFile("data/MIB.txt"), rgxPro, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
        //MatchCollection matches = Methods.CollectionRegex("data/" + mainFilePath.ReturnFilePath(), RegexString.LeafDataRGX);
        List<LeafData> leafDatas = new List<LeafData>();
        leafDatas = LeafDataParser.ReturnTree(mainFilePath, leafDatas);
        //map to leaf
        foreach (var item in leafDatas)
        {
            try
            {
                Leaf Parent = leafs.Find(x => x.Name == item.ParentName);
                Leaf newleaf = new Leaf()
                {
                    Name = item.ObjectType,
                    ParentName = item.ParentName,
                    Index = item.Index,
                    OID = Parent.OID + "." + item.Index.ToString()
                };
                leafs.Add(newleaf);
            }
            catch (Exception ex)
            {
                Logger.Error("Cannot map leafData to leaf: " + ex.Message);
            }
        }
        //List <LeafData> listOfLeafs = new List<LeafData>();
        foreach (var item in leafs)
        {
            Console.WriteLine(item.OID + " " + item.Name);
        }
        Console.ReadKey();
    }

}